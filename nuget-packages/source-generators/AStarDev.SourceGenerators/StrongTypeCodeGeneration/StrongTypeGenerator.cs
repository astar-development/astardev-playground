using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace AStarDev.SourceGenerators.StrongTypeCodeGeneration;

/// <summary>The <see cref="StrongTypeGenerator" /> class is a source generator that completes partial records annotated with the StrongTypeAttribute.</summary>
[Generator]
[System.Diagnostics.CodeAnalysis.SuppressMessage("MicrosoftCodeAnalysisCorrectness", "RS1038:Compiler extensions should be implemented in assemblies with compiler-provided references", Justification = "<Pending>")]
public class StrongTypeGenerator : IIncrementalGenerator
{
    /// <summary>
    /// The <see cref="Initialize" /> method is called by the compiler to register the source generation steps. It sets up a syntax provider to find all partial record structs and record classes with attributes and generates source code for those annotated with the <see cref="SourceGeneratorAttributes.StrongTypeAttribute" />.
    /// </summary>
    /// <param name="context"></param>
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var records = context.SyntaxProvider
            .CreateSyntaxProvider(
                predicate: static (s, _) => s is RecordDeclarationSyntax,
                transform: static (ctx, _) => (RecordDeclarationSyntax)ctx.Node)
            .Where(static rds => rds.Modifiers.Any(m => m.IsKind(SyntaxKind.PartialKeyword)) &&
                                 rds.AttributeLists.Count > 0)
            .Collect();

        context.RegisterSourceOutput(context.CompilationProvider.Combine(records), static (spc, source) =>
        {
            (var compilation, var recordDeclarations) = source;
            // Cache attribute symbol lookup
            var strongTypeAttrSymbol = compilation.GetTypeByMetadataName($"{AttributeConstants.AttributeNamespace}.{AttributeConstants.StrongTypeAttributeName}");
            if (strongTypeAttrSymbol == null)
                return;

            foreach (var recordDeclaration in recordDeclarations)
            {
                var model = compilation.GetSemanticModel(recordDeclaration.SyntaxTree);
                if (model.GetDeclaredSymbol(recordDeclaration) is not { } symbol)
                    continue;

                var attr = symbol.GetAttributes().FirstOrDefault(a => SymbolEqualityComparer.Default.Equals(a.AttributeClass, strongTypeAttrSymbol));
                if (attr == null)
                    continue;

                // Only allow 0 or 1 constructor argument
                if (attr.ConstructorArguments.Length > 1)
                    continue;

                string underlyingType = StrongTypeModelExtensions.CreateUnderlyingTypeFromAttribute(attr);
                string? ns = symbol.ContainingNamespace.IsGlobalNamespace ? null : symbol.ContainingNamespace.ToDisplayString();
                var modelObj = new StrongTypeModel(ns, symbol.Name, symbol.DeclaredAccessibility, underlyingType, symbol.IsValueType);
                string code = StrongTypeCodeGenerator.Generate(modelObj);
                spc.AddSource($"{modelObj.ModelName}_StrongType.g.cs", SourceText.From(code, Encoding.UTF8));
            }
        });
    }
}
