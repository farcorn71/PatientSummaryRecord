using PatientSummaryRecord.API.Models;
using PatientSummaryRecord.Application.Exceptions;

namespace PatientSummaryRecord.API.Middleware
{
    //This class helps me to structure my exception handling cleaner. could even send as a response following a standard or defined format
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
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
            catch (PatientNotFoundException ex)
            {
                _logger.LogWarning(ex.Message);
                await HandleExceptionAsync(context, ex, StatusCodes.Status404NotFound);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception");
                await HandleExceptionAsync(context, ex, StatusCodes.Status500InternalServerError);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex, int statusCode)
        {
            var response = new ErrorResponse
            {
                StatusCode = statusCode,
                Message = ex.Message,
                Details = ex.InnerException?.Message
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            return context.Response.WriteAsJsonAsync(response);
        }
    }
}
