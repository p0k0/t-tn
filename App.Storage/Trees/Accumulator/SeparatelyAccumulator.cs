using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Trees.Visitor;

namespace Trees.Accumulator
{
    public class SeparatelyAccumulator
    {
        private IVisitor _initialAccumulator;

        public SeparatelyAccumulator()
        {
            _initialAccumulator = new AccumulateVisitor();
        }

        public IEnumerable<IVisitor> Accumulate(Node startNode, Expression<Func<Node, bool>> predicate)
        {
            _initialAccumulator.Visit(startNode);

            if (predicate.Compile().Invoke(startNode))
                yield return _initialAccumulator;

            if (startNode.SubNodes.Count == 0)
                yield return _initialAccumulator;

            if (startNode.SubNodes.Count == 1)
                yield return Accumulate(startNode.SubNodes.Single(), predicate, _initialAccumulator).Single();

            if (startNode.SubNodes.Count > 1)
            {
                foreach (var sub in startNode.SubNodes)
                    yield return Accumulate(sub, predicate, new AccumulateVisitor(_initialAccumulator)).Single();
            }
        }

        public IEnumerable<IVisitor> Accumulate(Node startNode, Expression<Func<Node, bool>> predicate, IVisitor accumulateVisitor)
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
