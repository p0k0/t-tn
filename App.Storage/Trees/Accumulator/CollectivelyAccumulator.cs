﻿using System;
using System.Linq.Expressions;
using Trees.Visitor;

namespace Trees.Accumulator
{
    public class CollectivelyAccumulator
    {
        public void Accumulate(BaseNode startNode, Expression<Func<BaseNode, bool>> predicate, IVisitor accumulateVisitor)
        {
            accumulateVisitor.Visit(startNode);

            if (predicate.Compile().Invoke(startNode))
                return;

            foreach (var sub in startNode.SubNodes)
                Accumulate(startNode: sub, predicate, accumulateVisitor);
        }
    }
}
