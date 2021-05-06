using CSharpier.DocTypes;
using CSharpier.SyntaxPrinter;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CSharpier.SyntaxPrinter.SyntaxNodePrinters
{
    public static class ParenthesizedVariableDesignation
    {
        public static Doc Print(ParenthesizedVariableDesignationSyntax node)
        {
            return Doc.Group(
                Token.Print(node.OpenParenToken),
                Doc.Indent(
                    Doc.SoftLine,
                    SeparatedSyntaxList.Print(node.Variables, Node.Print, Doc.Line),
                    Doc.SoftLine
                ),
                Token.Print(node.CloseParenToken)
            );
        }
    }
}
