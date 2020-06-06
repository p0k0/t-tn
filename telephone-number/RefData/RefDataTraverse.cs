using System;
using System.Collections.Generic;
using System.Text;

namespace Storage
{
    public class RefDataTraverse
    {
        public void Traverse(RefData node, Visitor visitor)
        {
            visitor.Visit(node);
            foreach (var sub in node.SubNodes)
            {
                Traverse(sub, visitor);
            }
        }
    }
}
