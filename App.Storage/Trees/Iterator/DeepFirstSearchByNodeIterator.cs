using System;
using System.Linq.Expressions;
using Trees.Node;

namespace Trees.Iterator
{
    public class DeepFirstSearchByNodeIterator
    {
        public INode FindNode(INode startNode, Expression<Func<INode, bool>> predicate)
        {
            if (predicate.Compile().Invoke(startNode))
                return startNode;

            foreach (var sub in startNode.SubNodes)
                return FindNode(startNode: sub, predicate);

            return null;
        }
    }
}
