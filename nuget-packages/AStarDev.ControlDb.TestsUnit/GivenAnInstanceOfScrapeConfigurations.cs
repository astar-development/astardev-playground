namespace AStarDev.ControlDb.TestsUnit;

public class GivenAnInstanceOfScrapeConfigurations
{
    [Fact]
    public void when_accessing_the_scrapeConfigurations_dbSet_it_should_not_be_null()
        => new ControlDbContext().ScrapeConfigurations.First().ShouldMatchApproved();
}