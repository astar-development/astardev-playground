using AStarDev.ControlDb.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AStarDev.Playing.Startup;

public static class DataServices
{
    public static IServiceCollection AddDataServices(this IServiceCollection services)
    {
        services.AddDbContextFactory<ControlDbContext>(options =>
        {
            options.UseSqlite("Data Source=control.db"); // TODO -> Move connection string to configuration / correct location
        });

        return services;
    }
}
