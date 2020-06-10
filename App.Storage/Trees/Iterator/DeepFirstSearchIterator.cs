using System;
using System.Linq.Expressions;

namespace Trees
{
    public class DeepFirstSearchIterator
    {
        public Node Find(Node startNode, Expression<Func<Node, bool>> predicate)
        {
            if (predicate.Compile().Invoke(startNode))
                return startNode;

            foreach (var sub in startNode.SubNodes)
                return Find(startNode: sub, predicate);

            return null;
        }
    }
}
