using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;
using System.Linq;

namespace InitializeAsync
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public class IsInitializeAsyncInvokedCorrectlyAnalyzer
	 : DiagnosticAnalyzer
	{
		private static DiagnosticDescriptor initializeAsyncRule =
			new DiagnosticDescriptor(
				"IA0001", "Find objects that are not initialized asynchronously correctly",
				"InitializeAsync<T> must be called immediately after construction",
				"Usage", DiagnosticSeverity.Error, true);

		public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics
		{
			get
			{
				return ImmutableArray.Create(IsInitializeAsyncInvokedCorrectlyAnalyzer.initializeAsyncRule);
			}
		}

		public override void Initialize(AnalysisContext context)
		{
			context.RegisterSyntaxNodeAction<SyntaxKind>(
			  IsInitializeAsyncInvokedCorrectlyAnalyzer.AnalyzeObjectCreation, SyntaxKind.ObjectCreationExpression);
		}

		private static void AnalyzeObjectCreation(SyntaxNodeAnalysisContext context)
		{
			var objectCreation = (ObjectCreationExpressionSyntax)context.Node;
			var iInitializeAsync = context.SemanticModel
				.Compilation.GetTypeByMetadataName(typeof(IInitializeAsync<>).FullName);
			var symbolInfo = context.SemanticModel.GetSymbolInfo(
				objectCreation.Type).Symbol as INamedTypeSymbol;

			if (symbolInfo != null &&
				 symbolInfo.Interfaces.Contains(iInitializeAsync))
			{
				// ...
			}
		}
	}
}
