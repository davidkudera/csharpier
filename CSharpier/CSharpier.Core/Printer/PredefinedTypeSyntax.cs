using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CSharpier.Core
{
    public partial class Printer
    {
        private Doc PrintPredefinedTypeSyntax(PredefinedTypeSyntax node)
        {
            return this.PrintSyntaxToken(node.Keyword);
        }
    }
}
