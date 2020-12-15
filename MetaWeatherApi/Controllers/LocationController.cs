using System.Collections.Generic;
using System.Threading.Tasks;
using MetaWeatherApi.Common.Models;
using MetaWeatherApi.Models;
using MetaWeatherApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MetaWeatherApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly IMetaWeatherApiService metaWeatherApiService;
        private readonly ILogger<LocationController> logger;

        public LocationController(IMetaWeatherApiService metaWeatherApiService, ILogger<LocationController> logger)
        {
            this.metaWeatherApiService = metaWeatherApiService;
            this.logger = logger;
        }

        // Get api/location/41415
        [Route("{id}")]
        [HttpGet]
        public async Task<LocationForecastModel> Get(int id)
        {
            return await this.metaWeatherApiService.GetLocationForecast(id);
        }

        // Get api/location/search/?query=york
        [Route("search/")]
        [HttpGet]
        public async Task<IEnumerable<Location>> Search([FromQuery(Name = "query")]string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return (IEnumerable<Location>)BadRequest();
            }
            return await this.metaWeatherApiService.SearchForLocation(query);
        }
    }
}
