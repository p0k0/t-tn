using System;
using System.Linq.Expressions;

namespace Trees
{
    public class DeepFirstSearchByNodeIterator
    {
        public Node Find(Node startNode, Expression<Func<Node, bool>> predicate)
        {
            if (!startNode.HasVisited && predicate.Compile().Invoke(startNode))
            {
                startNode.HasVisited = true;
                return startNode;
            }

            foreach (var sub in startNode.SubNodes)
                return Find(startNode: sub, predicate);

            return null;
        }
    }
}
