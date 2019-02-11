using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace SimpleWebApp.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MyHeader
    {
        private readonly RequestDelegate _next;

        public MyHeader(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            httpContext.Response.Headers.Add("myheader", "my value");
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MyHeaderExtensions
    {
        public static IApplicationBuilder UseMyHeader(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyHeader>();
        }
    }
}
