using Serilog.Context;

namespace VerticalSliceArchitecture.Api.Middlewares;

public sealed class AddCorrelationIdMiddleware(RequestDelegate next)
{
    private const string CorrelationIdKey = "X-Correlation-ID";
    public Task InvokeAsync(HttpContext httpContext)
    {
        if (!httpContext.Request.Headers.TryGetValue(CorrelationIdKey, out var correlationId))
        {
            if (string.IsNullOrWhiteSpace(correlationId))
            {
                correlationId = Guid.NewGuid().ToString();

                httpContext.Response.OnStarting(() =>
                {
                    if (!httpContext.Response.Headers.ContainsKey(CorrelationIdKey))
                    {
#pragma warning disable ASP0019
                        httpContext.Response.Headers.Add(CorrelationIdKey, correlationId);
#pragma warning restore ASP0019
                    }

                    return Task.CompletedTask;
                });

            }

            using (LogContext.PushProperty("CorrelationId", correlationId))
            {
                return next(httpContext);
            }
        }
        return next(httpContext);
    }
}
