namespace AStarDev.SourceGeneratorAttributes;

/// <summary>
/// Indicates that the target is a strong type wrapping a single underlying value. Intended for use only on partial record structs or partial record classes.
/// This is not enforced by the compiler, but should be validated by source generators.
/// </summary>
/// <remarks>Initializes a new instance of the StrongTypeAttribute class with the specified underlying type.</remarks>
/// <param name="underlyingType">The type of the wrapped value. If null, the default type of Guid will be used.</param>
[AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class StrongTypeAttribute(Type? underlyingType = null) : Attribute
{
    /// <summary>The type of the Value property (typeof(Guid), typeof(int), typeof(string) or typeof(long) - other types are not supported at the moment.). </summary>
    public Type UnderlyingType { get; } = underlyingType ?? typeof(Guid);
}
