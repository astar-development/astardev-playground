using AStarDev.Playing.Home;
using Microsoft.Extensions.DependencyInjection;

namespace AStarDev.Playing.Startup;

public static class ApplicationServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<MainWindow>();

        return services;
    }
}