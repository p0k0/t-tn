using System.Linq;
using Xunit;

namespace Trees.Tests.Iterator
{
    public class DeepFirstSearchByNodeIteratorTests
    {
        [Fact]
        public void Should_find_node_when_it_possible()
        {
            var factory = new TreeFactory();
            var iterator = new DeepFirstSearchByNodeIterator();

            var treeHead = factory.CreateStraightTree("01234");
            var searchResult = iterator.FindNode(treeHead, node => node.Data == '3');
            var expected = new BaseNode { Data = '3' };

            Assert.Equal(expected, searchResult);
        }

        [Fact]
        public void Should_find_node_when_tree_with_branches()
        {
            var factory = new TreeFactory();
            var iterator = new DeepFirstSearchByNodeIterator();

            var treeHead = factory.CreateStraightTree("0");
            var subTreeA = factory.CreateStraightTree("123");
            var subTreeB = factory.CreateStraightTree("456");

            treeHead.AppendSub(subTreeA);
            treeHead.AppendSub(subTreeB);

            var searchResult = iterator.FindNode(treeHead, node => node.Data == '3');
            var expected = new BaseNode { Data = '3' };

            Assert.Equal(expected, searchResult);
        }

        [Fact]
        public void Should_find_node_when_tree_with_branches_and_duplicate_node_data()
        {
            var factory = new TreeFactory();
            var iterator = new DeepFirstSearchByNodeIterator();

            var treeHead = factory.CreateStraightTree("0");
            var subTreeA = factory.CreateStraightTree("123");
            var subTreeB = factory.CreateStraightTree("453");

            treeHead.AppendSub(subTreeA);
            treeHead.AppendSub(subTreeB);

            var searchResult = iterator.FindNode(treeHead, node => node.Data == '3');
            var expected = new BaseNode { Data = '3' };

            Assert.Equal(expected, searchResult);
        }

        [Fact]
        public void Should_find_all_leaf_node()
        {
            var factory = new TreeFactory();
            var iterator = new DeepFirstSearchByNodeIterator();

            var treeHead = factory.CreateStraightTree("0");
            var subTreeA = factory.CreateStraightTree("123");
            var subTreeB = factory.CreateStraightTree("456");

            treeHead.AppendSub(subTreeA);
            treeHead.AppendSub(subTreeB);

            var searchResult = iterator.FindNode(treeHead, node => !node.SubNodes.Any());
            var expected = new BaseNode { Data = '3' };

            Assert.Equal(expected, searchResult);
        }
    }
}
