using AStarDev.ControlDb.Persistence.TestsUnit.TestFactories;
using Domain = AStarDev.ControlDb;

namespace AStarDev.ControlDb.Persistence.TestsUnit;

public sealed class GivenAScrapeConfigurationEntity
{
    [Fact]
    public void when_converting_to_a_domain_model_then_the_id_value_is_preserved()
    {
        ScrapeConfiguration entity = ScrapeConfigurationFactory.Create();
        entity.Id = ScrapeConfigurationId.Create;

        Domain.ScrapeConfiguration domainModel = entity.ToDomain();

        domainModel.Id.Value.ShouldBe(entity.Id.Value);
    }

    [Fact]
    public void when_converting_to_a_domain_model_then_all_properties_are_copied()
    {
        ScrapeConfiguration entity = ScrapeConfigurationFactory.Create();

        Domain.ScrapeConfiguration domainModel = entity.ToDomain();

        domainModel.SiteName.ShouldBe("Mock Site Name");
        domainModel.SiteUrl.ShouldBe("https://example.com");
        domainModel.SearchCategoryPrefix.ShouldBe("Mock Search Category Prefix");
        domainModel.SearchCategorySuffix.ShouldBe("Mock Search Category Suffix");
        domainModel.TopWallpapers.ShouldBe("Mock Top Wallpapers");
        domainModel.HotWallpapers.ShouldBe("Mock Hot Wallpapers");
        domainModel.Username.ShouldBe("Mock Username");
        domainModel.HashedPassword.ShouldBe("Mock Hashed Password");
    }

    [Fact]
    public void when_converting_to_a_domain_model_and_back_then_the_entity_values_match()
    {
        ScrapeConfiguration entity = ScrapeConfigurationFactory.Create();
        entity.Id = ScrapeConfigurationId.Create;

        ScrapeConfiguration roundTripped = entity.ToDomain().ToEntity();

        roundTripped.ShouldBeEquivalentTo(entity);
    }
}
