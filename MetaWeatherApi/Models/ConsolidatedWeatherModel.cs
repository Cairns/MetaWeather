using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetaWeatherApi.Models
{
    public class ConsolidatedWeatherModel
    {
        [JsonProperty("weather_state_name")]
        public string WeatherStateName { get; set; }

        [JsonProperty("weather_state_abbr")]
        public string WeatherStateAbbreviation { get; set; }

        [JsonProperty("wind_direction_compass")]
        public string WindDirectionCompass { get; set; }

        [JsonProperty("created")]
        public DateTimeOffset Created { get; set; }

        [JsonProperty("applicable_date")]
        public DateTime ApplicableDate { get; set; }

        [JsonProperty("min_temp")]
        public decimal MinimumTemperature { get; set; }

        [JsonProperty("max_temp")]
        public decimal MaximumTemperature { get; set; }

        [JsonProperty("the_temp")]
        public decimal CurrentTemperature { get; set; }

        [JsonProperty("wind_speed")]
        public decimal WindSpeed { get; set; }

        [JsonProperty("wind_direction")]
        public decimal WindDirection { get; set; }

        [JsonProperty("air_pressure")]
        public decimal AirPressue { get; set; }

        [JsonProperty("humidity")]
        public decimal Humidity { get; set; }

        [JsonProperty("visibility")]
        public decimal Visibility { get; set; }

        [JsonProperty("predictability")]
        public decimal Predictability { get; set; }
    }
}
