using System.Collections.Generic;
using Trees.Accumulator;
using Trees.Visitor;

namespace Trees
{
    public class BaseNode
    {
        public BaseNode Parent { get; protected set; }
        public IList<BaseNode> SubNodes { get; protected set; }
        public char Data { get; set; }
        public bool HasVisited { get; set; }

        public BaseNode()
        {
            SubNodes = new List<BaseNode>();
        }
        public void AppendSub(BaseNode newSubNode)
        {
            newSubNode.Parent = this;
            SubNodes.Add(newSubNode);
        }

        public int CountOverallSubNode()
        {
            var accumulator = new CollectivelyAccumulator();
            var visitor = new CounterVisitor();
            accumulator.Accumulate(this, node => !node.HasVisited, visitor);

            return visitor.Counter;
        }

        public override bool Equals(object obj)
        {
            return Data.Equals(((BaseNode)obj).Data);
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
