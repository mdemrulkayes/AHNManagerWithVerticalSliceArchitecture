using Microsoft.EntityFrameworkCore;
using VerticalSliceArchitecture.Api.Database;

namespace VerticalSliceArchitecture.Api.Extensions;

public static class DatabaseDependencyInjection
{
    public static IServiceCollection RegisterDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("DbCs"));
        });
        return services;
    }

    public static IApplicationBuilder MigrateDatabase(this IApplicationBuilder app)
    {
        var scopedService = app.ApplicationServices.CreateScope();
        var dbContext = scopedService.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        if (dbContext.Database.IsSqlServer())
        {
            dbContext.Database.Migrate();
        }

        return app;
    }
}
