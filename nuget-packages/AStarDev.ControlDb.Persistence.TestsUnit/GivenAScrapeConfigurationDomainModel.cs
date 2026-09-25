using AStarDev.ControlDb.Persistence.TestsUnit.TestFactories;
using Domain = AStarDev.ControlDb;

namespace AStarDev.ControlDb.Persistence.TestsUnit;

public sealed class GivenAScrapeConfigurationDomainModel
{
    private static readonly Domain.ScrapeConfiguration DomainModel = new(
        new Domain.ScrapeConfigurationId(Guid.CreateVersion7()),
        new Domain.ScrapeSettings(
            new Domain.SiteName("Domain Site Name"),
            new Uri("https://domain.example.com"),
            new Domain.SearchCategoryPrefix("Domain Search Category Prefix"),
            new Domain.SearchCategorySuffix("Domain Search Category Suffix"),
            new Domain.TopWallpapers("Domain Top Wallpapers"),
            new Domain.HotWallpapers("Domain Hot Wallpapers"),
            new Domain.Username("Domain Username"),
            new Domain.HashedPassword("Domain Hashed Password")
        )
    );

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

        entity.ScrapeSettings.SiteName.Value.ShouldBe("Domain Site Name");
        entity.ScrapeSettings.SiteUrl.AbsoluteUri.ShouldBe("https://domain.example.com/");
        entity.ScrapeSettings.SearchCategoryPrefix.Value.ShouldBe("Domain Search Category Prefix");
        entity.ScrapeSettings.SearchCategorySuffix.Value.ShouldBe("Domain Search Category Suffix");
        entity.ScrapeSettings.TopWallpapers.Value.ShouldBe("Domain Top Wallpapers");
        entity.ScrapeSettings.HotWallpapers.Value.ShouldBe("Domain Hot Wallpapers");
        entity.ScrapeSettings.Username.Value.ShouldBe("Domain Username");
        entity.ScrapeSettings.HashedPassword.Value.ShouldBe("Domain Hashed Password");
    }

    [Fact]
    public void when_converting_to_an_entity_then_the_credentials_are_copied()
    {
        ScrapeConfiguration entity = DomainModel.ToEntity();

        entity.ScrapeSettings.HashedPassword.Value.ShouldBe("Domain Hashed Password");
        entity.ScrapeSettings.HashedPassword.Value.ShouldBe("Domain Hashed Password");
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

        existing.ScrapeSettings.SiteName.Value.ShouldBe("Domain Site Name");
        existing.ScrapeSettings.SiteUrl.AbsoluteUri.ShouldBe("https://domain.example.com/");
        existing.ScrapeSettings.SearchCategoryPrefix.Value.ShouldBe("Domain Search Category Prefix");
        existing.ScrapeSettings.SearchCategorySuffix.Value.ShouldBe("Domain Search Category Suffix");
        existing.ScrapeSettings.TopWallpapers.Value.ShouldBe("Domain Top Wallpapers");
        existing.ScrapeSettings.HotWallpapers.Value.ShouldBe("Domain Hot Wallpapers");
        existing.ScrapeSettings.Username.Value.ShouldBe("Domain Username");
        existing.ScrapeSettings.HashedPassword.Value.ShouldBe("Domain Hashed Password");
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
