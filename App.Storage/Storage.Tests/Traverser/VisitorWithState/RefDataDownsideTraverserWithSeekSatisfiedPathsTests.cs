using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Storage.Tests.Traverser.VisitorWithState
{
    public class RefDataDownsideTraverserWithSeekSatisfiedPathsTests
    {
        [Fact]
        public void Accumulating_paths_traverser_when_traverse_done_should_contain_posible_paths()
        {
            var factory = new RefDataFactory();

            var nodeA = factory.Create("0123456789");
            var nodeB = factory.Create("8888");

            nodeA.SubNodes.First()//node 1
                 .SubNodes.First()//node 2
                 .SubNodes.First()//node 3
                 .AppendSub(nodeB);

            var targetPathForTraverse = factory.Create("0123");
            var traverser = new RefDataDownsideTraverserWithSeekSatisfiedPaths(targetPathForTraverse);

            traverser.Traverse(nodeA);

            var expected = new List<StringBuilder> 
            {
                new StringBuilder("01238888"),
                new StringBuilder("0123456789"),
            };

            Assert.Equal(expected[0].ToString(), traverser.GetTraversedPaths()[0].ToString());
            Assert.Equal(expected[1].ToString(), traverser.GetTraversedPaths()[1].ToString());
        }

        [Fact]
        public void Accumulating_paths_traverser_when_traverse_done_should_contain_posible_paths_complex_case_1()
        {
            var factory = new RefDataFactory();

            var nodeA = factory.Create("0123456");
            var nodeB = factory.Create("8888");
            var nodeA2 = factory.Create("7");

            nodeA.SubNodes.First()//node 1
                 .SubNodes.First()//node 2
                 .SubNodes.First()//node 3
                 .AppendSub(nodeB);

            nodeA.AppendSub(nodeA2);

            var targetPathForTraverse = factory.Create("0123");
            var traverser = new RefDataDownsideTraverserWithSeekSatisfiedPaths(targetPathForTraverse);

            traverser.Traverse(nodeA);

            var expected = new List<StringBuilder>
            {
                new StringBuilder("01238888"),
                new StringBuilder("0123456"),
                new StringBuilder("01234567"),
            };

            Assert.Equal(expected[0].ToString(), traverser.GetTraversedPaths()[0].ToString());
            Assert.Equal(expected[1].ToString(), traverser.GetTraversedPaths()[1].ToString());
            Assert.Equal(expected[2].ToString(), traverser.GetTraversedPaths()[2].ToString());
        }
    }
}
