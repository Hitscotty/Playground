using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcPlayground.Models;
using Newtonsoft.Json;

namespace MvcPlayground.Controllers
{
    public class HomeController : Controller
    {
        public class Sample{
            public string name { get; set; }
            public string last { get; set; }
            public string title { get; set; }
            public string location { get; set; }
            public string date { get; set; }
            public string salary { get; set; }
        }
        public List<Sample> SampleDataBaseData = new List<Sample>{
            
   new Sample {  
      name="Tiger Nixon",
      last="System Architect",
      title="Edinburgh",
      location="5421",
      date="2011/04/25",
      salary="$320,800"
   },
   new Sample {  
      name="Garrett Winters",
      last="Accountant",
      title="Tokyo",
      location="8422",
      date="2011/07/25",
      salary="$170,750"
   },
   new Sample {  
      name="Ashton Cox",
      last="Junior Technical Author",
      title="San Francisco",
      location="1562",
      date="2009/01/12",
      salary="$86,000"
   },
   new Sample {  
      name="Cedric Kelly",
      last="Senior Javascript Developer",
      title="Edinburgh",
      location="6224",
      date="2012/03/29",
      salary="$433,060"
   },
   new Sample {  
      name="Airi Satou",
      last="Accountant",
      title="Tokyo",
      location="5407",
      date="2008/11/28",
      salary="$162,700"
   },
   new Sample {  
      name="Brielle Williamson",
      last="Integration Specialist",
      title="New York",
      location="4804",
      date="2012/12/02",
      salary="$372,000"
   },
   new Sample {  
      name="Herrod Chandler",
      last="Sales Assistant",
      title="San Francisco",
      location="9608",
      date="2012/08/06",
      salary="$137,500"
   },
   new Sample {  
      name="Rhona Davidson",
      last="Integration Specialist",
      title="Tokyo",
      location="6200",
      date="2010/10/14",
      salary="$327,900"
   },
   new Sample {  
      name="Colleen Hurst",
      last="Javascript Developer",
      title="San Francisco",
      location="2360",
      date="2009/09/15",
      salary="$205,500"
   },
   new Sample {  
      name="Sonya Frost",
      last="Software Engineer",
      title="Edinburgh",
      location="1667",
      date="2008/12/13",
      salary="$103,600"
   },
   new Sample {  
      name="Jena Gaines",
      last="Office Manager",
      title="London",
      location="3814",
      date="2008/12/19",
      salary="$90,560"
   },
   new Sample {  
      name="Quinn Flynn",
      last="Support Lead",
      title="Edinburgh",
      location="9497",
      date="2013/03/03",
      salary="$342,000"
   },
   new Sample {  
      name="Charde Marshall",
      last="Regional Director",
      title="San Francisco",
      location="6741",
      date="2008/10/16",
      salary="$470,600"
   },
   new Sample {  
      name="Haley Kennedy",
      last="Senior Marketing Designer",
      title="London",
      location="3597",
      date="2012/12/18",
      salary="$313,500"
   },
   new Sample {  
      name="Tatyana Fitzpatrick",
      last="Regional Director",
      title="London",
      location="1965",
      date="2010/03/17",
      salary="$385,750"
   },
   new Sample {  
      name="Michael Silva",
      last="Marketing Designer",
      title="London",
      location="1581",
      date="2012/11/27",
      salary="$198,500"
   },
   new Sample {  
      name="Paul Byrd",
      last="Chief Financial Officer (CFO)",
      title="New York",
      location="3059",
      date="2010/06/09",
      salary="$725,000"
   },
   new Sample {  
      name="Gloria Little",
      last="Systems Administrator",
      title="New York",
      location="1721",
      date="2009/04/10",
      salary="$237,500"
   },
   new Sample {  
      name="Bradley Greer",
      last="Software Engineer",
      title="London",
      location="2558",
      date="2012/10/13",
      salary="$132,000"
   },
   new Sample {  
      name="Dai Rios",
      last="Personnel Lead",
      title="Edinburgh",
      location="2290",
      date="2012/09/26",
      salary="$217,500"
   },
   new Sample {  
      name="Jenette Caldwell",
      last="Development Lead",
      title="New York",
      location="1937",
      date="2011/09/03",
      salary="$345,000"
   },
   new Sample {  
      name="Yuri Berry",
      last="Chief Marketing Officer (CMO)",
      title="New York",
      location="6154",
      date="2009/06/25",
      salary="$675,000"
   },
   new Sample {  
      name="Caesar Vance",
      last="Pre-Sales Support",
      title="New York",
      location="8330",
      date="2011/12/12",
      salary="$106,450"
   },
   new Sample {  
      name="Doris Wilder",
      last="Sales Assistant",
      title="Sidney",
      location="3023",
      date="2010/09/20",
      salary="$85,600"
   },
   new Sample {  
      name="Angelica Ramos",
      last="Chief Executive Officer (CEO)",
      title="London",
      location="5797",
      date="2009/10/09",
      salary="$1,200,000"
   },
   new Sample {  
      name="Gavin Joyce",
      last="Developer",
      title="Edinburgh",
      location="8822",
      date="2010/12/22",
      salary="$92,575"
   },
   new Sample {  
      name="Jennifer Chang",
      last="Regional Director",
      title="Singapore",
      location="9239",
      date="2010/11/14",
      salary="$357,650"
   },
   new Sample {  
      name="Brenden Wagner",
      last="Software Engineer",
      title="San Francisco",
      location="1314",
      date="2011/06/07",
      salary="$206,850"
   },
   new Sample {  
      name="Fiona Green",
      last="Chief Operating Officer (COO)",
      title="San Francisco",
      location="2947",
      date="2010/03/11",
      salary="$850,000"
   },
   new Sample {  
      name="Shou Itou",
      last="Regional Marketing",
      title="Tokyo",
      location="8899",
      date="2011/08/14",
      salary="$163,000"
   },
   new Sample {  
      name="Michelle House",
      last="Integration Specialist",
      title="Sidney",
      location="2769",
      date="2011/06/02",
      salary="$95,400"
   },
   new Sample {  
      name="Suki Burks",
      last="Developer",
      title="London",
      location="6832",
      date="2009/10/22",
      salary="$114,500"
   },
   new Sample {  
      name="Prescott Bartlett",
      last="Technical Author",
      title="London",
      location="3606",
      date="2011/05/07",
      salary="$145,000"
   },
   new Sample {  
      name="Gavin Cortez",
      last="Team Leader",
      title="San Francisco",
      location="2860",
      date="2008/10/26",
      salary="$235,500"
   },
   new Sample {  
      name="Martena Mccray",
      last="Post-Sales support",
      title="Edinburgh",
      location="8240",
      date="2011/03/09",
      salary="$324,050"
   },
   new Sample {  
      name="Unity Butler",
      last="Marketing Designer",
      title="San Francisco",
      location="5384",
      date="2009/12/09",
      salary="$85,675"
   },
   new Sample {  
      name="Howard Hatfield",
      last="Office Manager",
      title="San Francisco",
      location="7031",
      date="2008/12/16",
      salary="$164,500"
   },
   new Sample {  
      name="Hope Fuentes",
      last="Secretary",
      title="San Francisco",
      location="6318",
      date="2010/02/12",
      salary="$109,850"
   },
   new Sample {  
      name="Vivian Harrell",
      last="Financial Controller",
      title="San Francisco",
      location="9422",
      date="2009/02/14",
      salary="$452,500"
   },
   new Sample {  
      name="Timothy Mooney",
      last="Office Manager",
      title="London",
      location="7580",
      date="2008/12/11",
      salary="$136,200"
   },
   new Sample {  
      name="Jackson Bradshaw",
      last="Director",
      title="New York",
      location="1042",
      date="2008/09/26",
      salary="$645,750"
   },
   new Sample {  
      name="Olivia Liang",
      last="Support Engineer",
      title="Singapore",
      location="2120",
      date="2011/02/03",
      salary="$234,500"
   },
   new Sample {  
      name="Bruno Nash",
      last="Software Engineer",
      title="London",
      location="6222",
      date="2011/05/03",
      salary="$163,500"
   },
   new Sample {  
      name="Sakura Yamamoto",
      last="Support Engineer",
      title="Tokyo",
      location="9383",
      date="2009/08/19",
      salary="$139,575"
   },
   new Sample {  
      name="Thor Walton",
      last="Developer",
      title="New York",
      location="8327",
      date="2013/08/11",
      salary="$98,540"
   },
   new Sample {  
      name="Finn Camacho",
      last="Support Engineer",
      title="San Francisco",
      location="2927",
      date="2009/07/07",
      salary="$87,500"
   },
   new Sample {  
      name="Serge Baldwin",
      last="Data Coordinator",
      title="Singapore",
      location="8352",
      date="2012/04/09",
      salary="$138,575"
   },
   new Sample {  
      name="Zenaida Frank",
      last="Software Engineer",
      title="New York",
      location="7439",
      date="2010/01/04",
      salary="$125,250"
   },
   new Sample {  
      name="Zorita Serrano",
      last="Software Engineer",
      title="San Francisco",
      location="4389",
      date="2012/06/01",
      salary="$115,000"
   },
   new Sample {  
      name="Jennifer Acosta",
      last="Junior Javascript Developer",
      title="Edinburgh",
      location="3431",
      date="2013/02/01",
      salary="$75,650"
   },
   new Sample {  
      name="Cara Stevens",
      last="Sales Assistant",
      title="New York",
      location="3990",
      date="2011/12/06",
      salary="$145,600"
   },
   new Sample {  
      name="Hermione Butler",
      last="Regional Director",
      title="London",
      location="1016",
      date="2011/03/21",
      salary="$356,250"
   },
   new Sample {  
      name="Lael Greer",
      last="Systems Administrator",
      title="London",
      location="6733",
      date="2009/02/27",
      salary="$103,500"
   },
   new Sample {  
      name="Jonas Alexander",
      last="Developer",
      title="San Francisco",
      location="8196",
      date="2010/07/14",
      salary="$86,500"
   },
   new Sample {  
      name="Shad Decker",
      last="Regional Director",
      title="Edinburgh",
      location="6373",
      date="2008/11/13",
      salary="$183,000"
   },
   new Sample {  
      name="Michael Bruce",
      last="Javascript Developer",
      title="Singapore",
      location="5384",
      date="2011/06/27",
      salary="$183,000"
   },
   new Sample {  
      name="Donna Snider",
      last="Customer Support",
      title="New York",
      location="4226",
      date="2011/01/25",
      salary="$112,000"
   }

              
        };
            

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpPost]
        public JsonResult GetData(JqDataTable<Sample> model)
        {
            // get data source 
            model.Init(SampleDataBaseData);

            // sort results
            var toClient = model.Sort()
                                .Search()
                                .Paginate()
                                .Response();
            
            return new JsonResult(toClient);
        }
       }
    }