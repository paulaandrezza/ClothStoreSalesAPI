using Microsoft.AspNetCore.Mvc.Filters;

namespace ClothStoreSalesAPI.Filters
{
    public class LogActionFilter : IActionFilter
    {
        private readonly ILogger<LogActionFilter> _logger;

        public LogActionFilter(ILogger<LogActionFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation($"Action started: {context.ActionDescriptor.DisplayName} - {DateTime.Now}");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation($"Action completed: {context.ActionDescriptor.DisplayName} - {DateTime.Now}");
        }
    }
}
