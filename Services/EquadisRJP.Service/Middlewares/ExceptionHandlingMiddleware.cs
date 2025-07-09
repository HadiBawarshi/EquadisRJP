using EquadisRJP.Domain.DomainExceptions;
using EquadisRJP.Domain.Errors;
using EquadisRJP.Domain.Primitives;
using System.Net;
using System.Net.Mime;

namespace EquadisRJP.Service.Middlewares
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

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                var error = MapToDomainError(exception);

                _logger.LogError(exception, "\nException caught in middleware. Mapped to ErrorCode= {Code}, Description= {Desc} \n ",
                error.Code, error.Description);

                var statusCode = MapToStatusCode(error.Type);

                context.Response.StatusCode = (int)statusCode;

                context.Response.ContentType = MediaTypeNames.Application.Json;

                await context.Response.WriteAsJsonAsync(Result.Failure(error));
            }
        }



        private Error MapToDomainError(Exception exception)
        {
            return exception switch
            {
                PartnershipExpiredException ex =>
                    Error.Conflict(DomainErrors.Partnership.PartnershipExpired),

                _ =>
                    Error.Problem(DomainErrors.ServerError.InternalServerError)
            };
        }


        private HttpStatusCode MapToStatusCode(ErrorType errorType) => errorType switch
        {
            ErrorType.Validation => HttpStatusCode.BadRequest,
            ErrorType.NotFound => HttpStatusCode.NotFound,
            ErrorType.Conflict => HttpStatusCode.Conflict,
            ErrorType.Problem => HttpStatusCode.InternalServerError,
            ErrorType.Failure => HttpStatusCode.BadRequest,
            _ => HttpStatusCode.InternalServerError
        };


    }
}
