namespace AStarDev.ControlDb.TestsUnit.TestFactories;

public static class ScrapeConfigurationFactory
{
    public static ScrapeConfiguration Create()
        => new(ScrapeConfigurationId.Empty, new ScrapeSettings(
            new SiteName("Mock Site Name"),
            new Uri("https://example.com"),
            new SearchCategoryPrefix("Mock Search Category Prefix"),
            new SearchCategorySuffix("Mock Search Category Suffix"),
            new TopWallpapers("Mock Top Wallpapers"),
            new HotWallpapers("Mock Hot Wallpapers"),
            new Username("Mock Username"),
            new HashedPassword("Mock Hashed Password")));
}
