using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AMS.Host
{
    public class GlobalExceptionHandlerExtensions
    {

        private readonly RequestDelegate _next;

        public GlobalExceptionHandlerExtensions(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var Response = new ErrorResponse()
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                ErrorMessage = ex.Message,
            };
            await context.Response.WriteAsJsonAsync(Response);
        }
    }
}