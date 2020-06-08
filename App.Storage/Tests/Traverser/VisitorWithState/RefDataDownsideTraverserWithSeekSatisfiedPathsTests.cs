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
        public void Accumulating_paths_visitor_when_traverse_done_should_contain_posible_paths()
        {
            var factory = new RefDataFactory();

            var nodeA = factory.Create("0123456789");
            var nodeB = factory.Create("8888");

            nodeA.SubNodes.First()//node 1
                 .SubNodes.First()//node 2
                 .SubNodes.First()//node 3
                 .AppendSub(nodeB);

            var targetPathForTraverse = factory.Create("012388");
            var visitor = factory.CreateVisitorAccumulatingPaths();
            var traverser = new RefDataDownsideTraverserWithSeekSatisfiedPaths(targetPathForTraverse);

            traverser.Traverse(nodeA, visitor);

            var expected = nodeB.SubNodes.Single() //8
                                .SubNodes.Single();//8

            Assert.Equal(expected, visitor.GetState());
        }
    }
}
