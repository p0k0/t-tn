using System.Linq;


namespace Trees.Iterator
{
    public class TraverseSubNodeByPathIterator
    {
        public Node LastTraversedNode { get; protected set; }
        public Node TraverseRemainder { get; protected set; }

        public void Traverse(Node startNode, Node straightTraversePathHead)
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
