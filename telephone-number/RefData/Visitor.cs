using System;
using System.Collections.Generic;
using System.Text;

namespace Storage
{
    public class Visitor
    {
        public virtual void Visit(RefData node)
        {

        }
    }

    public class VisitorWithCondition
    {
        public virtual bool Visit(RefData node)
        {
            return false;
        }
    }

    public class FindVisitor : VisitorWithCondition
    {
        private readonly RefData _targetNode;

        public FindVisitor(RefData targetNode)
        {
            _targetNode = targetNode ?? throw new ArgumentNullException(nameof(targetNode));
        }

        public override bool Visit(RefData node)
        {
            if (node.Data != _targetNode.Data)
                return false;

            return true;
        }
    }
}
