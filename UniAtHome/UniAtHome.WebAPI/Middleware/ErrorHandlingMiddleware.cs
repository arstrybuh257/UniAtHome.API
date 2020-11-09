using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace UniAtHome.WebAPI.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, IWebHostEnvironment env)
        {
            try
            {
                await this.next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, env);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception, IWebHostEnvironment env)
        {
            HttpStatusCode status;
            string message;
            var stackTrace = String.Empty;

            //Here you can handle your exceptions like this:

            //var exceptionType = exception.GetType();
            //if (exceptionType == typeof(CryptographicException))
            //{
            //    message = exception.Message;
            //    status = HttpStatusCode.NotFound;
            //}
            //else
            status = HttpStatusCode.InternalServerError;
            message = exception.Message;
            string result;

            if (env.IsEnvironment("Development"))
            {
                stackTrace = exception.StackTrace;
                result = JsonSerializer.Serialize(new { message, status, stackTrace });
            }
            else
            {
                result = JsonSerializer.Serialize(new { message, status });
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;
            return context.Response.WriteAsync(result);
        }
    }
}
