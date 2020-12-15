using AutoMapper;
using MetaWeatherApi.Common.Models;
using MetaWeatherApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetaWeatherApi.Profiles
{
    public class LocationForecastProfile : Profile
    {
        public LocationForecastProfile()
        {
            CreateMap<LocationForecastModel, LocationForecast>();
            CreateMap<LocationModel, Location>();
            CreateMap<ConsolidatedWeatherModel, ConsolidatedWeather>();
        }
    }
}
