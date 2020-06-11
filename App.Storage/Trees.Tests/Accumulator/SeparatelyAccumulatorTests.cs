using System.Linq;
using Trees.Accumulator;
using Trees.Factory;
using Trees.Visitor;
using Xunit;

namespace Trees.Tests.Accumulator
{
    public class SeparatelyAccumulatorTests
    {
        [Fact]
        public void Separately_accumulate_with_three_args_should_fill_each_visited_brach_with_they_own_visitor_that_will_contain_traversed_path()
        {
            var factory = new ChainFactory();
            var treeHead = factory.Create("0");
            var subTreeA = factory.Create("123");
            var subTreeB = factory.Create("453");

            treeHead.AppendSub(subTreeA);
            treeHead.AppendSub(subTreeB);

            var accumulator = new SubBranchesAccumulator();
            var visitor = new AccumulatePathAsStringVisitor();
            accumulator.Accumulate(treeHead, visitor);

            Assert.Equal(2, accumulator.Visitors.Count);
            Assert.Contains(new AccumulatePathAsStringVisitor("0123"), accumulator.Visitors);
            Assert.Contains(new AccumulatePathAsStringVisitor("0453"), accumulator.Visitors);
        }

        [Fact]
        public void Separately_accumulate_with_two_args_should_fill_each_visited_brach_with_they_own_visitor_that_will_contain_traversed_path()
        {
            var factory = new ChainFactory();

            var treeHead = factory.Create("0");
            var subTreeA = factory.Create("123");
            var subTreeB = factory.Create("453");

            treeHead.AppendSub(subTreeA);
            treeHead.AppendSub(subTreeB);

            var accumulator = new SubBranchesAccumulator();
            accumulator.Accumulate(treeHead, new AccumulatePathAsStringVisitor());

            Assert.Equal(2, accumulator.Visitors.Count);
            Assert.Contains(new AccumulatePathAsStringVisitor("0123"), accumulator.Visitors);
            Assert.Contains(new AccumulatePathAsStringVisitor("0453"), accumulator.Visitors);
        }
    }
}
