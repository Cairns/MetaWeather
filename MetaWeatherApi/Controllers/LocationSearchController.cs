using System.Collections.Generic;
using System.Threading.Tasks;
using MetaWeatherApi.Models;
using MetaWeatherApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MetaWeatherApi.Controllers
{
    [ApiController]
    [Route("api/location/search/")]
    public class LocationSearchController : ControllerBase
    {
        private readonly IMetaWeatherApiService metaWeatherApiService;
        private readonly ILogger<LocationSearchController> logger;

        public LocationSearchController(IMetaWeatherApiService metaWeatherApiService, ILogger<LocationSearchController> logger)
        {
            this.metaWeatherApiService = metaWeatherApiService;
            this.logger = logger;
        }

        ////[Route("")]
        //[Route("{id}")]
        //[HttpGet]
        //public async Task<LocationForecastModel> Get(int id)
        //{
        //    return await this.metaWeatherApiService.GetLocationForecast(id);
        //}

        //[Route("{query}")]
        //[HttpGet]
        //public async Task<IEnumerable<LocationModel>> SearchLocation(string query)
        //{
        //    return null;
        //}
    }
}
