using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Altkom.DotnetCore.Api.Middlewares
{

    public static class LoggerMiddlewareExtension
    {
        public static IApplicationBuilder UseLoggerMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<LoggerMiddleware>();
        }
    }

    public class LoggerMiddleware
    {
        private readonly RequestDelegate next;

        public LoggerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            System.Diagnostics.Trace.WriteLine($"{context.Request.Path}");

            //wzorzec odpowiedzialności 
            await next(context);
            System.Diagnostics.Trace.WriteLine($"{context.Response.StatusCode}");
        }
    }
}
