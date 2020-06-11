using System.Linq;
using Trees.Node;

namespace Trees.Iterator
{
    public class TraverseSubNodeByPathIterator
    {
        public INode LastTraversedNode { get; protected set; }
        public INode TraverseRemainder { get; protected set; }

        public void Traverse(INode startNode, INode straightTraversePathHead)
        {
            if (startNode == null)
                return;

            LastTraversedNode = startNode;
            TraverseRemainder = straightTraversePathHead;

            if (straightTraversePathHead == null)
                return;

            var nextStartNode = startNode.SubNodes.Where(x => x.Data == straightTraversePathHead.Data).FirstOrDefault();
            var nextTraversePathNode = straightTraversePathHead.SubNodes.SingleOrDefault();

            Traverse(nextStartNode, nextTraversePathNode);
        }
    }
}
