using System;
using System.Linq.Expressions;
using Trees.Visitor;

namespace Trees.Iterator
{
    public class AccumulateIterator
    {
        public Node Accumulate(Node startNode, Expression<Func<Node, bool>> predicate, AccumulateVisitor accumulateVisitor)
        {
            accumulateVisitor.Visit(startNode);

            if (predicate.Compile().Invoke(startNode))
                return startNode;

            foreach (var sub in startNode.SubNodes)
                return Accumulate(startNode: sub, predicate, accumulateVisitor);

            return null;
        }
    }
}
