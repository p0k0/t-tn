using System.Linq;
using Trees.Factory;
using Xunit;

namespace Trees.Tests.Iterator
{
    public class DeepFirstSearchByNodeIteratorTests
    {
        [Fact]
        public void Should_find_node_when_it_possible()
        {
            var factory = new ChainFactory();
            var iterator = new DeepFirstSearchByNodeIterator();

            var treeHead = factory.Create("01234");
            var searchResult = iterator.FindNode(treeHead, node => node.Data == '3');
            var expected = new TreeNode { Data = '3' };

            Assert.Equal(expected, searchResult);
        }

        [Fact]
        public void Should_find_node_when_tree_with_branches()
        {
            var factory = new ChainFactory();
            var iterator = new DeepFirstSearchByNodeIterator();

            var treeHead = factory.Create("0");
            var subTreeA = factory.Create("123");
            var subTreeB = factory.Create("456");

            treeHead.AppendSub(subTreeA);
            treeHead.AppendSub(subTreeB);

            var searchResult = iterator.FindNode(treeHead, node => node.Data == '3');
            var expected = new TreeNode { Data = '3' };

            Assert.Equal(expected, searchResult);
        }

        [Fact]
        public void Should_find_node_when_tree_with_branches_and_duplicate_node_data()
        {
            var factory = new ChainFactory();

            var treeHead = factory.Create("0");
            var subTreeA = factory.Create("123");
            var subTreeB = factory.Create("453");

            treeHead.AppendSub(subTreeA);
            treeHead.AppendSub(subTreeB);

            var iterator = new DeepFirstSearchByNodeIterator();
            var searchResult = iterator.FindNode(treeHead, node => node.Data == '3');
            var expected = new TreeNode { Data = '3' };

            Assert.Equal(expected, searchResult);
        }

        [Fact]
        public void Should_find_all_leaf_node()
        {
            var factory = new ChainFactory();
            var iterator = new DeepFirstSearchByNodeIterator();

            var treeHead = factory.Create("0");
            var subTreeA = factory.Create("123");
            var subTreeB = factory.Create("456");

            treeHead.AppendSub(subTreeA);
            treeHead.AppendSub(subTreeB);

            var searchResult = iterator.FindNode(treeHead, node => !node.SubNodes.Any());
            var expected = new TreeNode { Data = '3' };

            Assert.Equal(expected, searchResult);
        }
    }
}
