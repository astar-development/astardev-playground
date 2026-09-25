using AStarDev.SourceGeneratorAttributes;

namespace AStarDev.ControlDb;

public sealed record ScrapeConfiguration(ScrapeConfigurationId Id, ScrapeSettings ScrapeSettings);

public sealed record ScrapeSettings(SiteName SiteName, Uri SiteUrl, SearchCategoryPrefix SearchCategoryPrefix, SearchCategorySuffix SearchCategorySuffix, TopWallpapers TopWallpapers, HotWallpapers HotWallpapers, Username Username, HashedPassword HashedPassword);

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
