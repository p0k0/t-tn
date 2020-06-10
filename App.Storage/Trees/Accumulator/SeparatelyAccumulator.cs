using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Trees.Node;
using Trees.Visitor;

namespace Trees.Accumulator
{
    public class SeparatelyAccumulator
    {
        public IEnumerable<IVisitor> Accumulate(INode startNode, Expression<Func<INode, bool>> predicate, IVisitor accumulateVisitor)
        {
            accumulateVisitor.Visit(startNode);

            if (predicate.Compile().Invoke(startNode))
                yield return accumulateVisitor;

            if (startNode.SubNodes.Count == 0)
                yield return accumulateVisitor;

            if (startNode.SubNodes.Count == 1)
            {
                foreach (var subResult in Accumulate(startNode.SubNodes.Single(), predicate, accumulateVisitor))
                    yield return subResult;
            }

            if (startNode.SubNodes.Count > 1)
            {
                foreach (var sub in startNode.SubNodes)
                    yield return Accumulate(sub, predicate, new AccumulatePathAsStringVisitor(accumulateVisitor)).Single();
            }
        }
    }
}
