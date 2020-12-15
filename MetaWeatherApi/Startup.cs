using AutoMapper;
using MetaWeatherApi.Common;
using MetaWeatherApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace MetaWeatherApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            //ServicePointManager.ServerCertificateValidationCallback =
            //    delegate (object sender, X509Certificate certificate, X509Chain
            //    chain, SslPolicyErrors sslPolicyErrors)
            //    {
            //        return true;
            //    };

            services.AddControllers();
            services.AddHttpClient();
            services.AddAutoMapper(typeof(Startup));
            services.Configure<ApiConfiguration>(Configuration.GetSection(nameof(ApiConfiguration)));
            services.AddTransient<IApiClient, ApiClient>();
            services.AddTransient<IMetaWeatherApiService, MetaWeatherApiService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
