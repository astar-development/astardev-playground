using System.Diagnostics.CodeAnalysis;

namespace AStarDev.Utilities;

public static class StringExtensions
{
    extension([NotNullWhen(false)] string? value)
    {
        /// <summary>The IsNullOrWhiteSpace method, as you might expect, checks whether the string is, in fact, null, empty or whitespace</summary>
        /// <returns>True if the string is null, empty or whitespace, False otherwise</returns>
        public bool IsNullOrWhiteSpace() => string.IsNullOrWhiteSpace(value);

        /// <summary>The IsNotNullOrWhiteSpace method, as you might expect, checks whether the string is, in fact, null, empty or whitespace</summary>
        /// <returns>True if the string is null, empty or whitespace, False otherwise</returns>
        public bool IsNotNullOrWhiteSpace() => !string.IsNullOrWhiteSpace(value);
    }
}
