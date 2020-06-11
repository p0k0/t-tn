using System.Linq;
using Trees.Node;
using Trees.Visitor;

namespace Trees.Accumulator
{
    public class AccumulateNodeIterator
    {
        public AccumulatePathAsNodeVisitor Visitor { get; protected set; }

        public AccumulateNodeIterator(AccumulatePathAsNodeVisitor visitor)
        {
            Visitor = visitor;
        }

        public AccumulateNodeIterator() : this(new AccumulatePathAsNodeVisitor())
        {
        }

        public void FindLastSatisfiedNode(INode startNode, INode straightTraversePathHead)
        {
            if (startNode == null)
                return;

            Visitor.Visit(startNode);

            if (straightTraversePathHead == null)
                return;

            var nextStartNode = startNode.SubNodes.Where(x => x.Data == straightTraversePathHead.Data).FirstOrDefault();
            var nextTraversePathNode = straightTraversePathHead.SubNodes.SingleOrDefault();

            FindLastSatisfiedNode(nextStartNode, nextTraversePathNode);
        }
    }
}
