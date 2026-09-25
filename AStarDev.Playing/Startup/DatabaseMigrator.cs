using AStarDev.ControlDb.Persistence;
using AStarDev.LoggingExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AStarDev.Playing.Startup;

public static class DatabaseMigrator
{
    public static async Task MigrateAsync(IDbContextFactory<ControlDbContext> contextFactory, ILogger logger)
    {
        try
        {
            await using var context = contextFactory.CreateDbContext();
            await context.Database.MigrateAsync();
            LogMessage.Information(logger, "Database migration completed successfully.");
        }
        catch (Exception ex)
        {
            LogMessage.Error(logger, "An error occurred while migrating the database.", ex);
            throw;
        }
    }
}