using AStarDev.ControlDb.Persistence.TestsIntegration.TestFactories;
using AStarDev.Utilities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Domain = AStarDev.ControlDb;

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

    [Fact]
    public void when_saving_a_converted_domain_model_then_it_is_persisted()
    {
        var domainModel = new Domain.ScrapeConfiguration(new Domain.ScrapeConfigurationId(Guid.CreateVersion7()), "Domain Site Name", "https://domain.example.com", "Domain Prefix", "Domain Suffix", "Domain Top", "Domain Hot", "Domain Username", "Domain Hashed Password");

        using (var context = new ControlDbContext(options))
        {
            context.ScrapeConfigurations.Add(domainModel.ToEntity());
            context.SaveChanges();
        }

        using var newContext = new ControlDbContext(options);
        var result = newContext.ScrapeConfigurations.Single();

        result.Id.Value.ShouldBe(domainModel.Id.Value);
        result.SiteName.ShouldBe("Domain Site Name");
        result.HotWallpapers.ShouldBe("Domain Hot");
        result.Username.ShouldBe("Domain Username");
        result.HashedPassword.ShouldBe("Domain Hashed Password");
    }

    [Fact]
    public void when_updating_a_tracked_entity_from_a_domain_model_then_the_changes_are_persisted()
    {
        ScrapeConfiguration entity = ScrapeConfigurationFactory.Create();
        entity.Id = ScrapeConfigurationId.Create;
        using (var context = new ControlDbContext(options))
        {
            context.ScrapeConfigurations.Add(entity);
            context.SaveChanges();
        }

        var domainModel = new Domain.ScrapeConfiguration(new Domain.ScrapeConfigurationId(entity.Id.Value), "Updated Site Name", "https://updated.example.com", "Updated Prefix", "Updated Suffix", "Updated Top", "Updated Hot", "Updated Username", "Updated Hashed Password");
        using (var context = new ControlDbContext(options))
        {
            context.ScrapeConfigurations.Single(sc => sc.Id == entity.Id).UpdateFrom(domainModel);
            context.SaveChanges();
        }

        using var newContext = new ControlDbContext(options);
        var result = newContext.ScrapeConfigurations.Single();

        result.SiteName.ShouldBe("Updated Site Name");
        result.SiteUrl.ShouldBe("https://updated.example.com");
        result.TopWallpapers.ShouldBe("Updated Top");
        result.Username.ShouldBe("Updated Username");
        result.HashedPassword.ShouldBe("Updated Hashed Password");
    }

    [Fact]
    public void when_loading_a_persisted_entity_then_it_converts_to_a_domain_model()
    {
        ScrapeConfiguration entity = ScrapeConfigurationFactory.Create();
        entity.Id = ScrapeConfigurationId.Create;
        using (var context = new ControlDbContext(options))
        {
            context.ScrapeConfigurations.Add(entity);
            context.SaveChanges();
        }

        using var newContext = new ControlDbContext(options);
        Domain.ScrapeConfiguration result = newContext.ScrapeConfigurations.Single().ToDomain();

        result.Id.Value.ShouldBe(entity.Id.Value);
        result.SiteName.ShouldBe("Mock Site Name");
        result.HotWallpapers.ShouldBe("Mock Hot Wallpapers");
        result.Username.ShouldBe("Mock Username");
        result.HashedPassword.ShouldBe("Mock Hashed Password");
    }

    public void Dispose() => connection.Dispose();
}
