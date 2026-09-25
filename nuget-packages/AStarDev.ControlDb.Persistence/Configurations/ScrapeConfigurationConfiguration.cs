using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AStarDev.ControlDb.Persistence.Configurations;

public class ScrapeConfigurationConfiguration : IEntityTypeConfiguration<ScrapeConfiguration>
{
    public void Configure(EntityTypeBuilder<ScrapeConfiguration> builder)
    {
        builder.HasKey(sc => sc.Id);
        builder.Property(sc => sc.Id).HasConversion(scrapeConfigurationId => scrapeConfigurationId.Value, value => new ScrapeConfigurationId(value));
        builder.Property(sc => sc.Id).ValueGeneratedOnAdd();

        builder.ComplexProperty(sc => sc.ScrapeSettings, scrapeSettingsBuilder =>
        {
            scrapeSettingsBuilder.Property(ss => ss.SiteName).IsRequired().HasColumnType("varchar(50)").HasConversion(siteName => siteName.Value, value => new SiteName(value));
            scrapeSettingsBuilder.Property(ss => ss.SiteUrl).IsRequired().HasColumnType("varchar(255)").HasConversion(siteUrl => siteUrl.AbsoluteUri, value => new Uri(value));
            scrapeSettingsBuilder.Property(ss => ss.SearchCategoryPrefix).IsRequired().HasColumnType("varchar(255)").HasConversion(searchCategoryPrefix => searchCategoryPrefix.Value, value => new SearchCategoryPrefix(value));
            scrapeSettingsBuilder.Property(ss => ss.SearchCategorySuffix).IsRequired().HasColumnType("varchar(255)").HasConversion(searchCategorySuffix => searchCategorySuffix.Value, value => new SearchCategorySuffix(value));
            scrapeSettingsBuilder.Property(ss => ss.TopWallpapers).IsRequired().HasColumnType("varchar(255)").HasConversion(topWallpapers => topWallpapers.Value, value => new TopWallpapers(value));
            scrapeSettingsBuilder.Property(ss => ss.HotWallpapers).IsRequired().HasColumnType("varchar(255)").HasConversion(hotWallpapers => hotWallpapers.Value, value => new HotWallpapers(value));
            scrapeSettingsBuilder.Property(ss => ss.Username).IsRequired().HasColumnType("varchar(50)").HasConversion(username => username.Value, value => new Username(value));
            scrapeSettingsBuilder.Property(ss => ss.HashedPassword).IsRequired().HasColumnType("varchar(255)").HasConversion(hashedPassword => hashedPassword.Value, value => new HashedPassword(value));
        });
    }
}