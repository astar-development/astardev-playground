namespace AStarDev.Utilities.TestsUnit;

public class GivenTheStringExtensions
{
    [Fact]
    public void when_the_isNullOrWhiteSpace_extension_is_called_with_a_null_string_then_the_returned_value_is_true()
        => ((string?)null).IsNullOrWhiteSpace().ShouldBeTrue();

    [Fact]
    public void when_the_isNullOrWhiteSpace_extension_is_called_with_an_empty_string_then_the_returned_value_is_true()
        => string.Empty.IsNullOrWhiteSpace().ShouldBeTrue();

    [Fact]
    public void when_the_isNullOrWhiteSpace_extension_is_called_with_a_whitespace_string_then_the_returned_value_is_true()
        => " ".IsNullOrWhiteSpace().ShouldBeTrue();

    [Fact]
    public void when_the_isNullOrWhiteSpace_extension_is_called_with_a_non_whitespace_string_then_the_returned_value_is_false()
        => "Test".IsNullOrWhiteSpace().ShouldBeFalse();

    [Fact]
    public void when_the_isNotNullOrWhiteSpace_extension_is_called_with_a_null_string_then_the_returned_value_is_false()
        => ((string?)null).IsNotNullOrWhiteSpace().ShouldBeFalse();

    [Fact]
    public void when_the_isNotNullOrWhiteSpace_extension_is_called_with_an_empty_string_then_the_returned_value_is_false()
        => string.Empty.IsNotNullOrWhiteSpace().ShouldBeFalse();

    [Fact]
    public void when_the_isNotNullOrWhiteSpace_extension_is_called_with_a_whitespace_string_then_the_returned_value_is_false()
        => " ".IsNotNullOrWhiteSpace().ShouldBeFalse();

    [Fact]
    public void when_the_isNotNullOrWhiteSpace_extension_is_called_with_a_non_whitespace_string_then_the_returned_value_is_true()
        => "Test".IsNotNullOrWhiteSpace().ShouldBeTrue();
}