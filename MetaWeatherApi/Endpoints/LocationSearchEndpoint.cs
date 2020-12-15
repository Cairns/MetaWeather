using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetaWeatherApi.Endpoints
{
    public class LocationSearchEndpoint : IApiEndpoint
    {
        public string Path => "location/search";

        private static readonly LocationSearchEndpoint instance = new LocationSearchEndpoint();

        private LocationSearchEndpoint()
        { }

        public static string Endpoint => instance.Path;
    }
}
