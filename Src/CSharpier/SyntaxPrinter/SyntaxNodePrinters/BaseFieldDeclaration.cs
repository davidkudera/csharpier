using System.Collections.Generic;
using CSharpier.DocTypes;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CSharpier.SyntaxPrinter.SyntaxNodePrinters
{
    public static class BaseFieldDeclaration
    {
        public static Doc Print(BaseFieldDeclarationSyntax node)
        {
            var docs = new List<Doc>
            {
                ExtraNewLines.Print(node),
                AttributeLists.Print(node, node.AttributeLists),
                Modifiers.Print(node.Modifiers)
            };
            if (node is EventFieldDeclarationSyntax eventFieldDeclarationSyntax)
            {
                docs.Add(Token.PrintWithSuffix(eventFieldDeclarationSyntax.EventKeyword, " "));
            }

            docs.Add(Node.Print(node.Declaration), Token.Print(node.SemicolonToken));
            return Doc.Concat(docs);
        }
    }
}
