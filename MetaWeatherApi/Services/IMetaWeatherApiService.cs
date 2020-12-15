using MetaWeatherApi.Models;
using MetaWeatherApi.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetaWeatherApi.Services
{
    public interface IMetaWeatherApiService
    {
        Task<LocationForecastModel> GetLocationForecast(int id);
        Task<IEnumerable<Location>> SearchForLocation(string query);
    }
}
