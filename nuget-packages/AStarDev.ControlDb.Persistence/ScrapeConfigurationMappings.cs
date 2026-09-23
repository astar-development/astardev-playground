using Domain = AStarDev.ControlDb;

namespace AStarDev.ControlDb.Persistence;

/// <summary>Converts between the immutable domain <see cref="Domain.ScrapeConfiguration"/> and the mutable EF Core <see cref="ScrapeConfiguration"/> entity.</summary>
public static class ScrapeConfigurationMappings
{
    /// <summary>Creates an immutable domain model from the entity.</summary>
    public static Domain.ScrapeConfiguration ToDomain(this ScrapeConfiguration entity)
        => new(new Domain.ScrapeConfigurationId(entity.Id.Value), entity.SiteName, entity.SiteUrl, entity.SearchCategoryPrefix, entity.SearchCategorySuffix, entity.TopWallpapers, entity.HotWallpapers, entity.Username, entity.HashedPassword);

    /// <summary>Creates a new entity from the domain model.</summary>
    public static ScrapeConfiguration ToEntity(this Domain.ScrapeConfiguration scrapeConfiguration)
        => new ScrapeConfiguration { Id = new ScrapeConfigurationId(scrapeConfiguration.Id.Value) }.UpdateFrom(scrapeConfiguration);

    /// <summary>Copies the domain model's values onto this (typically tracked) entity so EF Core detects the changes. The Id is left unchanged.</summary>
    public static ScrapeConfiguration UpdateFrom(this ScrapeConfiguration entity, Domain.ScrapeConfiguration scrapeConfiguration)
    {
        entity.SiteName = scrapeConfiguration.SiteName;
        entity.SiteUrl = scrapeConfiguration.SiteUrl;
        entity.SearchCategoryPrefix = scrapeConfiguration.SearchCategoryPrefix;
        entity.SearchCategorySuffix = scrapeConfiguration.SearchCategorySuffix;
        entity.TopWallpapers = scrapeConfiguration.TopWallpapers;
        entity.HotWallpapers = scrapeConfiguration.HotWallpapers;
        entity.Username = scrapeConfiguration.Username;
        entity.HashedPassword = scrapeConfiguration.HashedPassword;

        return entity;
    }
}
