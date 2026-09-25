using AStarDev.ControlDb.Persistence.TestsUnit.TestFactories;
using AStarDev.Utilities;
using Domain = AStarDev.ControlDb;

namespace AStarDev.ControlDb.Persistence.TestsUnit;

public sealed class GivenAScrapeConfigurationEntity
{
    [Fact]
    public void when_converting_to_a_domain_model_then_all_properties_are_copied()
    {
        ScrapeConfiguration entity = ScrapeConfigurationFactory.Create();

        Domain.ScrapeConfiguration domainModel = entity.ToDomain();

        domainModel.ToJson().ShouldBeEquivalentTo(entity.ToJson());
    }

    [Fact]
    public void when_converting_to_a_domain_model_and_back_then_the_entity_values_match()
    {
        ScrapeConfiguration entity = ScrapeConfigurationFactory.Create();
        entity.Id = ScrapeConfigurationId.Create;

        ScrapeConfiguration roundTripped = entity.ToDomain().ToEntity();

        roundTripped.ToJson().ShouldBeEquivalentTo(entity.ToJson());
    }
}
