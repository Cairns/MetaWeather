using AutoMapper;
using MetaWeatherApi.Common;
using MetaWeatherApi.Common.Models;
using MetaWeatherApi.Endpoints;
using MetaWeatherApi.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetaWeatherApi.Services
{
    public class MetaWeatherApiService : IMetaWeatherApiService
    {
        private readonly IApiClient apiClient;
        private readonly IMapper mapper;
        private readonly ILogger logger;

        public MetaWeatherApiService(IApiClient apiClient, IMapper mapper, ILogger<MetaWeatherApiService> logger)
        {
            this.apiClient = apiClient;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<LocationForecastModel> GetLocationForecast(int id)
        {
            var url = $"{LocationEndpoint.Endpoint}{id}";

            var locationForecast = await this.apiClient.GetAsync<LocationForecastModel>(url);

            return locationForecast;
        }

        public async Task<IEnumerable<Location>> SearchForLocation(string query)
        {
            var url = $"{LocationSearchEndpoint.Endpoint}?query={query}";

            var locationModels = await this.apiClient.GetAsync<List<LocationModel>>(url);

            var locations = mapper.Map<IEnumerable<LocationModel>, IEnumerable<Location>>(locationModels);

            return locations?.OrderBy(l => l.Title);
        }
    }
}
