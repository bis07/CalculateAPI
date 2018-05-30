using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace APICalculator.Infrastructure
{
    public class ExceptionFilterAttribute : Microsoft.AspNetCore.Mvc.Filters.ExceptionFilterAttribute
    {
        private static ILogger _logger;

        public ExceptionFilterAttribute(ILogger<ExceptionFilterAttribute> logger)
        {
            _logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            var ex = context.Exception;
            _logger.LogError(ex.ToString());

          
            if (ex.GetType() == typeof(DivideByZeroException))
            {
                var json = new JsonErrorResponse
                {
                    Messages = new[] { ex.Message }
                };

                context.Result = new BadRequestObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            if (ex.GetType() == typeof(Exception))
            {
                var json = new JsonErrorResponse
                {
                    Messages = new[] { ex.Message }
                };

                context.Result = new BadRequestObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                context.ExceptionHandled = false;
            }
        }

        private class JsonErrorResponse
        {
            public string[] Messages { get; set; }
        }
    }
}
