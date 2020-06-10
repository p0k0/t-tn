using System;
using System.Linq.Expressions;

namespace Trees
{
    public class DeepFirstSearchByNodeIterator
    {
        public Node FindNode(Node startNode, Expression<Func<Node, bool>> predicate)
        {
            if (predicate.Compile().Invoke(startNode))
                return startNode;

            foreach (var sub in startNode.SubNodes)
                return FindNode(startNode: sub, predicate);

            return null;
        }
    }
}
