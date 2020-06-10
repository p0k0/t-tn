﻿using System;
using System.Linq.Expressions;
using Trees.Visitor;

namespace Trees.Iterator
{
    public class AccumulateIterator
    {
        public void Accumulate(Node startNode, Expression<Func<Node, bool>> predicate, AccumulateVisitor accumulateVisitor)
        {
            accumulateVisitor.Visit(startNode);

            if (predicate.Compile().Invoke(startNode))
                return;

            foreach (var sub in startNode.SubNodes)
                Accumulate(startNode: sub, predicate, accumulateVisitor);
        }
    }
}
