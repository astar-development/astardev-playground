using AStarDev.ControlDb.TestsUnit.TestFactories;

namespace AStarDev.ControlDb.TestsUnit;

public sealed class GivenAScrapeConfigurationDomainModel
{
    [Fact]
    public void when_creating_a_domain_model_then_all_properties_are_set_correctly()
    {
        ScrapeConfiguration entity = ScrapeConfigurationFactory.Create();

        entity.SiteName.ShouldBe("Mock Site Name");
        entity.SiteUrl.ShouldBe("https://example.com");
        entity.SearchCategoryPrefix.ShouldBe("Mock Search Category Prefix");
        entity.SearchCategorySuffix.ShouldBe("Mock Search Category Suffix");
        entity.TopWallpapers.ShouldBe("Mock Top Wallpapers");
        entity.HotWallpapers.ShouldBe("Mock Hot Wallpapers");
        entity.Username.ShouldBe("Mock Username");
        entity.HashedPassword.ShouldBe("Mock Hashed Password");
    }
}
