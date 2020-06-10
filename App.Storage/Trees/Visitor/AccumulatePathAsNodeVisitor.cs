using System.Collections.Generic;
using System.Linq;

namespace Trees.Visitor
{
    public class AccumulatePathAsNodeVisitor : IVisitor
    {
        public IList<StraightTreeNode> TraversedNodes { get; set; }

        public AccumulatePathAsNodeVisitor()
        {
            TraversedNodes = new List<StraightTreeNode>();
        }

        public void Visit(BaseNode viditedNode)
        {
            viditedNode.HasVisited = true;
            var newNode = new StraightTreeNode { Data = viditedNode.Data, HasVisited = true };
            UpdatePreviousTraversedNode(newNode);

            TraversedNodes.Add(newNode);
        }

        private void UpdatePreviousTraversedNode(StraightTreeNode newNode)
        {
            if (TraversedNodes.Any())
            {
                var lastInsertedNode = TraversedNodes.Last();
                lastInsertedNode.SubNodes.Add(newNode);
            }
        }

        public override bool Equals(object obj)
        {
            return ToString().Equals( ((AccumulatePathAsNodeVisitor)obj).ToString() );
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return TraversedNodes.ToString();
        }
    }
}
