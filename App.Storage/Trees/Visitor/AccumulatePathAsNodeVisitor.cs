using System.Collections.Generic;
using System.Linq;
using Trees.Node;

namespace Trees.Visitor
{
    public class AccumulatePathAsNodeVisitor : IVisitor
    {
        public IList<ChainNode> TraversedNodes { get; set; }

        public AccumulatePathAsNodeVisitor()
        {
            TraversedNodes = new List<ChainNode>();
        }

        public void Visit(INode viditedNode)
        {
            var newNode = new ChainNode { Data = viditedNode.Data };
            UpdatePreviousTraversedNode(newNode);

            TraversedNodes.Add(newNode);
        }

        private void UpdatePreviousTraversedNode(ChainNode newNode)
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
