﻿using System.Collections.Generic;
using Trees.Node;
using Trees.Visitor;

namespace Trees.Accumulator
{
    public class SubBranchesAccumulator
    {
        public IList<IVisitor> Visitors { get; private set; }

        public SubBranchesAccumulator()
        {
            Visitors = new List<IVisitor>();
        }

        public void Accumulate(INode startNode, IVisitor accumulateVisitor)
        {
            accumulateVisitor.Visit(startNode);

            if (startNode.SubNodes.Count == 0)
                Visitors.Add(accumulateVisitor);

            foreach (var sub in startNode.SubNodes)
                Accumulate(sub, new AccumulatePathAsStringVisitor(accumulateVisitor));
        }
    }
}
