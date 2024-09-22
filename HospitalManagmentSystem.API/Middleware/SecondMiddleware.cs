namespace HospitalManagmentSystem.API.Middleware
{
    public class SecondMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<SecondMiddleware> _logger;

        public SecondMiddleware(RequestDelegate next,ILogger<SecondMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            _logger.LogWarning("SecondMiddleware Starting");
            
            _next(httpContext);
            
            _logger.LogWarning("SecondMiddleware Ended");

        }
    }
}
