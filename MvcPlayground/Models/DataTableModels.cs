using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace MvcPlayground.Models
{
    public class JqDataTable<T>
    {
        // properties are not capital due to json mapping
        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
        public List<Column> columns { get; set; }
        public Search search { get; set; }
        public List<Order> order { get; set; }

        public IEnumerable<T> results { get; set; }
        private IEnumerable<T> Source { get; set; } 
 
        public void Init(IEnumerable<T> source){
            // state changing
            results = source;
            // immutable original
            Source = source;
        }

        public Response<T> Response(){

            return new Response<T>
            {
                draw = draw,
                recordsTotal = Source.Count(),
                recordsFiltered = Source.Count(),
                data = results 
            };
        }
    }

    // received data
    public class Column
    {
        public string data { get; set; }
        public string name { get; set; }
        public bool searchable { get; set; }
        public bool orderable { get; set; }
        public Search search { get; set; }
    }

    public class Search
    {
        public string value { get; set; }
        public string regex { get; set; }
    }

    public class Order
    {
        public int column { get; set; }
        public string dir { get; set; }
    }

    // returned data
    public class Response<T>{
        public long draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public IEnumerable<T> data { get; set; }
    }

    public static class JqExtensions {
        
        public static JqDataTable<T> Sort<T>(this JqDataTable<T> model){

            // is sort
            if (model.order.Count == 1)
            {

                var column = model.order.ElementAt(0).column;
                var sortType = model.order.ElementAt(0).dir;
                var colName = model.columns.ElementAt(column).data;

                if (sortType == "asc")
                {
                    model.results = model.results.OrderBy(x => x.GetType().GetProperty(colName).GetValue(x, null)).ToList();
                }
                else
                {
                    model.results = model.results.OrderByDescending(x => x.GetType().GetProperty(colName).GetValue(x, null)).ToList();
                }

            }

            return model;
        }

        public static JqDataTable<T> Search<T>(this JqDataTable<T> model){
            
            if (!String.IsNullOrEmpty(model.search.value))
            {
                var query = model.search.value.ToLower();

                model.results = model.results.Where(x =>
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

        public static JqDataTable<T> Paginate<T>(this JqDataTable<T> model){

            model.results = model.results.Skip((int)model.start).Take((int)model.length).ToList();

            return model;
        }
    }
}
