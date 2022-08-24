using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace TestApp.Middlewares
{
    public class HelloWorldMiddleware
    {
        private readonly RequestDelegate _next;

        public HelloWorldMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        
        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("HelloWorld");
            await _next(context);
        }
    }

    public static class AuthorizationAppBuilderExtensions
    {
        public static IApplicationBuilder UseHelloWorld(this IApplicationBuilder app)
        {

            return app.UseMiddleware<HelloWorldMiddleware>();
        }
    }
}