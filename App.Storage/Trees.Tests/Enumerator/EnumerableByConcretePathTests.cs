using System.Collections.Generic;
using System.Linq;
using Trees.Enumerable;
using Trees.Factory;
using Xunit;

namespace Trees.Tests
{
    public class EnumerableByConcretePathTests
    {
        [Fact]
        public void Should_traverse_concrete_node_success()
        {
            var factory = new ChainFactory();
            var startTraversePath = factory.Create("7890");
            var headNode = factory.Create("12345");
            var subNode1 = factory.Create("7890");
            var subNode2 = factory.Create("0543");

            headNode.AppendSub(subNode1);
            headNode.AppendSub(subNode2);

            var visited = new List<Node>();
            var enumerable = new EnumerableByConcretePath(headNode, startTraversePath);
            foreach (Node node in enumerable)
                visited.Add(node);

            Assert.Equal(visited.Count, startTraversePath.OverallSubNodeCount);
        }

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

            var enumerable = new EnumerableByConcretePath(treeHead, traversePathHead);
            var enumerator = enumerable.GetEnumerator();
            while (enumerator.MoveNext()) { }

            var expected = subTreeA // 1
                                .SubNodes.FirstOrDefault() //2
                                .SubNodes.FirstOrDefault(); //3

            Assert.Equal(expected, enumerator.Current);
            Assert.Equal(expected.OverallSubNodeCount, ((Node)enumerator.Current).OverallSubNodeCount);
        }
    }
}
