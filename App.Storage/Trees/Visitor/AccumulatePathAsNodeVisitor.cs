using System.Collections.Generic;
using System.Linq;


namespace Trees.Visitor
{
    public class AccumulatePathAsNodeVisitor : IVisitor
    {
        public IList<Node> TraversedNodes { get; set; }

        public AccumulatePathAsNodeVisitor()
        {
            TraversedNodes = new List<Node>();
        }

        public void Visit(Node viditedNode)
        {
            var newNode = new Node { Data = viditedNode.Data };
            UpdatePreviousTraversedNode(newNode);

            TraversedNodes.Add(newNode);
        }

        private void UpdatePreviousTraversedNode(Node newNode)
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
