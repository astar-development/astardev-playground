using AStarDev.SourceGenerators.StrongTypeCodeGeneration;
using AStarDev.SourceGenerators.TestsUnit.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace AStarDev.SourceGenerators.TestsUnit.StrongTypeCodeGeneration;

public sealed class GivenAStrongTypeGenerator
{
    [Fact]
    public void when_the_type_is_int_on_a_partial_record_struct_then_the_full_record_struct_is_generated_with_value_property_of_type_int()
    {
        const string input = """
                             using AStarDev.SourceGeneratorAttributes;
                             namespace TestNamespace
                             {
                                 [StrongType(typeof(int))]
                                 public readonly partial record struct MyId { }
                             }
                             """;

        var compilation = CompilationHelpers.CreateCompilation(input);

        var generator = new StrongTypeGenerator();
        var driver = CSharpGeneratorDriver.Create(generator);
        driver = (CSharpGeneratorDriver)driver.RunGenerators(compilation, TestContext.Current.CancellationToken);
        var result = driver.GetRunResult();
        var allGenerated = result.Results.SelectMany(r => r.GeneratedSources).ToList();
        var generated = allGenerated.FirstOrDefault(x => x.HintName.Contains("MyId", StringComparison.Ordinal));
        generated.Equals(default(GeneratedSourceResult)).ShouldBeFalse();
        string generatedText = generated.SourceText.ToString();
        generatedText.ShouldContain("public readonly partial record struct MyId(System.Int32 Value)");
    }

    [Fact]
    public void when_the_type_is_string_on_a_partial_record_struct_then_the_full_record_struct_is_generated_with_value_property_of_type_string()
    {
        const string input = """
                             using AStarDev.SourceGeneratorAttributes;
                             namespace TestNamespace
                             {
                                 [StrongType(typeof(string))]
                                 public readonly partial record struct MyId { }
                             }
                             """;

        var compilation = CompilationHelpers.CreateCompilation(input);

        var generator = new StrongTypeGenerator();
        var driver = CSharpGeneratorDriver.Create(generator);
        driver = (CSharpGeneratorDriver)driver.RunGenerators(compilation, TestContext.Current.CancellationToken);
        var result = driver.GetRunResult();
        var allGenerated = result.Results.SelectMany(r => r.GeneratedSources).ToList();
        var generated = allGenerated.FirstOrDefault(x => x.HintName.Contains("MyId", StringComparison.Ordinal));
        generated.Equals(default(GeneratedSourceResult)).ShouldBeFalse();
        string generatedText = generated.SourceText.ToString();
        generatedText.ShouldContain("public readonly partial record struct MyId(System.String Value)");
    }

    [Fact]
    public void when_the_type_is_guid_on_a_partial_record_struct_then_the_full_record_struct_is_generated_with_value_property_of_type_guid()
    {
        const string input = """
                             using AStarDev.SourceGeneratorAttributes;
                             namespace TestNamespace
                             {
                                 [StrongType(typeof(Guid))]
                                 public readonly partial record struct MyId { }
                             }
                             """;

        var compilation = CompilationHelpers.CreateCompilation(input);

        var generator = new StrongTypeGenerator();
        var driver = CSharpGeneratorDriver.Create(generator);
        driver = (CSharpGeneratorDriver)driver.RunGenerators(compilation, TestContext.Current.CancellationToken);
        var result = driver.GetRunResult();
        var allGenerated = result.Results.SelectMany(r => r.GeneratedSources).ToList();
        var generated = allGenerated.FirstOrDefault(x => x.HintName.Contains("MyId", StringComparison.Ordinal));
        generated.Equals(default(GeneratedSourceResult)).ShouldBeFalse();
        string generatedText = generated.SourceText.ToString();
        generatedText.ShouldContain("public readonly partial record struct MyId(System.Guid Value)");
    }

    [Fact]
    public void when_the_type_is_long_on_a_partial_record_struct_then_the_full_record_struct_is_generated_with_value_property_of_type_long()
    {
        const string input = """
                             using AStarDev.SourceGeneratorAttributes;
                             namespace TestNamespace
                             {
                                 [StrongType(typeof(long))]
                                 public readonly partial record struct MyId { }
                             }
                             """;

        var compilation = CompilationHelpers.CreateCompilation(input);

        var generator = new StrongTypeGenerator();
        var driver = CSharpGeneratorDriver.Create(generator);
        driver = (CSharpGeneratorDriver)driver.RunGenerators(compilation, TestContext.Current.CancellationToken);
        var result = driver.GetRunResult();
        var allGenerated = result.Results.SelectMany(r => r.GeneratedSources).ToList();
        var generated = allGenerated.FirstOrDefault(x => x.HintName.Contains("MyId", StringComparison.Ordinal));
        generated.Equals(default(GeneratedSourceResult)).ShouldBeFalse();
        string generatedText = generated.SourceText.ToString();
        generatedText.ShouldContain("public readonly partial record struct MyId(System.Int64 Value)");
    }

