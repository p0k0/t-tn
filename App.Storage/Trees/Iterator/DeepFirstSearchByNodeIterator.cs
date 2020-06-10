using System;
using System.Linq.Expressions;

namespace Trees
{
    public class DeepFirstSearchByNodeIterator
    {
        public BaseNode FindNode(BaseNode startNode, Expression<Func<BaseNode, bool>> predicate)
        {
            if (predicate.Compile().Invoke(startNode))
                return startNode;

            foreach (var sub in startNode.SubNodes)
                return FindNode(startNode: sub, predicate);

            return null;
        }
    }
}
