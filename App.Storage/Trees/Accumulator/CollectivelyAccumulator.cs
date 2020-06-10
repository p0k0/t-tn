using System;
using System.Linq.Expressions;
using Trees.Node;
using Trees.Visitor;

namespace Trees.Accumulator
{
    public class CollectivelyAccumulator
    {
        public void Accumulate(INode startNode, Expression<Func<INode, bool>> predicate, IVisitor accumulateVisitor)
        {
            accumulateVisitor.Visit(startNode);

            if (predicate.Compile().Invoke(startNode))
                return;

            foreach (var sub in startNode.SubNodes)
                Accumulate(startNode: sub, predicate, accumulateVisitor);
        }
    }
}
