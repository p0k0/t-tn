using System;

namespace Trees.Visitor
{
    public class FindNodeVisitor : ConditionalVisitor
    {
        private readonly Node _targetNode;

        public FindNodeVisitor(Node targetNode)
        {
            _targetNode = targetNode ?? throw new ArgumentNullException(nameof(targetNode));
        }

        public override bool Visit(Node node)
        {
            if (node.Data != _targetNode.Data)
                return false;

            return true;
        }
    }
}
