using System.Collections.Generic;
using Trees.Iterator;
using Trees.Visitor;

namespace Trees
{
    public class Node
    {
        public Node Parent { get; set; }
        public IList<Node> SubNodes { get; set; }
        public char Data { get; set; }

        private int? _overallSubNodeCount;
        public int OverallSubNodeCount
        {
            get
            {
                if (!_overallSubNodeCount.HasValue)
                {
                    _overallSubNodeCount = CountOverallSubNode();
                }

                return _overallSubNodeCount.Value;
            }
        }

        public Node()
        {
            SubNodes = new List<Node>();
        }

        public virtual void AppendSub(Node newSubNode)
        {
            if (newSubNode == null)
                return;

            newSubNode.Parent = this;
            SubNodes.Add(newSubNode);
        }

        private int CountOverallSubNode()
        {
            var visitor = new CounterVisitor();
            var accumulator = new TraverseSubNodeIterator(visitor);

            accumulator.Accumulate(this);

            return visitor.Counter;
        }

        public override bool Equals(object obj)
        {
            return Data.Equals(((Node)obj).Data);
        }

        public override int GetHashCode()
        {
            return Data.GetHashCode();
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
