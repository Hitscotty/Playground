using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace JqDataTable
{
    /// <summary>
    /// helper types for working with a jquery datatable serverside.
    /// includes client data and necessary response objects
    /// </summary>
    public class JqDataTable<T>
    {
        [JsonProperty("draw")]
        public int Draw { get; set; }
        [JsonProperty("start")]
        public int Start { get; set; }
        [JsonProperty("length")]
        public int Length { get; set; }
        [JsonProperty("columns")]
        public List<Column> Columns { get; set; }
        [JsonProperty("search")]
        public Search Search { get; set; }
        [JsonProperty("order")]
        public List<Order> Order { get; set; }

        [JsonProperty("results")]
        public IEnumerable<T> Results { get; set; }
        private IEnumerable<T> Source { get; set; } 
 
        public void Init(IEnumerable<T> source){
            // state changing
            Results = source;
            // immutable original
            Source = source;
        }

        public Response<T> Response(){

            return new Response<T>
            {
                Draw = Draw,
                RecordsTotal = Source.Count(),
                RecordsFiltered = Source.Count(),
                Data = Results 
            };
        }
    }

    public class Column
    {
        [JsonProperty("data")]
        public string Data { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("searchable")]
        public bool Searchable { get; set; }
        [JsonProperty("orderable")]
        public bool Orderable { get; set; }
        [JsonProperty("search")]
        public Search Search { get; set; }
    }

    public class Search
    {
        [JsonProperty("Value")]
        public string Value { get; set; }
        [JsonProperty("regex")]
        public string Regex { get; set; }
    }

    public class Order
    {
        [JsonProperty("column")]
        public int Column { get; set; }
        [JsonProperty("dir")]
        public string Dir { get; set; }
    }

    /// <summary>
    /// The data that the jquery datatable expects in response
    /// </summary>
    public class Response<T>{
        [JsonProperty("draw")]
        public long Draw { get; set; }
        [JsonProperty("recordsTotal")]
        public int RecordsTotal { get; set; }
        [JsonProperty("recordsFiltered")]
        public int RecordsFiltered { get; set; }
        [JsonProperty("data")]
        public IEnumerable<T> Data { get; set; }
    }

    /// <summary>
    /// JqDataTable serverside operations as extension methods
    /// </summary>
    public static class JqExtensions {

        /// <summary>
        /// Uses current instance of JqDataTable to sort the source
        /// </summary>
        /// <returns>The sort.</returns>
        /// <param name="model">Model.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static JqDataTable<T> Sort<T>(this JqDataTable<T> model){

            // is sort
            if (model.Order.Count == 1)
            {

                var column = model.Order.ElementAt(0).Column;
                var sortType = model.Order.ElementAt(0).Dir;
                var colName = model.Columns.ElementAt(column).Data;

                if (sortType == "asc")
                {
                    model.Results = model.Results.OrderBy(x => x.GetType().GetProperty(colName).GetValue(x, null)).ToList();
                }
                else
                {
                    model.Results = model.Results.OrderByDescending(x => x.GetType().GetProperty(colName).GetValue(x, null)).ToList();
                }

            }

            return model;
        }

        /// <summary>
        /// Uses current state of JqDataTable instance to search the source
        /// </summary>
        /// <returns>The search.</returns>
        /// <param name="model">Model.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static JqDataTable<T> Search<T>(this JqDataTable<T> model){
            
            if (!String.IsNullOrEmpty(model.Search.Value))
            {
                var query = model.Search.Value.ToLower();

                model.Results = model.Results.Where(x =>
                {
                    // check all keys for value 
                    foreach (var prop in x.GetType().GetProperties())
                    {
                        var currentValue = prop.GetValue(x, null).ToString().ToLower();
                        if (currentValue.Contains(query))
                        {
                            return true;
                        }
                    }
                    return false;
                }).ToList();

            }

            return model;
        }

        /// <summary>
        /// Uses the current instance of the JqDataTable to paginate the instance
        /// </summary>
        /// <returns>The paginate.</returns>
        /// <param name="model">Model.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static JqDataTable<T> Paginate<T>(this JqDataTable<T> model){

            model.Results = model.Results.Skip((int)model.Start).Take((int)model.Length).ToList();

            return model;
        }
    }
}
