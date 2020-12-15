using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetaWeatherApi.Common.Models
{
    public class LocationForecast : Location
    {
        public ICollection<ConsolidatedWeather> ConsolidatedWeathers { get; set; }

        public DateTimeOffset Time { get; set; }

        public DateTimeOffset SunRise { get; set; }

        public DateTimeOffset SunSet { get; set; }

        public string TimezoneName { get; set; }

        public Location Parent { get; set; }

        public string Timezone { get; set; }
    }
}
