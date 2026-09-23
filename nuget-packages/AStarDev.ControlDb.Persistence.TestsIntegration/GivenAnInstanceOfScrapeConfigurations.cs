using AStarDev.ControlDb.Persistence.TestsIntegration.TestFactories;
using AStarDev.Utilities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace AStarDev.ControlDb.Persistence.TestsIntegration;

public sealed class GivenAnInstanceOfScrapeConfigurations : IDisposable
{
    private readonly SqliteConnection connection;
    private readonly DbContextOptions<ControlDbContext> options;

    public GivenAnInstanceOfScrapeConfigurations()
    {
        connection = new SqliteConnection("Data Source=:memory:");
        connection.Open();
        options = new DbContextOptionsBuilder<ControlDbContext>().UseSqlite(connection).Options;

        using var context = new ControlDbContext(options);
        context.Database.EnsureCreated();
    }

    [Fact]
    public void when_accessing_the_scrapeConfigurations_dbSet_it_should_not_be_null()
    {
        using var context = new ControlDbContext(options);
        ScrapeConfiguration entity = ScrapeConfigurationFactory.Create();
        context.ScrapeConfigurations.Add(entity);
        context.SaveChanges();

        using var newContext = new ControlDbContext(options);
        var result = newContext.ScrapeConfigurations.First();

        result.Id.ShouldBeAssignableTo<ScrapeConfigurationId>();
        result.HashedPassword.ShouldBe("Mock Hashed Password");
        result.HotWallpapers.ShouldBe("Mock Hot Wallpapers");
        result.Username.ShouldBe("Mock Username");
        result.TopWallpapers.ShouldBe("Mock Top Wallpapers");
        result.SearchCategoryPrefix.ShouldBe("Mock Search Category Prefix");
        result.SearchCategorySuffix.ShouldBe("Mock Search Category Suffix");
        result.SiteName.ShouldBe("Mock Site Name");
        result.SiteUrl.ShouldBe("https://example.com");
    }

    public void Dispose() => connection.Dispose();
}
