using MetaWeatherApi.Common.Images;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetaWeatherApi.Common.Models
{
    public class ConsolidatedWeather
    {
        public string WeatherStateName { get; set; }

        public string WeatherStateAbbreviation { get; set; }

        public string WindDirectionCompass { get; set; }

        public DateTimeOffset Created { get; set; }

        public DateTime ApplicableDate { get; set; }

        public decimal MinimumTemperature { get; set; }

        public decimal MaximumTemperature { get; set; }

        public decimal CurrentTemperature { get; set; }

        public decimal WindSpeed { get; set; }

        public decimal WindDirection { get; set; }

        public decimal AirPressue { get; set; }

        public decimal Humidity { get; set; }

        public decimal Visibility { get; set; }

        public decimal Predictability { get; set; }

        //TODO: Create a viewmodel representation for this class to contain this property
        public string ImageSource {  get => String.Format(StaticWeatherImageSource.WeatherImageSource, WeatherStateAbbreviation);}
}
}

