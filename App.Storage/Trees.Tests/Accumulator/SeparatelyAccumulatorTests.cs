﻿using System.Linq;
using Trees.Accumulator;
using Trees.Visitor;
using Xunit;

namespace Trees.Tests.Accumulator
{
    public class SeparatelyAccumulatorTests
    {
        [Fact]
        public void Separately_accumulate_should_fill_each_visited_brach_with_they_own_visitor_that_will_contain_traversed_path()
        {
            var factory = new TreeFactory();
            var iterator = new SeparatelyAccumulator();
            var visitor = new AccumulateVisitor();

            var treeHead = factory.CreateStraightTree("0");
            var subTreeA = factory.CreateStraightTree("123");
            var subTreeB = factory.CreateStraightTree("453");

            treeHead.AppendSub(subTreeA);
            treeHead.AppendSub(subTreeB);

            var filledVisitors = iterator.Accumulate(treeHead, node => !node.HasVisited, visitor).ToList();
            Assert.Equal(2, filledVisitors.Count);
            Assert.Contains(new AccumulateVisitor("0123"), filledVisitors);
            Assert.Contains(new AccumulateVisitor("0453"), filledVisitors);
        }
    }
}