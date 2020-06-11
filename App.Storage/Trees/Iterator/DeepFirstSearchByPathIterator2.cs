using System.Linq;
using Trees.Node;

namespace Trees
{
    public class DeepFirstSearchByPathIterator2
    {
        public INode Result { get; protected set; }
        public INode TraverseRemainder { get; protected set; }

        public void FindLastSatisfiedNode(INode startNode, INode straightTraversePathHead)
        {   
            if (startNode == null)
                return;

            Result = startNode;
            TraverseRemainder = straightTraversePathHead;

            if (straightTraversePathHead == null)
                return;

            var nextStartNode = startNode.SubNodes.Where(x => x.Data == straightTraversePathHead.Data).FirstOrDefault();
            var nextTraversePathNode = straightTraversePathHead.SubNodes.SingleOrDefault();

            FindLastSatisfiedNode(nextStartNode, nextTraversePathNode);
        }
    }
}
