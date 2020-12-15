using System;
using System.Collections.Generic;
using System.Text;

namespace MetaWeatherApi.Common
{
    public class ApiConfiguration : IApiConfiguration
    {
        public string BaseApiUrl { get; set; }
    }
}
