using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIProject.Models
{
    public class CityModel
    {
        public string Description { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public string Country { get; set; }
        public string Humidity { get; set; }

    }
}