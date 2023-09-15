namespace QuotesApi.Middleware
{
    public class DenemeMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly ILogger _logger;
        public DenemeMiddleware(RequestDelegate requestDelegate, ILogger<DenemeMiddleware> logger)
        {
            _requestDelegate = requestDelegate;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                try
                {
                    int b = 0;
                    int a = 4 / b;
                }
                catch (Exception)
                {

                    throw;
                }

            }
            catch (Exception ex)
            {
                _logger.LogInformation("ex hata aldı");

            }

        }
    }
}
