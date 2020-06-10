using System.Linq;
using Trees.Accumulator;
using Trees.Visitor;
using Xunit;

namespace Trees.Tests.Accumulator
{
    public class SeparatelyAccumulatorTests
    {
        [Fact]
        public void Separately_accumulate_with_three_args_should_fill_each_visited_brach_with_they_own_visitor_that_will_contain_traversed_path()
        {
            var factory = new TreeFactory();
            var accumulator = new SeparatelyAccumulator();
            var visitor = new AccumulatePathAsStringVisitor();

            var treeHead = factory.CreateStraightTree("0");
            var subTreeA = factory.CreateStraightTree("123");
            var subTreeB = factory.CreateStraightTree("453");

            treeHead.AppendSub(subTreeA);
            treeHead.AppendSub(subTreeB);

            var filledVisitors = accumulator.Accumulate(treeHead, node => !node.HasVisited, visitor).ToList();
            Assert.Equal(2, filledVisitors.Count);
            Assert.Contains(new AccumulatePathAsStringVisitor("0123"), filledVisitors);
            Assert.Contains(new AccumulatePathAsStringVisitor("0453"), filledVisitors);
        }

        [Fact]
        public void Separately_accumulate_with_two_args_should_fill_each_visited_brach_with_they_own_visitor_that_will_contain_traversed_path()
        {
            var factory = new TreeFactory();
            var accumulator = new SeparatelyAccumulator();

            var treeHead = factory.CreateStraightTree("0");
            var subTreeA = factory.CreateStraightTree("123");
            var subTreeB = factory.CreateStraightTree("453");

            treeHead.AppendSub(subTreeA);
            treeHead.AppendSub(subTreeB);

            var filledVisitors = accumulator.Accumulate(treeHead, node => !node.HasVisited, new AccumulatePathAsStringVisitor()).ToList();
            Assert.Equal(2, filledVisitors.Count);
            Assert.Contains(new AccumulatePathAsStringVisitor("0123"), filledVisitors);
            Assert.Contains(new AccumulatePathAsStringVisitor("0453"), filledVisitors);
        }
    }
}
