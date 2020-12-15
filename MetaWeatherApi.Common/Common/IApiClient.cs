using Newtonsoft.Json;
using System.Threading.Tasks;

namespace MetaWeatherApi.Common
{
    public interface IApiClient
    {
        public JsonSerializerSettings SerializerSettings { get; set; }

        Task<TOutput> GetAsync<TOutput>(string url) where TOutput : new();
        Task<TOutput> GetAsync<TOutput>(string url, JsonSerializerSettings serializerSettings) where TOutput : new();
        Task<TOutput> GetAsync<TOutput>(string uri, string request) where TOutput : new();
        Task<TOutput> GetAsync<TOutput>(string uri, string request, JsonSerializerSettings serializerSettings) where TOutput : new();
    }
}
