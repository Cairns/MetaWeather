using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetaWeatherApi.Models
{
    public class LocationModel
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("location_type")]
        public string LocationType { get; set; }

        [JsonProperty("woeid")]
        public int WhereOnEarthID { get; set; }

        [JsonProperty("latt_long")]
        public string Coordinates { get; set; }
    }
}
