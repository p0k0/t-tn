using System.Collections.Generic;
using Trees.Enumerator;
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
    }
}
