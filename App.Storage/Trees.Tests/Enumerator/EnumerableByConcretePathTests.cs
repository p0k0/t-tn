using System.Collections.Generic;
using System.Linq;
using Trees.Enumerable;
using Trees.Factory;
using Trees;
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
            var enumerable = new EnumerableTreeBySpecifiedPath(headNode, startTraversePath);
            var enumerator = enumerable.GetEnumerator();
            while(enumerator.MoveNext()) { visited.Add(enumerator.Current); }
            
            Assert.True(enumerator.IsDestinationReached);
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

            var enumerable = new EnumerableTreeBySpecifiedPath(treeHead, traversePathHead);
            var enumerator = enumerable.GetEnumerator();
            while (enumerator.MoveNext()) { }

            var expected = subTreeA // 1
                                .SubNodes.FirstOrDefault() //2
                                .SubNodes.FirstOrDefault(); //3
            var expectedEnumerable = new EnumerableTreeByDFS(expected);

            Assert.Equal(expected, enumerator.Current);
        }
    }
}
