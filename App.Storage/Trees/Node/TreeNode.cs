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

        private int CountOverallSubNode()
        {
            var accumulator = new DeepFindSearchAccumulator();
            var visitor = new CounterVisitor();
            accumulator.Accumulate(this, visitor);

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
