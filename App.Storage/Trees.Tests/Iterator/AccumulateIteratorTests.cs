using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trees.Iterator;
using Trees.Visitor;
using Xunit;

namespace Trees.Tests.Iterator
{
    public class AccumulateIteratorTests
    {
        [Fact]
        public void Should_fill_visitor_travesed_path_that_present_first_satisfied_result()
        {
            var factory = new TreeFactory();
            var iterator = new AccumulateIterator();
            var visitor = new AccumulateVisitor();

            var treeHead = factory.CreateStraightTree("0");
            var subTreeA = factory.CreateStraightTree("123");
            var subTreeB = factory.CreateStraightTree("453");

            treeHead.AppendSub(subTreeA);
            treeHead.AppendSub(subTreeB);

            var lastSatisfiedNode = iterator.Accumulate(treeHead, node => !node.SubNodes.Any(), visitor);
            var expectedNode = new Node { Data = '3' };
            var expectedPath = "0123";

            Assert.Equal(expectedNode, lastSatisfiedNode);
            Assert.Contains(expectedPath, visitor.TraversedPath.ToString());
        }


    }
}
