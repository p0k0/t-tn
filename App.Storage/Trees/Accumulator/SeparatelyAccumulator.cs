using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Trees.Visitor;

namespace Trees.Accumulator
{
    public class SeparatelyAccumulator
    {
        public IEnumerable<AccumulateVisitor> Accumulate(Node startNode, Expression<Func<Node, bool>> predicate, AccumulateVisitor accumulateVisitor)
        {
            accumulateVisitor.Visit(startNode);

            if (predicate.Compile().Invoke(startNode))
                yield return accumulateVisitor;

            if (startNode.SubNodes.Count == 0)
                yield return accumulateVisitor;

            if (startNode.SubNodes.Count == 1)
                yield return Accumulate(startNode.SubNodes.Single(), predicate, accumulateVisitor).Single();

            if (startNode.SubNodes.Count > 1)
            {
                foreach (var sub in startNode.SubNodes)
                    yield return Accumulate(sub, predicate, new AccumulateVisitor(accumulateVisitor)).Single();
            }
        }
    }
}
