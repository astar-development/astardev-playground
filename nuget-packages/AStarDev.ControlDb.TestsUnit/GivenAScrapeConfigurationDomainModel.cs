using AStarDev.ControlDb.TestsUnit.TestFactories;

namespace AStarDev.ControlDb.TestsUnit;

public sealed class GivenAScrapeConfigurationDomainModel
{
    [Fact]
    public void when_creating_a_domain_model_then_all_properties_are_set_correctly()
    {
        ScrapeConfiguration entity = ScrapeConfigurationFactory.Create();

        entity.ScrapeSettings.SiteName.Value.ShouldBe("Mock Site Name");
        entity.ScrapeSettings.SiteUrl.AbsoluteUri.ShouldBe("https://example.com/");
        entity.ScrapeSettings.SearchCategoryPrefix.Value.ShouldBe("Mock Search Category Prefix");
        entity.ScrapeSettings.SearchCategorySuffix.Value.ShouldBe("Mock Search Category Suffix");
        entity.ScrapeSettings.TopWallpapers.Value.ShouldBe("Mock Top Wallpapers");
        entity.ScrapeSettings.HotWallpapers.Value.ShouldBe("Mock Hot Wallpapers");
        entity.ScrapeSettings.Username.Value.ShouldBe("Mock Username");
        entity.ScrapeSettings.HashedPassword.Value.ShouldBe("Mock Hashed Password");
    }
}
