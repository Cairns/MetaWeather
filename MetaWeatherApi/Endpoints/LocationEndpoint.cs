using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetaWeatherApi.Endpoints
{
    public class LocationEndpoint : IApiEndpoint
    {
        public string Path => "location/";

        private static readonly LocationEndpoint instance = new LocationEndpoint();

        private LocationEndpoint()
        { }

        public static string Endpoint => instance.Path;
    }
}
