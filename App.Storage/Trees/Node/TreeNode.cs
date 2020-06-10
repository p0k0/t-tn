using System.Collections.Generic;
using System.Linq;
using Trees.Accumulator;
using Trees.Node;
using Trees.Visitor;

namespace Trees
{
    public class TreeNode : INode
    {
        public INode Parent { get; set; }
        public IList<INode> SubNodes { get; set; }
        public char Data { get; set; }
        public bool HasVisited { get; set; }

        public TreeNode()
        {
            SubNodes = new List<INode>();
        }

        public virtual void AppendSub(INode newSubNode)
        {
            if (newSubNode == null)
                return;

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
            return Data.Equals(((TreeNode)obj).Data);
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
