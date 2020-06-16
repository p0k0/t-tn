using System;
using System.Collections.Generic;
using System.Text;
using Trees.Enumerator;
using Trees.Factory;
using Xunit;

namespace Trees.Tests
{
    public class EnumerableByDeepFindSearchTests
    {
        [Fact]
        public void Should_traverse_all_node_success()
        {
            var factory = new ChainFactory();
            var headNode = factory.Create("12345");
            var subNode = factory.Create("7890");
            headNode.AppendSub(subNode);

            var visited = new List<Node>();
            var enumerable = new EnumerableByDeepFindSearch(headNode);
            foreach (Node node in enumerable)
                visited.Add(node);

            Assert.Equal(visited.Count, headNode.OverallSubNodeCount);
        }
    }
}
