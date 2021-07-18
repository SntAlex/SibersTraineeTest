using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Sibers.Services.Exceptions;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Sibers.WebApi.Middlewares
{
    /// <summary>
    /// Middleware для отлавливания ошибок
    /// </summary>
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;

            switch (ex)
            {
                case NotFoundException _:
                    code = HttpStatusCode.NotFound;
                    break;
                case BadRequestException _:
                    code = HttpStatusCode.BadRequest;
                    break;
            }

            var result = JsonConvert.SerializeObject(new { error = ex.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