    [Fact]
    public void when_no_type_is_specified_on_a_partial_record_struct_then_the_full_record_struct_is_generated_with_value_property_of_type_guid()
    {
        const string input = """
                             using AStarDev.SourceGeneratorAttributes;
                             namespace TestNamespace
                             {
                                 [StrongType]
                                 public readonly partial record struct MyId { }
                             }
                             """;

        var compilation = CompilationHelpers.CreateCompilation(input);

        var generator = new StrongTypeGenerator();
        var driver = CSharpGeneratorDriver.Create(generator);
        driver = (CSharpGeneratorDriver)driver.RunGenerators(compilation, TestContext.Current.CancellationToken);
        var result = driver.GetRunResult();
        var allGenerated = result.Results.SelectMany(r => r.GeneratedSources).ToList();
        var generated = allGenerated.FirstOrDefault(x => x.HintName.Contains("MyId", StringComparison.Ordinal));
        generated.Equals(default(GeneratedSourceResult)).ShouldBeFalse();
        string generatedText = generated.SourceText.ToString();
        generatedText.ShouldContain("public readonly partial record struct MyId(System.Guid Value)");
    }

    [Fact]
    public void when_the_full_record_struct_is_generated_with_value_property_then_the_implicit_converters_should_be_generated()
    {
        const string input = """
                             using AStarDev.SourceGeneratorAttributes;
                             namespace TestNamespace
                             {
                                 [StrongType]
                                 public readonly partial record struct MyId { }
                             }
                             """;

        var compilation = CompilationHelpers.CreateCompilation(input);

        var generator = new StrongTypeGenerator();
        var driver = CSharpGeneratorDriver.Create(generator);
        driver = (CSharpGeneratorDriver)driver.RunGenerators(compilation, TestContext.Current.CancellationToken);
        var result = driver.GetRunResult();
        var allGenerated = result.Results.SelectMany(r => r.GeneratedSources).ToList();
        var generated = allGenerated.FirstOrDefault(x => x.HintName.Contains("MyId", StringComparison.Ordinal));
        generated.Equals(default(GeneratedSourceResult)).ShouldBeFalse();
        string generatedText = generated.SourceText.ToString();
        generatedText.ShouldBe("""
                               // <auto-generated/>

                               using System;
                               using System.Collections.Generic;

                               namespace TestNamespace;

                               /// <summary>A strongly-typed wrapper around a <see cref="System.Guid"/> value.</summary>
                               /// <param name="Value">The underlying value.</param>
                               public readonly partial record struct MyId(System.Guid Value)
                               {
                                   /// <inheritdoc />
                                   public static implicit operator MyId(System.Guid value) => new MyId(value);

                                   /// <inheritdoc />
                                   public static implicit operator System.Guid(MyId strongType) => strongType.Value;
                               }
                               """);
    }

    [Fact]
    public void when_the_partial_record_struct_is_not_readonly_then_the_full_record_struct_is_still_generated_with_readonly_added()
    {
        const string input = """
                             using AStarDev.SourceGeneratorAttributes;
                             namespace TestNamespace
                             {
                                 [StrongType(typeof(int))]
                                 public partial record struct MyId { }
                             }
                             """;

        var compilation = CompilationHelpers.CreateCompilation(input);

        var generator = new StrongTypeGenerator();
        var driver = CSharpGeneratorDriver.Create(generator);
        driver = (CSharpGeneratorDriver)driver.RunGenerators(compilation, TestContext.Current.CancellationToken);
        var result = driver.GetRunResult();
        var allGenerated = result.Results.SelectMany(r => r.GeneratedSources).ToList();
        var generated = allGenerated.FirstOrDefault(x => x.HintName.Contains("MyId", StringComparison.Ordinal));
        generated.Equals(default(GeneratedSourceResult)).ShouldBeFalse();
        string generatedText = generated.SourceText.ToString();
        generatedText.ShouldContain("public readonly partial record struct MyId(System.Int32 Value)");
    }

