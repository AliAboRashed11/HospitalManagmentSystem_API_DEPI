using Microsoft.AspNetCore.Http;

namespace HospitalManagmentSystem.API.Middleware
{
    public class FirstMiddelware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<FirstMiddelware> _logger;

        public FirstMiddelware(RequestDelegate next,ILogger<FirstMiddelware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogWarning("FistMiddleWare Starting");
            
            _next(context);

            _logger.LogWarning("FistMiddleWare Ended");
        }
    }
}
