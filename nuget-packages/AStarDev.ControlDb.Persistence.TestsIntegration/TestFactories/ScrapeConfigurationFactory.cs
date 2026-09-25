namespace AStarDev.ControlDb.Persistence.TestsIntegration.TestFactories;

public static class ScrapeConfigurationFactory
{
    public static ScrapeConfiguration Create()
        => new()
        {
            Id = ScrapeConfigurationId.Empty,
            ScrapeSettings = new ScrapeSettings
            {
                SiteName = new SiteName("Mock Site Name"),
                SiteUrl = new Uri("https://example.com"),
                SearchCategoryPrefix = new SearchCategoryPrefix("Mock Search Category Prefix"),
                SearchCategorySuffix = new SearchCategorySuffix("Mock Search Category Suffix"),
                TopWallpapers = new TopWallpapers("Mock Top Wallpapers"),
                HotWallpapers = new HotWallpapers("Mock Hot Wallpapers"),
                Username = new Username("Mock Username"),
                HashedPassword = new HashedPassword("Mock Hashed Password")
            }
        };
}
