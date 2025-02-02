﻿using System.Net;
using System.Text.Json;


namespace OnlineLearning.Presentation.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred.");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected
            var result = string.Empty;

            if (exception is ArgumentNullException)
            {
                code = HttpStatusCode.BadRequest;
                result = Newtonsoft.Json.JsonConvert.SerializeObject(new { error = "Bad request: " + exception.Message });
            }
            else if (exception is UnauthorizedAccessException)
            {
                code = HttpStatusCode.Unauthorized;
                result = Newtonsoft.Json.JsonConvert.SerializeObject(new { error = "Unauthorized: " + exception.Message });
            }
            else
            {
                result = Newtonsoft.Json.JsonConvert.SerializeObject(new { error = "An unexpected error occurred: " + exception.Message });
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
