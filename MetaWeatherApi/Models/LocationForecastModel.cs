using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetaWeatherApi.Models
{
    public class LocationForecastModel : LocationModel
    {
        [JsonProperty("consolidated_weather")]
        public ICollection<ConsolidatedWeatherModel> ConsolidatedWeathers { get; set; }

        [JsonProperty("time")]
        public DateTimeOffset Time { get; set; }

        [JsonProperty("sun_rise")]
        public DateTimeOffset SunRise { get; set; }

        [JsonProperty("sun_set")]
        public DateTimeOffset SunSet { get; set; }

        [JsonProperty("timezone_name")]
        public string TimezoneName { get; set; }

        [JsonProperty("parent")]
        public LocationModel Parent { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }
    }
}
