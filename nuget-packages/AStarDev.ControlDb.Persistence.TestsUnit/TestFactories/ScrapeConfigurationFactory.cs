namespace AStarDev.ControlDb.Persistence.TestsUnit.TestFactories;

public static class ScrapeConfigurationFactory
{
    public static ScrapeConfiguration Create()
        => new(ScrapeConfigurationId.Empty, "Mock Site Name", "https://example.com", "Mock Search Category Prefix", "Mock Search Category Suffix", "Mock Top Wallpapers", "Mock Hot Wallpapers", "Mock Username", "Mock Hashed Password");
}