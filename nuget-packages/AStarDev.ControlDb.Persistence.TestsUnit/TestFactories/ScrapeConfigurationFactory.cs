namespace AStarDev.ControlDb.Persistence.TestsUnit.TestFactories;

public static class ScrapeConfigurationFactory
{
    public static ScrapeConfiguration Create()
        => new()
        {
            Id = ScrapeConfigurationId.Empty,
            SiteName = "Mock Site Name",
            SiteUrl = "https://example.com",
            SearchCategoryPrefix = "Mock Search Category Prefix",
            SearchCategorySuffix = "Mock Search Category Suffix",
            TopWallpapers = "Mock Top Wallpapers",
            HotWallpapers = "Mock Hot Wallpapers",
            Username = "Mock Username",
            HashedPassword = "Mock Hashed Password"
        };
}
