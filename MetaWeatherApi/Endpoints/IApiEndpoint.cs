using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetaWeatherApi.Endpoints
{
    public interface IApiEndpoint
    {
        string Path { get; }
    }
}
