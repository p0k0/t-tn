using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trees.Enumerable;
using Trees.Enumerator;
using Trees.Enumerator.Specified;
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
            var enumerable = new EnumerableTreeByDFS(headNode);
            foreach (Node node in enumerable)
                visited.Add(node);

            Assert.Equal(visited.Count, headNode.OverallSubNodeCount);
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

            var enumerable = new EnumerableTreeByDFS(treeHead);
            var buffer = new StringBuilder();
            foreach (Node node in enumerable)
            {
                buffer.Append(node.Data);
            }


            var expectedPath1 = "0123453";
            var expectedPath2 = "0453123";
            var expected = new List<string> { expectedPath1, expectedPath2 };

            Assert.Contains(expected, x => x == buffer.ToString());
        }

        [Fact]
        public void Able_accumulate_all_paths()
        {
            var factory = new ChainFactory();

            var treeHead = factory.Create("0");
            var subTreeA = factory.Create("123");
            var subTreeB = factory.Create("453");

            treeHead.AppendSub(subTreeA);
            treeHead.AppendSub(subTreeB);

            var accumulator = new PathAccumulator();

            var enumerable = new EnumeratorAccumulatingBranches(treeHead, accumulator);

            while (enumerable.MoveNext()) { }

            var expected = new List<string> { "0123", "0453" };

            Assert.Equal(2, accumulator.Paths.Count);
            Assert.Contains(expected[0], accumulator.Paths);
            Assert.Contains(expected[1], accumulator.Paths);
        }
    }
}
