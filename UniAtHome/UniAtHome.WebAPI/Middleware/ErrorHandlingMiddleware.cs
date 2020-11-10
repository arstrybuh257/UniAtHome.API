using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using UniAtHome.BLL.Exceptions;

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
            int status = 
                (exception as CustomHttpException)?.StatusCode ?? (int)HttpStatusCode.InternalServerError;

            string message = exception.Message;
            string result;

            if (env.IsEnvironment("Development"))
            {
                string stackTrace = exception.StackTrace;
                result = JsonSerializer.Serialize(new { message, status, stackTrace });
            }
            else
            {
                result = JsonSerializer.Serialize(new { message, status });
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = status;
            return context.Response.WriteAsync(result);
        }
    }
}
