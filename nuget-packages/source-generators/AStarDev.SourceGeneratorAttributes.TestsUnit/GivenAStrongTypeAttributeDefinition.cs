namespace AStarDev.SourceGeneratorAttributes.TestsUnit;

public sealed class GivenAStrongTypeAttributeDefinition
{
    [Fact]
    public void when_constructed_with_no_underlying_type_then_underlying_type_defaults_to_guid() => new StrongTypeAttribute().UnderlyingType.ShouldBe(typeof(Guid));

    [Fact]
    public void when_constructed_with_an_underlying_type_then_underlying_type_is_set() => new StrongTypeAttribute(typeof(int)).UnderlyingType.ShouldBe(typeof(int));

    [Fact]
    public void when_attribute_usage_is_inspected_then_it_is_valid_on_structs_and_classes()
        => typeof(StrongTypeAttribute).GetCustomAttributes(typeof(AttributeUsageAttribute), false)
            .OfType<AttributeUsageAttribute>().Single().ValidOn.ShouldBe(AttributeTargets.Struct | AttributeTargets.Class);

    [Fact]
    public void when_attribute_usage_is_inspected_then_it_is_not_inherited()
        => typeof(StrongTypeAttribute).GetCustomAttributes(typeof(AttributeUsageAttribute), false)
            .OfType<AttributeUsageAttribute>().Single().Inherited.ShouldBeFalse();

    [Fact]
    public void when_attribute_usage_is_inspected_then_multiple_usage_is_not_allowed()
        => typeof(StrongTypeAttribute).GetCustomAttributes(typeof(AttributeUsageAttribute), false)
            .OfType<AttributeUsageAttribute>().Single().AllowMultiple.ShouldBeFalse();
}
