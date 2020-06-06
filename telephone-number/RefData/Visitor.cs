using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Storage
{
    public abstract class Visitor
    {
        public abstract void Visit(RefData node);
    }

    public abstract class VisitorWithCondition
    {
        public abstract bool Visit(RefData node);
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

    public class AccumulateVisitor : Visitor
    {
        private readonly StringBuilder _path;

        public AccumulateVisitor()
        {
            _path = new StringBuilder();
        }

        public override void Visit(RefData node)
        {
            _path.Append(node.Data);
        }

        public string GetTraversedPath() => _path.ToString();
    }
}
