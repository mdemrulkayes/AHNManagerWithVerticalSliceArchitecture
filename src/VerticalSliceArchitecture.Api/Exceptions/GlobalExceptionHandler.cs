using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace VerticalSliceArchitecture.Api.Exceptions;

public sealed class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        logger.LogError(exception, "Internal server error occurred: {message}", exception.Message);

        var problemDetails = new ProblemDetails
        {
            Title = "Internal Server Error",
            Detail = "An error has been occurred. Please contact with the support.",
            Status = StatusCodes.Status500InternalServerError
        };

        httpContext.Response.StatusCode = problemDetails.Status.Value;

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}
