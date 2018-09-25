using System;
using System.Collections.Generic;
using System.Net;
using Exterminator.Models;
using Exterminator.Models.Exceptions;
using Exterminator.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace Exterminator.WebApi.ExceptionHandlerExtensions
{
    public static class ExceptionHandlerExtensions
    {
        public static void UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            // TODO: Implement
            app.UseExceptionHandler(error =>
            {
                error.Run(async context =>
                {
                    var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = exceptionHandlerFeature.Error;
                    var statusCode = (int) HttpStatusCode.InternalServerError;

                    

                    if (exception is ResourceNotFoundException)
                    {
                        statusCode = (int) HttpStatusCode.NotFound;
                    }
                    else if (exception is ModelFormatException)
                    {
                        statusCode = (int) HttpStatusCode.PreconditionFailed;
                    }
                    else if (exception is ArgumentOutOfRangeException)
                    {
                        statusCode = (int) HttpStatusCode.BadRequest;
                    }

                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = statusCode;
                    
                    var logService = app.ApplicationServices.GetService(typeof(ILogService)) as ILogService;
                    logService.LogToDatabase(new Models.ExceptionModel
                    {
                        StatusCode = statusCode,
                        ExceptionMessage = exception.Message,
                        StackTrace = exception.StackTrace
                    });
                    
                    await context.Response.WriteAsync(new Models.ExceptionModel
                    {
                        StatusCode = statusCode,
                        ExceptionMessage = exception.Message
                    }.ToString());

                });
            });
        }
    }
}