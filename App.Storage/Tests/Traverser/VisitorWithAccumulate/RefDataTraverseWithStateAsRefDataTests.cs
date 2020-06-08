using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;

namespace Storage.Tests.Traverser.VisitorWithAccumulate
{
    public class RefDataTraverseWithStateAsRefDataTests
    {
        [Fact]
        public void Accumulate_traverse_with_straight_source_branch_should_accumulate()
        {
            var factory = new RefDataFactory();

            var nodeA = factory.Create("0123456789");
            var nodeB = factory.Create("8888");

            nodeA.SubNodes.First()//node 1
                 .SubNodes.First()//node 2
                 .SubNodes.First()//node 3
                 .AppendSub(nodeB);

            var target = factory.Create("012388");
            var visitor = factory.CreateAccumulateVisitorWithStateAsString();
            var traverser = new RefDataDownsideAccumulateTraverseWithStraightBranch(target);

            traverser.Traverse(nodeA, visitor);

            var expected = "012388";

            Assert.Equal(expected, visitor.GetState().ToString());
        }
    }
}
