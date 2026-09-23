using AStarDev.ControlDb.Persistence.TestsIntegration.TestFactories;
using AStarDev.Utilities;

namespace AStarDev.ControlDb.Persistence.TestsIntegration;

public class GivenAnInstanceOfScrapeConfigurations
{
    public GivenAnInstanceOfScrapeConfigurations()
    {
        var context = new ControlDbContext();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
    }

    [Fact]
    public void when_accessing_the_scrapeConfigurations_dbSet_it_should_not_be_null()
    {
        var context = new ControlDbContext();
        ScrapeConfiguration entity = ScrapeConfigurationFactory.Create();
        context.ScrapeConfigurations.Add(entity);
        context.SaveChanges();

        var newContext = new ControlDbContext();

        newContext.ScrapeConfigurations.First().ToJson().ShouldMatchApproved();
    }
}
