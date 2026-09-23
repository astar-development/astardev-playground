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

        builder.Property(sc => sc.SiteName).IsRequired().HasColumnType("varchar(50)");
        builder.Property(sc => sc.SiteUrl).IsRequired().HasColumnType("varchar(255)");
        builder.Property(sc => sc.SearchCategoryPrefix).IsRequired().HasColumnType("varchar(255)");
        builder.Property(sc => sc.SearchCategorySuffix).IsRequired().HasColumnType("varchar(255)");
        builder.Property(sc => sc.TopWallpapers).IsRequired().HasColumnType("varchar(255)");
        builder.Property(sc => sc.HotWallpapers).IsRequired().HasColumnType("varchar(255)");
        builder.Property(sc => sc.Username).IsRequired().HasColumnType("varchar(50)");
        builder.Property(sc => sc.HashedPassword).IsRequired().HasColumnType("varchar(255)");
    }
}