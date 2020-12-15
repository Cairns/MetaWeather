using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetaWeatherApi.Common.Models
{
    public class Location
    {
        public string Title { get; set; }

        public string LocationType { get; set; }

        public int WhereOnEarthID { get; set; }

        public string Coordinates { get; set; }
    }
}

