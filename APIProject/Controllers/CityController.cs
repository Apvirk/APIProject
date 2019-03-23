using APIProject.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace APIProject.Controllers
{
    public class CityController : Controller
    {
        // GET: City
        public ActionResult search(String cityname)
        {
            var city = new CityModel();
            try
            {
                Debug.WriteLine("http://api.openweathermap.org/data/2.5/weather?q=" + cityname + "&appid=8e94e5994470528d16441624dba1e2c4");
                WebRequest request = WebRequest.Create("http://api.openweathermap.org/data/2.5/weather?q=" + cityname + "&appid=8e94e5994470528d16441624dba1e2c4");

                WebResponse response = request.GetResponse();

                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.  

                
                string citydata = reader.ReadToEnd();
                var dataobject = JObject.Parse(citydata);
                Debug.WriteLine(dataobject.ToString());
                
                city.Country = dataobject["sys"]["country"].ToString();
                city.Lat = dataobject["coord"]["lat"].ToString();
                city.Lng = dataobject["coord"]["lon"].ToString();
                city.Humidity = dataobject["main"]["humidity"].ToString();
                city.Description = dataobject["weather"][0]["description"].ToString();
               
                Debug.WriteLine("City h "+city.Humidity+ "  " + dataobject["main"]["humidity"].ToString());
            }
            catch(Exception e) {
                Debug.WriteLine(e.ToString());
               ViewBag.Title = "Error";
            }

            return View(city);
        }
    }
}