namespace AStarDev.ControlDb;

public sealed record ScrapeConfiguration(ScrapeConfigurationId Id, string SiteName, string SiteUrl, string SearchCategoryPrefix, string SearchCategorySuffix, string TopWallpapers, string HotWallpapers);
