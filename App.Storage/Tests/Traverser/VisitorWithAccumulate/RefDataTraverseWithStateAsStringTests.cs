using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;

namespace Storage.Tests.Traverser.VisitorWithAccumulate
{
    public class RefDataTraverseWithStateAsStringTests
    {
        [Fact]
        public void Accumulate_traverse_when_tree_is_line_should_accumulate()
        {
            var factory = new RefDataFactory();

            var nodeA = factory.Create("0123456789");
            var nodeB = factory.Create("8888");

            nodeA.SubNodes.First()//node 1
                 .SubNodes.First()//node 2
                 .SubNodes.First()//node 3
                 .AppendSub(nodeB);

            var visitor = factory.CreateAccumulateVisitorWithStateAsString();
            var traverser = new RefDataDownsideAccumulateTraverseWithBranchPathAsString("0123456789");

            traverser.Traverse(nodeA, visitor);

            var expected = "0123456789";

            Assert.Equal(expected, visitor.GetState().ToString());
        }
    }
}
