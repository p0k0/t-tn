using Storage;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;

namespace Storage.Tests
{
    public class RefDataTraverseTests
    {
        [Fact]
        public void Conditional_traverse_should_find_target_node()
        {
            var factory = new RefDataFactory();
            var node = factory.Create("0123456789");
            var target = factory.Create('7');
            var visitor = new FindVisitor(target);
            var traverser = new RefDataDownsideTraverseWithCondition();

            var traversResult = traverser.Traverse(node, visitor);

            Assert.True(traversResult);
        }

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

            var visitor = new AccumulateVisitor();
            var traverser = new RefDataDownsideAccumulateTraverseWithBranch("0123456789");

            traverser.Traverse(nodeA, visitor);

            var expected = "0123456789";

            Assert.Equal(expected, visitor.GetTraversedPath());
        }

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
            var visitor = new AccumulateVisitor();
            var traverser = new RefDataDownsideAccumulateTraverseWithStraightBranch(target);

            traverser.Traverse(nodeA, visitor);

            var expected = "012388";

            Assert.Equal(expected, visitor.GetTraversedPath());
        }
    }
}
