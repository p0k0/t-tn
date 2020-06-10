using System;
using System.Linq;
using System.Linq.Expressions;

namespace Trees
{
    public class DeepFirstSearchByPathIterator
    {
        public Node Find(Node startNode, Expression<Func<Node, bool>> predicate, Node straightTraversePathHead)
        {
            if (predicate.Compile().Invoke(startNode) && 
                straightTraversePathHead != null && 
                !straightTraversePathHead.SubNodes.Any())
                return startNode;

            if (straightTraversePathHead == null)
                return startNode;

            foreach (var sub in startNode.SubNodes.Where(x => x.Data == straightTraversePathHead.Data))
                return Find(startNode: sub, predicate, straightTraversePathHead.SubNodes.SingleOrDefault());

            return null;
        }
    }
}
