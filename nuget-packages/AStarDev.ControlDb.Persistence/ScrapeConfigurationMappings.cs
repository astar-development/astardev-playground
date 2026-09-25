using Domain = AStarDev.ControlDb;

namespace AStarDev.ControlDb.Persistence;

/// <summary>Converts between the immutable domain <see cref="Domain.ScrapeConfiguration"/> and the mutable EF Core <see cref="ScrapeConfiguration"/> entity.</summary>
public static class ScrapeConfigurationMappings
{
    /// <summary>Creates an immutable domain model from the entity.</summary>
    public static Domain.ScrapeConfiguration ToDomain(this ScrapeConfiguration entity)
    => new(new Domain.ScrapeConfigurationId(entity.Id.Value), new Domain.ScrapeSettings(new Domain.SiteName(entity.ScrapeSettings.SiteName.Value), new Uri(entity.ScrapeSettings.SiteUrl.AbsoluteUri), new Domain.SearchCategoryPrefix(entity.ScrapeSettings.SearchCategoryPrefix.Value), new Domain.SearchCategorySuffix(entity.ScrapeSettings.SearchCategorySuffix.Value), new Domain.TopWallpapers(entity.ScrapeSettings.TopWallpapers.Value), new Domain.HotWallpapers(entity.ScrapeSettings.HotWallpapers.Value), new Domain.Username(entity.ScrapeSettings.Username.Value), new Domain.HashedPassword(entity.ScrapeSettings.HashedPassword.Value)));

    /// <summary>Creates a new entity from the domain model.</summary>
    public static ScrapeConfiguration ToEntity(this Domain.ScrapeConfiguration scrapeConfiguration)
        => new ScrapeConfiguration { Id = new ScrapeConfigurationId(scrapeConfiguration.Id.Value) }.UpdateFrom(scrapeConfiguration);

    /// <summary>Copies the domain model's values onto this (typically tracked) entity so EF Core detects the changes. The Id is left unchanged.</summary>
    public static ScrapeConfiguration UpdateFrom(this ScrapeConfiguration entity, Domain.ScrapeConfiguration scrapeConfiguration)
    {
        entity.ScrapeSettings = new ScrapeSettings { SiteName = new SiteName(scrapeConfiguration.ScrapeSettings.SiteName.Value), SiteUrl = new Uri(scrapeConfiguration.ScrapeSettings.SiteUrl.AbsoluteUri), SearchCategoryPrefix = new SearchCategoryPrefix(scrapeConfiguration.ScrapeSettings.SearchCategoryPrefix.Value), SearchCategorySuffix = new SearchCategorySuffix(scrapeConfiguration.ScrapeSettings.SearchCategorySuffix.Value), TopWallpapers = new TopWallpapers(scrapeConfiguration.ScrapeSettings.TopWallpapers.Value), HotWallpapers = new HotWallpapers(scrapeConfiguration.ScrapeSettings.HotWallpapers.Value), Username = new Username(scrapeConfiguration.ScrapeSettings.Username.Value), HashedPassword = new HashedPassword(scrapeConfiguration.ScrapeSettings.HashedPassword.Value) };
        return entity;
    }
}

