using AStarDev.ControlDb.Persistence.TestsUnit.TestFactories;
using Domain = AStarDev.ControlDb;

namespace AStarDev.ControlDb.Persistence.TestsUnit;

public sealed class GivenAScrapeConfigurationDomainModel
{
    private static readonly Domain.ScrapeConfiguration DomainModel = new(
        new Domain.ScrapeConfigurationId(Guid.CreateVersion7()),
        "Domain Site Name",
        "https://domain.example.com",
        "Domain Search Category Prefix",
        "Domain Search Category Suffix",
        "Domain Top Wallpapers",
        "Domain Hot Wallpapers",
        "Domain Username",
        "Domain Hashed Password");

    [Fact]
    public void when_converting_to_an_entity_then_the_id_value_is_preserved()
    {
        ScrapeConfiguration entity = DomainModel.ToEntity();

        entity.Id.Value.ShouldBe(DomainModel.Id.Value);
    }

    [Fact]
    public void when_converting_to_an_entity_then_all_domain_properties_are_copied()
    {
        ScrapeConfiguration entity = DomainModel.ToEntity();

        entity.SiteName.ShouldBe("Domain Site Name");
        entity.SiteUrl.ShouldBe("https://domain.example.com");
        entity.SearchCategoryPrefix.ShouldBe("Domain Search Category Prefix");
        entity.SearchCategorySuffix.ShouldBe("Domain Search Category Suffix");
        entity.TopWallpapers.ShouldBe("Domain Top Wallpapers");
        entity.HotWallpapers.ShouldBe("Domain Hot Wallpapers");
    }

    [Fact]
    public void when_converting_to_an_entity_then_the_credentials_are_copied()
    {
        ScrapeConfiguration entity = DomainModel.ToEntity();

        entity.Username.ShouldBe("Domain Username");
        entity.HashedPassword.ShouldBe("Domain Hashed Password");
    }

    [Fact]
    public void when_updating_an_existing_entity_then_the_same_instance_is_returned()
    {
        ScrapeConfiguration existing = ScrapeConfigurationFactory.Create();

        ScrapeConfiguration result = existing.UpdateFrom(DomainModel);

        result.ShouldBeSameAs(existing);
    }

    [Fact]
    public void when_updating_an_existing_entity_then_all_domain_properties_are_copied()
    {
        ScrapeConfiguration existing = ScrapeConfigurationFactory.Create();

        existing.UpdateFrom(DomainModel);

        existing.SiteName.ShouldBe("Domain Site Name");
        existing.SiteUrl.ShouldBe("https://domain.example.com");
        existing.SearchCategoryPrefix.ShouldBe("Domain Search Category Prefix");
        existing.SearchCategorySuffix.ShouldBe("Domain Search Category Suffix");
        existing.TopWallpapers.ShouldBe("Domain Top Wallpapers");
        existing.HotWallpapers.ShouldBe("Domain Hot Wallpapers");
        existing.Username.ShouldBe("Domain Username");
        existing.HashedPassword.ShouldBe("Domain Hashed Password");
    }

    [Fact]
    public void when_updating_an_existing_entity_then_the_id_is_unchanged()
    {
        ScrapeConfiguration existing = ScrapeConfigurationFactory.Create();
        ScrapeConfigurationId originalId = existing.Id;

        existing.UpdateFrom(DomainModel);

        existing.Id.ShouldBe(originalId);
    }
}
