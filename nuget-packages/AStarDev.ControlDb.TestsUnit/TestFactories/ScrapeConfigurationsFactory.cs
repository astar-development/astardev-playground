namespace AStarDev.ControlDb.TestsUnit.TestFactories;

public static class ScrapeConfigurationsFactory
{
    public static ScrapeConfiguration Create()
        => new ScrapeConfiguration(Guid.Empty, "Mock Site Name", "https://example.com", "Mock Search Category Prefix", "Mock Search Category Suffix", "Mock Top Wallpapers", "Mock Hot Wallpapers");
}