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

    public class RefDataTraverseWithCondition
    {
        public virtual bool Traverse(RefData node, VisitorWithCondition visitor)
        {
            if (visitor.Visit(node))
                return true;

            foreach (var sub in node.SubNodes)
            {
                if (Traverse(sub, visitor))
                    return true;
            }

            return false;
        }
    }
}