    [Fact]
    public void when_the_type_is_non_partial_record_struct_then_no_code_is_generated()
    {
        const string input = """
                             using AStarDev.SourceGeneratorAttributes;
                             namespace TestNamespace
                             {
                                 [StrongType(typeof(int))]
                                 public record struct MyId { }
                             }
                             """;

        var compilation = CompilationHelpers.CreateCompilation(input);

        var generator = new StrongTypeGenerator();
        var driver = CSharpGeneratorDriver.Create(generator);
        driver = (CSharpGeneratorDriver)driver.RunGenerators(compilation, TestContext.Current.CancellationToken);
        var result = driver.GetRunResult();
        var allGenerated = result.Results.SelectMany(r => r.GeneratedSources).ToList();
        var generated = allGenerated.FirstOrDefault(x => x.HintName.Contains("MyId", StringComparison.Ordinal));
        generated.Equals(default(GeneratedSourceResult)).ShouldBeTrue();
    }

    [Fact]
    public void when_the_type_is_non_partial_non_record_struct_then_no_code_is_generated()
    {
        const string input = """
                             using AStarDev.SourceGeneratorAttributes;
                             namespace TestNamespace
                             {
                                 [StrongType(typeof(int))]
                                 public struct MyId { }
                             }
                             """;

        var compilation = CompilationHelpers.CreateCompilation(input);

        var generator = new StrongTypeGenerator();
        var driver = CSharpGeneratorDriver.Create(generator);
        driver = (CSharpGeneratorDriver)driver.RunGenerators(compilation, TestContext.Current.CancellationToken);
        var result = driver.GetRunResult();
        var allGenerated = result.Results.SelectMany(r => r.GeneratedSources).ToList();
        var generated = allGenerated.FirstOrDefault(x => x.HintName.Contains("MyId", StringComparison.Ordinal));
        generated.Equals(default(GeneratedSourceResult)).ShouldBeTrue();
    }

    [Fact]
    public void when_the_type_is_string_on_a_partial_record_class_then_the_full_sealed_record_class_is_generated_with_value_property_of_type_string()
    {
        const string input = """
                             using AStarDev.SourceGeneratorAttributes;
                             namespace TestNamespace
                             {
                                 [StrongType(typeof(string))]
                                 public partial record EmailAddress { }
                             }
                             """;

        var compilation = CompilationHelpers.CreateCompilation(input);

        var generator = new StrongTypeGenerator();
        var driver = CSharpGeneratorDriver.Create(generator);
        driver = (CSharpGeneratorDriver)driver.RunGenerators(compilation, TestContext.Current.CancellationToken);
        var result = driver.GetRunResult();
        var allGenerated = result.Results.SelectMany(r => r.GeneratedSources).ToList();
        var generated = allGenerated.FirstOrDefault(x => x.HintName.Contains("EmailAddress", StringComparison.Ordinal));
        generated.Equals(default(GeneratedSourceResult)).ShouldBeFalse();
        string generatedText = generated.SourceText.ToString();
        generatedText.ShouldContain("public sealed partial record EmailAddress(System.String Value)");
    }

    [Fact]
    public void when_the_partial_record_is_declared_with_the_class_keyword_then_the_full_sealed_record_class_is_generated()
    {
        const string input = """
                             using AStarDev.SourceGeneratorAttributes;
                             namespace TestNamespace
                             {
                                 [StrongType(typeof(string))]
                                 public partial record class EmailAddress { }
                             }
                             """;

        var compilation = CompilationHelpers.CreateCompilation(input);

        var generator = new StrongTypeGenerator();
        var driver = CSharpGeneratorDriver.Create(generator);
        driver = (CSharpGeneratorDriver)driver.RunGenerators(compilation, TestContext.Current.CancellationToken);
        var result = driver.GetRunResult();
        var allGenerated = result.Results.SelectMany(r => r.GeneratedSources).ToList();
        var generated = allGenerated.FirstOrDefault(x => x.HintName.Contains("EmailAddress", StringComparison.Ordinal));
        generated.Equals(default(GeneratedSourceResult)).ShouldBeFalse();
        string generatedText = generated.SourceText.ToString();
        generatedText.ShouldContain("public sealed partial record EmailAddress(System.String Value)");
    }

