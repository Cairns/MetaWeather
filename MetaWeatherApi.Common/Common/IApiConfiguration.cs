using System;
using System.Collections.Generic;
using System.Text;

namespace MetaWeatherApi.Common
{
    public interface IApiConfiguration
    {
        string BaseApiUrl { get; }
    }
}
