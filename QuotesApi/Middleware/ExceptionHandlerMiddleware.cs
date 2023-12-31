﻿namespace QuotesApi.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
         public ExceptionHandlerMiddleware(RequestDelegate requestDelegate, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);

            }
            catch (Exception ex)
            {
                _logger.LogInformation("ex hata aldı");
                
            }

        }
    }
}
