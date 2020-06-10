using System.Linq;
using Xunit;

namespace Trees.Tests.Iterator
{
    public class DeepFirstSearchByPathIteratorTests
    {
        [Fact]
        public void Should_find_node_when_tree_with_branches()
        {
            var factory = new TreeFactory();
            var iterator = new DeepFirstSearchByPathIterator();

            var treeHead = factory.CreateStraightTree("0");
            var subTreeA = factory.CreateStraightTree("123");
            var subTreeB = factory.CreateStraightTree("456");

            treeHead.AppendSub(subTreeA);
            treeHead.AppendSub(subTreeB);

            var traversePathHead = factory.CreateStraightTree("123");

            iterator.FindLastSatisfiedNode(treeHead, node => node.Data == '3', traversePathHead);
            var searchResult = iterator.Visitor.TraversedNodes.Last();
            var expected = new BaseNode { Data = '3' };

            Assert.Equal(expected, searchResult);
        }

        [Fact]
        public void Should_find_node_when_tree_with_branches_and_duplicate_node_data()
        {
            var factory = new TreeFactory();
            var iterator = new DeepFirstSearchByPathIterator();

            var treeHead = factory.CreateStraightTree("0");
            var subTreeA = factory.CreateStraightTree("123");
            var subTreeB = factory.CreateStraightTree("453");

            treeHead.AppendSub(subTreeA);
            treeHead.AppendSub(subTreeB);

            var traversePathHead = factory.CreateStraightTree("123");

            iterator.FindLastSatisfiedNode(treeHead, node => node.Data == '3', traversePathHead);
            var searchResult = iterator.Visitor.TraversedNodes.Last();
            var expected = new BaseNode { Data = '3' };

            Assert.Equal(expected, searchResult);
        }

        [Fact]
        public void Should_not_find_node_when_target_node_does_not_exists()
        {
            var factory = new TreeFactory();
            var iterator = new DeepFirstSearchByPathIterator();

            var treeHead = factory.CreateStraightTree("0");
            var subTreeA = factory.CreateStraightTree("1234");
            var subTreeB = factory.CreateStraightTree("4578");

            treeHead.AppendSub(subTreeA);
            treeHead.AppendSub(subTreeB);

            var traversePathHead = factory.CreateStraightTree("457");

            var targetNode = new BaseNode { Data = '9' };
            iterator.FindLastSatisfiedNode(treeHead, node => node == targetNode, traversePathHead);
            var searchResult = iterator.Visitor.TraversedNodes.Last();
            var expected = new BaseNode { Data = '7' };

            Assert.NotEqual(expected, targetNode);
        }

        [Fact]
        public void Should_return_last_equal_node_at_traverse_path_when_target_node_does_not_exists()
        {
            var factory = new TreeFactory();
            var iterator = new DeepFirstSearchByPathIterator();

            var treeHead = factory.CreateStraightTree("0");
            var subTreeA = factory.CreateStraightTree("1234");
            var subTreeB = factory.CreateStraightTree("4578");

            treeHead.AppendSub(subTreeA);
            treeHead.AppendSub(subTreeB);

            var traversePathHead = factory.CreateStraightTree("457");

            var targetNode = new BaseNode { Data = '9' };
            iterator.FindLastSatisfiedNode(treeHead, node => node == targetNode, traversePathHead);
            var searchResult = iterator.Visitor.TraversedNodes.Last();
            var expected = new BaseNode { Data = '7' };

            Assert.Equal(expected, searchResult);
        }
    }
}
