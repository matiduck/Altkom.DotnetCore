using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Altkom.DotnetCore.Api.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Altkom.DotnetCore.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Use(async (context, next) =>
           {
               System.Diagnostics.Trace.WriteLine($"{context.Request.Path}");

               //wzorzec odpowiedzialnoœci 
               await next();
               System.Diagnostics.Trace.WriteLine($"{context.Response.StatusCode}");
           });
           
            app.UseLoggerMiddleware();

            app.Use(async (context, next) =>
            {
                if (context.Request.Headers.ContainsKey("Authorize"))
                {
                    await next();
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                }
            });
            app.Run(context => context.Response.WriteAsync("Hej"));
        }
    }
}
