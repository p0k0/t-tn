using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trees.Enumerable;
using Trees.Factory;
using Xunit;

namespace Trees.Tests
{
    public class EnumerableByBreadthFindSearchTests
    {
        [Fact]
        public void Should_traverse_all_node_success()
        {
            var factory = new ChainFactory();
            var headNode = factory.Create("12345");
            var subNode = factory.Create("7890");
            headNode.AppendSub(subNode);

            var visited = new List<Node>();
            var enumerable = new EnumerableTreeByBFS(headNode);
            foreach (Node node in enumerable)
                visited.Add(node);

            Assert.Equal(visited.Count, enumerable.Count());
        }

        [Fact]
        public void Should_travesed_path_that_present_all_tree()
        {
            var factory = new ChainFactory();

            var treeHead = factory.Create("0");
            var subTreeA = factory.Create("123");
            var subTreeB = factory.Create("453");

            treeHead.AppendSub(subTreeA);
            treeHead.AppendSub(subTreeB);

            var enumerable = new EnumerableTreeByBFS(treeHead);
            var buffer = new StringBuilder();
            foreach (Node node in enumerable)
            {
                buffer.Append(node.Data);
            }


            var expectedPath1 = "0142533";
            var expectedPath2 = "0415233";
            var expected = new List<string> { expectedPath1, expectedPath2 };

            Assert.Contains(expected, x => x == buffer.ToString());
        }
    }
}
