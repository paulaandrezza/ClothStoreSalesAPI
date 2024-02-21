using ClothStoreSalesAPI.ResponseModels;
using Data.CustomExceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ClothStoreSalesAPI.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<ExceptionFilter> _logger;

        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ClothStoreSalesApiException clothStoreSalesApiException)
            {
                var errorResult = new ErrorResponse
                {
                    ErrorMessage = clothStoreSalesApiException.Message,
                    StatusCode = clothStoreSalesApiException.StatusCode
                };

                context.Result = new JsonResult(errorResult)
                {
                    StatusCode = errorResult.StatusCode
                };
            }
            else
            {
                var errorResult = new ErrorResponse
                {
                    ErrorMessage = "Internal Server Error",
                    StatusCode = StatusCodes.Status500InternalServerError
                };
                context.Result = new JsonResult(errorResult)
                {
                    StatusCode = errorResult.StatusCode
                };
            }

            _logger.LogError(context.Exception, "Exceção capturada pelo exception filter");
        }
    }
}
