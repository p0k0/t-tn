using Trees.Factory;
using Xunit;

namespace Trees.Tests.Iterator
{
    public class DeepFirstSearchByPathIterator2Tests
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

            var iterator = new DeepFirstSearchByPathIterator2();
            iterator.FindLastSatisfiedNode(treeHead, traversePathHead);
            var expected = subTreeA.SubNodes[0] //2
                                   .SubNodes[0]; //3

            Assert.Equal(expected, iterator.Result);
            Assert.Equal(expected.OverallSubNodeCount, iterator.Result.OverallSubNodeCount);
        }
    }
}
