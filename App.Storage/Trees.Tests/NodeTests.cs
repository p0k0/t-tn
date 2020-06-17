using System.Linq;
using Trees.Enumerable;
using Trees.Factory;
using Xunit;

namespace Trees.Tests
{
    public class NodeTests
    {
        [Fact]
        public void Should_return_correct_subnodes_count()
        {
            var factory = new ChainFactory();
            var patternA = "0123";
            var patternB = "456789";
            var headA = factory.Create(patternA);
            var headB = factory.Create(patternB);
            headA.AppendSub(headB);

            var treeHeadA = new EnumerableTreeByDFS(headA);

            var result = treeHeadA.Count();
            var expected = 10;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Should_return_correct_subnodes_count_case_two()
        {
            var factory = new ChainFactory();
            var patternA = "0123";
            var patternAAppendix = "873";
            var patternB = "456789";
            var headA = factory.Create(patternA);
            var headAAppendix = factory.Create(patternAAppendix);
            var headB = factory.Create(patternB);

            headA.AppendSub(headB);
            headA.AppendSub(headAAppendix);
            var treeHeadA = new EnumerableTreeByDFS(headA);
            var result = treeHeadA.Count();
            var expected = 13;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Two_node_with_same_data_should_be_equal()
        {
            var node1 = new Node() { Data = '1' };
            var node2 = new Node() { Data = '1' };

            Assert.Equal(node1, node2);
        }

        [Fact]
        public void Two_node_with_different_data_should_be_unequal()
        {
            var node1 = new Node() { Data = '1' };
            var node2 = new Node() { Data = '2' };

            Assert.NotEqual(node1, node2);
        }
    }
}
