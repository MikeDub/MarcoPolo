using System.Collections.Generic;
using KnockKnock.Web.Providers;
using KnockKnock.Web.Services.Fibonacci;
using KnockKnock.Web.Services.ReverseWords;
using KnockKnock.Web.Services.TriangleType;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KnockKnock.Web
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
            // Caching
            services.AddMvc(
                options =>
                {
                    options.CacheProfiles.Add("Default", new CacheProfile { NoStore = true, Location = ResponseCacheLocation.None});
                });

            // Compression
            services.AddResponseCompression(
                options =>
                {
                    options.Providers.Add<BrotliCompressionProvider>();
                    options.Providers.Add<GzipCompressionProvider>();
                }
            );

            // Dependencies
            services.AddSingleton<IFibonacciService, FibonacciService>();
            services.AddSingleton<ITriangleTypeService, TriangleTypeService>();
            services.AddSingleton<IReverseWordService, ReverseWordService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Compression
            app.UseMiddleware<ResponseCompressionQualityMiddleware>(
                    new Dictionary<string, double>
                    {
                        {"br", 1.0},
                        {"gzip", 0.9}
                    })
                .UseResponseCompression();

            // Header Options
            app.Use(
                async (context, next) =>
                {
                    context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                    context.Response.Headers.Add("expires", "-1");
                    context.Response.Headers.Add("expect-ct", "max-age=604800");
                    context.Response.Headers.Add("cache-control", "no-cache");
                    context.Response.Headers.Add("Strict-Transport-Security", "max-age=15552000; includeSubDomains; preload");
                    await next();
                });            

            // Configure Routing
            app.UseMvc(
                routes =>
                {
                    routes.MapRoute("Default", "{controller=Token}");
                }
            );
            
        }
    }
}