    [Fact]
    public void when_the_full_record_class_is_generated_with_value_property_then_the_implicit_converters_should_be_generated()
    {
        const string input = """
                             using AStarDev.SourceGeneratorAttributes;
                             namespace TestNamespace
                             {
                                 [StrongType(typeof(string))]
                                 public partial record EmailAddress { }
                             }
                             """;

        var compilation = CompilationHelpers.CreateCompilation(input);

        var generator = new StrongTypeGenerator();
        var driver = CSharpGeneratorDriver.Create(generator);
        driver = (CSharpGeneratorDriver)driver.RunGenerators(compilation, TestContext.Current.CancellationToken);
        var result = driver.GetRunResult();
        var allGenerated = result.Results.SelectMany(r => r.GeneratedSources).ToList();
        var generated = allGenerated.FirstOrDefault(x => x.HintName.Contains("EmailAddress", StringComparison.Ordinal));
        generated.Equals(default(GeneratedSourceResult)).ShouldBeFalse();
        string generatedText = generated.SourceText.ToString();
        generatedText.ShouldBe("""
                               // <auto-generated/>

                               using System;
                               using System.Collections.Generic;

                               namespace TestNamespace;

                               /// <summary>A strongly-typed wrapper around a <see cref="System.String"/> value.</summary>
                               /// <param name="Value">The underlying value.</param>
                               public sealed partial record EmailAddress(System.String Value)
                               {
                                   /// <inheritdoc />
                                   public static implicit operator EmailAddress(System.String value) => new EmailAddress(value);

                                   /// <inheritdoc />
                                   public static implicit operator System.String(EmailAddress strongType) => strongType.Value;
                               }
                               """);
    }

    [Fact]
    public void when_the_partial_record_class_is_internal_then_the_generated_record_class_is_internal()
    {
        const string input = """
                             using AStarDev.SourceGeneratorAttributes;
                             namespace TestNamespace
                             {
                                 [StrongType(typeof(string))]
                                 internal partial record EmailAddress { }
                             }
                             """;

        var compilation = CompilationHelpers.CreateCompilation(input);

        var generator = new StrongTypeGenerator();
        var driver = CSharpGeneratorDriver.Create(generator);
        driver = (CSharpGeneratorDriver)driver.RunGenerators(compilation, TestContext.Current.CancellationToken);
        var result = driver.GetRunResult();
        var allGenerated = result.Results.SelectMany(r => r.GeneratedSources).ToList();
        var generated = allGenerated.FirstOrDefault(x => x.HintName.Contains("EmailAddress", StringComparison.Ordinal));
        generated.Equals(default(GeneratedSourceResult)).ShouldBeFalse();
        string generatedText = generated.SourceText.ToString();
        generatedText.ShouldContain("internal sealed partial record EmailAddress(System.String Value)");
    }

    [Fact]
    public void when_the_type_is_non_partial_record_class_then_no_code_is_generated()
    {
        const string input = """
                             using AStarDev.SourceGeneratorAttributes;
                             namespace TestNamespace
                             {
                                 [StrongType(typeof(string))]
                                 public record EmailAddress { }
                             }
                             """;

        var compilation = CompilationHelpers.CreateCompilation(input);

        var generator = new StrongTypeGenerator();
        var driver = CSharpGeneratorDriver.Create(generator);
        driver = (CSharpGeneratorDriver)driver.RunGenerators(compilation, TestContext.Current.CancellationToken);
        var result = driver.GetRunResult();
        var allGenerated = result.Results.SelectMany(r => r.GeneratedSources).ToList();
        var generated = allGenerated.FirstOrDefault(x => x.HintName.Contains("EmailAddress", StringComparison.Ordinal));
        generated.Equals(default(GeneratedSourceResult)).ShouldBeTrue();
    }

    [Fact]
    public void when_the_type_is_partial_non_record_class_then_no_code_is_generated()
    {
        const string input = """
                             using AStarDev.SourceGeneratorAttributes;
                             namespace TestNamespace
                             {
                                 [StrongType(typeof(string))]
                                 public partial class EmailAddress { }
                             }
                             """;

        var compilation = CompilationHelpers.CreateCompilation(input);

        var generator = new StrongTypeGenerator();
        var driver = CSharpGeneratorDriver.Create(generator);
        driver = (CSharpGeneratorDriver)driver.RunGenerators(compilation, TestContext.Current.CancellationToken);
        var result = driver.GetRunResult();
        var allGenerated = result.Results.SelectMany(r => r.GeneratedSources).ToList();
        var generated = allGenerated.FirstOrDefault(x => x.HintName.Contains("EmailAddress", StringComparison.Ordinal));
        generated.Equals(default(GeneratedSourceResult)).ShouldBeTrue();
    }
}
