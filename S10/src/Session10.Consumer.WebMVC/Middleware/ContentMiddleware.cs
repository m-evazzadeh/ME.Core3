using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Session10.Consumer.WebMVC.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ContentMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration configuration;

        public ContentMiddleware(RequestDelegate next,IConfiguration configuration)
        {
            _next = next;
            this.configuration = configuration;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            //var v1 = configuration.GetSection("ConnectionStrings:DefaultConnection");
            //var v2 = configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            
            await _next(httpContext);

            await httpContext.Response.WriteAsync("helloooooooooooooooooo", encoding: Encoding.UTF8);
            return;
        }
    }


}
