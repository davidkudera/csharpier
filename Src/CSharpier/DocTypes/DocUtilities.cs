using System.Collections.Generic;

namespace CSharpier.DocTypes
{
    public static class DocUtilities
    {
        public static void RemoveInitialDoubleHardLine(List<Doc> docs)
        {
            var removeNextHardLine = false;
            RemoveInitialDoubleHardLine(docs, ref removeNextHardLine);
        }

        private static void RemoveInitialDoubleHardLine(List<Doc> docs, ref bool removeNextHardLine)
        {
            var x = 0;
            while (x < docs.Count)
            {
                var doc = docs[x];

                if (doc == Doc.Null)
                {
                    docs.RemoveAt(x);
                    break;
                }
                else if (doc is HardLine)
                {
                    if (removeNextHardLine)
                    {
                        docs.RemoveAt(x);
                        return;
                    }

                    removeNextHardLine = true;
                }
                else
                {
                    RemoveInitialDoubleHardLine(doc, ref removeNextHardLine);
                    return;
                }

                x++;
            }

            return;
        }

        public static void RemoveInitialDoubleHardLine(Doc doc)
        {
            var removeNextHardLine = false;
            RemoveInitialDoubleHardLine(doc, ref removeNextHardLine);
        }

        private static void RemoveInitialDoubleHardLine(Doc doc, ref bool removeNextHardLine)
        {
            switch (doc)
            {
                case StringDoc:
                    return;
                case IndentDoc indentDoc:
                    switch (indentDoc.Contents)
                    {
                        case HardLine:
                            if (removeNextHardLine)
                            {
                                indentDoc.Contents = Doc.Null;
                                return;
                            }

                            removeNextHardLine = true;
                            return;
                        default:
                            RemoveInitialDoubleHardLine(indentDoc.Contents, ref removeNextHardLine);
                            return;
                    }
                case Group group:
                    switch (group.Contents)
                    {
                        case HardLine:
                            if (removeNextHardLine)
                            {
                                group.Contents = Doc.Null;
                                return;
                            }

                            removeNextHardLine = true;
                            return;
                        default:
                            RemoveInitialDoubleHardLine(group.Contents, ref removeNextHardLine);
                            return;
                    }
                case Concat concat:
                    RemoveInitialDoubleHardLine(concat.Contents, ref removeNextHardLine);
                    return;
            }
        }
    }
}
