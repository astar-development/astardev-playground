namespace AStarDev.ControlDb.Persistence;

public sealed class ScrapeConfiguration
{
    public ScrapeConfigurationId Id { get; set; }
    public string SiteName { get; set; } = string.Empty;
    public string SiteUrl { get; set; } = string.Empty;
    public string SearchCategoryPrefix { get; set; } = string.Empty;
    public string SearchCategorySuffix { get; set; } = string.Empty;
    public string TopWallpapers { get; set; } = string.Empty;
    public string HotWallpapers { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string HashedPassword { get; set; } = string.Empty;
}
