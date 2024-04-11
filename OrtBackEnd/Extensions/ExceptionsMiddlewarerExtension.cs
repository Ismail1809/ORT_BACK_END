using Microsoft.AspNetCore.Diagnostics;
using OrtBackEnd.Contracts;
using OrtBackEnd.Middleware;
using OrtBackEnd.Models;
using System.Net;

namespace OrtBackEnd.Extensions
{
    public static class ExceptionsMiddlewarerExtension
    {
        //public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILoggerManager logger)
        //{
        //    app.UseExceptionHandler(appError =>
        //    {
        //        appError.Run(async context =>
        //        {
        //            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        //            context.Response.ContentType = "application/json";
        //            var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
        //            if (contextFeature != null)
        //            {
        //                logger.LogError($"Something went wrong: {contextFeature.Error}");
        //                await context.Response.WriteAsync(new ErrorDetails()
        //                {
        //                    StatusCode = context.Response.StatusCode,
        //                    Message = "Internal Server Error."
        //                }.ToString());
        //            }
        //        });
        //    });
        //}

        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleWare>();
        }
    }
}
