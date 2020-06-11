using Trees.Factory;
using Trees.Iterator;
using Xunit;

namespace Trees.Tests.Iterator
{
    public class TraverseSubNodeByPathIteratorTests
    {
        [Fact]
        public void Should_find_node_when_tree_with_branches()
        {
            var factory = new ChainFactory();

            var treeHead = factory.Create("0");
            var subTreeA = factory.Create("123");
            var subTreeB = factory.Create("456");

            treeHead.AppendSub(subTreeA);
            treeHead.AppendSub(subTreeB);

            var traversePathHead = factory.Create("123");

            var iterator = new TraverseSubNodeByPathIterator();
            iterator.Traverse(treeHead, traversePathHead);
            var expected = subTreeA.SubNodes[0] //2
                                   .SubNodes[0]; //3

            Assert.Equal(expected, iterator.LastTraversedNode);
            Assert.Equal(expected.OverallSubNodeCount, iterator.LastTraversedNode.OverallSubNodeCount);
        }
    }
}
