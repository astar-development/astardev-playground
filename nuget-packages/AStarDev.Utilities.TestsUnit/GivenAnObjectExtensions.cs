namespace AStarDev.Utilities.TestsUnit;

public class GivenAnObjectExtensions
{
    [Fact]
    public void when_the_toJson_extension_is_called_then_the_returned_object_is_as_expected()
        => new MockClass { Id = 1, Name = "Test" }.ToJson().ShouldMatchApproved();

    private sealed class MockClass
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
