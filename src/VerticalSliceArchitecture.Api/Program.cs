using Serilog;
using Serilog.Events;

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(config.GetSection("Serilog"))
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
try
{
    builder.Host.UseSerilog();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();


    var app = builder.Build();

    // Configure the HTTP request pipeline.
    app.UseSerilogRequestLogging(options =>
    {
        // Customize the message template
        options.MessageTemplate = "Handled {RequestPath}";

        // Emit debug-level events instead of the defaults
        options.GetLevel = (httpContext, elapsed, ex) => LogEventLevel.Debug;

        // Attach additional properties to the request completion event
        options.EnrichDiagnosticContext = (diagnosticContext, httpContext) =>
        {
            diagnosticContext.Set("RequestHost", httpContext.Request.Host.Value);
            diagnosticContext.Set("RequestScheme", httpContext.Request.Scheme);
        };
    });
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection();

    app.MapGet("weather", (ILogger<Program> logger) =>
    {
        logger.LogInformation("Weather API called");
        return Results.Ok();
    });

    app.Run();
}
catch (Exception e)
{
    Log.Fatal(e, "Error occurred in the application startup. Message: {@Message}", e.Message);
    throw new ApplicationException("An application exception occurred at the time of start up");
}
finally
{
    Log.CloseAndFlush();
}
