using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ITS.Infrastructure.Enums;
using ITS.Infrastructure.Exceptions;
using ITS.Infrastructure.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace ITS.WebApi.Helper.Implement
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;

        public ErrorHandlerMiddleware(RequestDelegate next, IWebHostEnvironment env)
        {
            _next = next;
            _env = env;
        }

        public async Task Invoke(HttpContext context)
        {
            HttpStatusCode httpStatusCode;
            var message = OperationResult.Fail.GetDescription();
            string errorMessage = null;
            object additionalData = null;

            try
            {
                await _next(context);
                if (context.Response.StatusCode == 401)
                {
                    httpStatusCode = HttpStatusCode.Unauthorized;
                    errorMessage = ApiResponseMessage.Unauthorized.GetDescription();
                    await WriteToResponseAsync();

                }
            }
            catch (AppException exception)
            {
                httpStatusCode = exception.StatusCode;
                additionalData = exception.AdditionalData;
                await WriteToResponseAsync();
            }
            catch (Exception exception)
            {
                httpStatusCode = HttpStatusCode.InternalServerError;
                if (_env.IsDevelopment())
                {
                    var dic = new Dictionary<string, string>()
                    {
                        ["Exception"] = exception.Message,
                        ["StackTrace"] = exception.StackTrace
                    };
                    errorMessage = JsonConvert.SerializeObject(dic);
                }
                else
                {
                    errorMessage = exception.Message;
                }

                await WriteToResponseAsync();
            }


            async Task WriteToResponseAsync()
            {
                var result = new ApiResult(httpStatusCode, message, new Error(errorMessage, additionalData));
                var json = JsonConvert.SerializeObject(result);
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(json);
            }
        }
    }
}