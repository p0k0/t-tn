using System.Linq;
using Trees.Accumulator;
using Trees.Factory;
using Trees.Visitor;
using Xunit;

namespace Trees.Tests.Iterator
{
    public class AccumulateNodeIteratorTests
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

            var iterator = new AccumulateNodeIterator();
            iterator.FindLastSatisfiedNode(treeHead, traversePathHead);
            var searchResult = iterator.Visitor.TraversedNodes.Last();
            var expected = new Trees.Node { Data = '3' };

            Assert.Equal(expected, searchResult);
        }

        [Fact]
        public void Should_find_node_when_tree_with_branches_and_duplicate_node_data()
        {
            var factory = new ChainFactory();
            var iterator = new AccumulateNodeIterator();

            var treeHead = factory.Create("0");
            var subTreeA = factory.Create("123");
            var subTreeB = factory.Create("453");

            treeHead.AppendSub(subTreeA);
            treeHead.AppendSub(subTreeB);

            var traversePathHead = factory.Create("123");

            iterator.FindLastSatisfiedNode(treeHead, traversePathHead);
            var searchResult = iterator.Visitor.TraversedNodes.Last();
            var expected = new Trees.Node { Data = '3' };

            Assert.Equal(expected, searchResult);
        }

        [Fact]
        public void Should_not_find_node_when_target_node_does_not_exists()
        {
            var factory = new ChainFactory();
            var iterator = new AccumulateNodeIterator();

            var treeHead = factory.Create("0");
            var subTreeA = factory.Create("1234");
            var subTreeB = factory.Create("4578");

            treeHead.AppendSub(subTreeA);
            treeHead.AppendSub(subTreeB);

            var traversePathHead = factory.Create("457");

            var targetNode = new Trees.Node { Data = '9' };
            iterator.FindLastSatisfiedNode(treeHead, traversePathHead);
            var searchResult = iterator.Visitor.TraversedNodes.Last();
            var expected = new Trees.Node { Data = '7' };

            Assert.NotEqual(expected, targetNode);
        }

        [Fact]
        public void Should_return_last_equal_node_at_traverse_path_when_target_node_does_not_exists()
        {
            var factory = new ChainFactory();
            var iterator = new AccumulateNodeIterator();

            var treeHead = factory.Create("0");
            var subTreeA = factory.Create("1234");
            var subTreeB = factory.Create("4578");

            treeHead.AppendSub(subTreeA);
            treeHead.AppendSub(subTreeB);

            var traversePathHead = factory.Create("457");

            var targetNode = new Trees.Node { Data = '9' };
            iterator.FindLastSatisfiedNode(treeHead, traversePathHead);
            var searchResult = iterator.Visitor.TraversedNodes.Last();
            var expected = new Trees.Node { Data = '7' };

            Assert.Equal(expected, searchResult);
        }
    }
}
