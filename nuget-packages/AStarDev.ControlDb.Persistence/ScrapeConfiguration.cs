using AStarDev.SourceGeneratorAttributes;

namespace AStarDev.ControlDb.Persistence;

public sealed class ScrapeConfiguration
{
    public ScrapeConfigurationId Id { get; set; }
    public ScrapeSettings ScrapeSettings { get; set; } = default!;
}

public sealed class ScrapeSettings
{

    public SiteName SiteName { get; set; }
    public Uri SiteUrl { get; set; } = default!;
    public SearchCategoryPrefix SearchCategoryPrefix { get; set; }
    public SearchCategorySuffix SearchCategorySuffix { get; set; }
    public TopWallpapers TopWallpapers { get; set; }
    public HotWallpapers HotWallpapers { get; set; }
    public Username Username { get; set; }
    public HashedPassword HashedPassword { get; set; }
}

[StrongType(typeof(string))]
public partial record struct SiteName;

[StrongType(typeof(string))]
public partial record struct SearchCategoryPrefix;

[StrongType(typeof(string))]
public partial record struct SearchCategorySuffix;

[StrongType(typeof(string))]
public partial record struct TopWallpapers;

[StrongType(typeof(string))]
public partial record struct HotWallpapers;

[StrongType(typeof(string))]
public partial record struct Username;

[StrongType(typeof(string))]
public partial record struct HashedPassword;
