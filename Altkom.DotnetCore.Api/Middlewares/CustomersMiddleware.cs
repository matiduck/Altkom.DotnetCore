using Altkom.Dotnecore.IServices;
using Altkom.DotnetCore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text.Json;
using System.Threading.Tasks;

namespace Altkom.DotnetCore.Api.Middlewares
{
    public class CustomersMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ICustomerService customerService;
        public CustomersMiddleware(RequestDelegate next, ICustomerService customerService)
        {
            this.next = next;
            this.customerService = customerService;
        }

        public async Task Invoke(HttpContext context)
        {
            string content = JsonSerializer.Serialize<IEnumerable<Customer>>(customerService.Get());
            context.Response.StatusCode = StatusCodes.Status200OK;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(content);
        }

    }

    public static class CustomersMiddlewareExtensions
    {
        public static IEndpointConventionBuilder MapCustomers(this IEndpointRouteBuilder endpoints, string pattern)
        {
            return endpoints.MapGet(pattern, endpoints.CreateApplicationBuilder()
                .UseMiddleware<CustomersMiddleware>()
                .Build());
        }
    }
}
