using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MetaWeatherApi.Common
{
    public class ApiClient : IApiClient
    {
        private readonly IOptions<ApiConfiguration> apiConfiguration;
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ILogger<ApiClient> logger;

        protected JsonSerializerSettings DefaultSerialiserSettings => new JsonSerializerSettings();
        //Strategy pattern, allow consumers of the ApiClient to override the json serializersettings if required, otherwise default settings will be used
        public JsonSerializerSettings SerializerSettings { get; set; }

        public ApiClient(IOptions<ApiConfiguration> apiConfiguration, IHttpClientFactory httpClientFactory, ILogger<ApiClient> logger)
        {
            this.apiConfiguration = apiConfiguration;
            this.httpClientFactory = httpClientFactory;
            this.logger = logger;
        }

        public async Task<TOutput> GetAsync<TOutput>(string url) where TOutput : new()
        {
            return await this.GetAsync<TOutput>(url, this.SerializerSettings != null ? this.SerializerSettings : DefaultSerialiserSettings);
        }

        public async Task<TOutput> GetAsync<TOutput>(string uri, string request) where TOutput : new()
        {
            return await this.GetAsync<TOutput>(uri, request, this.SerializerSettings != null ? this.SerializerSettings : DefaultSerialiserSettings);
        }

        public async Task<TOutput> GetAsync<TOutput>(string url, JsonSerializerSettings serializerSettings) where TOutput : new()
        {
            try
            {
                var httpResponse = await GetAsync(url);
                var response = ProcessResponse<TOutput>(httpResponse, serializerSettings);

                return await response;
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, nameof(GetAsync), nameof(ApiClient));
            }

            return default(TOutput) != null ? default : new TOutput();
        }

        public async Task<TOutput> GetAsync<TOutput>(string uri, string request, JsonSerializerSettings serializerSettings) where TOutput : new()
        {
            try
            {
                var httpResponse = await GetAsync(uri, request);
                var response = ProcessResponse<TOutput>(httpResponse, serializerSettings);

                return await response;
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, nameof(GetAsync), nameof(ApiClient));
            }

            return default(TOutput) != null ? default : new TOutput();
        }

        private async Task<HttpResponseMessage> GetAsync(string uri, string request)
        {
            var url = $"{uri}/{request}";
            try
            {
                return await GetAsync(url);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, nameof(GetAsync), nameof(ApiClient));
            }

            return null;
        }

        private async Task<HttpResponseMessage> GetAsync(string url)
        {
            var client = CreateClient();
            try
            {
                return await client.GetAsync(url);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, nameof(GetAsync), nameof(ApiClient));
            }

            return null;
        }


        private async Task<TOutput> ProcessResponse<TOutput>(HttpResponseMessage httpResponse, JsonSerializerSettings serializerSettings) where TOutput : new()
        {
            if (httpResponse.IsSuccessStatusCode)
            {
                return await DeserializeResponseData<TOutput>(httpResponse, serializerSettings);
            }

            return default(TOutput) != null ? default : new TOutput();
        }

        private async Task<TOutput> DeserializeResponseData<TOutput>(HttpResponseMessage httpResponse, JsonSerializerSettings serializerSettings) where TOutput : new()
        {
            var responseString = await ResponseAsString(httpResponse);
            try
            {
                if (responseString != null)
                {
                    return JsonConvert.DeserializeObject<TOutput>(responseString, serializerSettings);
                }

                return default(TOutput) != null ? default : new TOutput();
            }
            catch (System.Exception ex)
            {
                var errorMessage = "Deserialize Error" + Environment.NewLine + httpResponse.StatusCode.ToString() + Environment.NewLine + responseString;
                logger.LogError(errorMessage);
                throw new Exception(errorMessage, ex);
            }
        }

        private async Task<string> ResponseAsString(HttpResponseMessage httpResponse)
        {
            return await httpResponse.Content?.ReadAsStringAsync();
        }

        private HttpClient CreateClient()
        {
            //var handler = new HttpClientHandler
            //{
            //    SslProtocols = System.Security.Authentication.SslProtocols.Tls13 | System.Security.Authentication.SslProtocols.Tls12 | System.Security.Authentication.SslProtocols.Tls11 | System.Security.Authentication.SslProtocols.Tls,
            //    ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            //};

            //HttpClient client = new HttpClient(handler);

            HttpClient client = this.httpClientFactory.CreateClient();
            
            client.DefaultRequestHeaders.Clear();
            client.BaseAddress = new Uri(apiConfiguration.Value.BaseApiUrl);
            return client;
        }
    }
}
