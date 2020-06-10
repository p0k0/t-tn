using System.Linq;
using System.Text;
using Trees.Accumulator;
using Trees.Visitor;
using Xunit;

namespace Trees.Tests.Accumulator
{
    public class CollectivelyAccumulatorTests
    {
        [Fact]
        public void Collectively_accumulate_should_fill_visitor_travesed_path_that_present_all_tree()
        {
            var factory = new TreeFactory();
            var iterator = new CollectivelyAccumulator();
            var visitor = new AccumulateVisitor();

            var treeHead = factory.CreateStraightTree("0");
            var subTreeA = factory.CreateStraightTree("123");
            var subTreeB = factory.CreateStraightTree("453");

            treeHead.AppendSub(subTreeA);
            treeHead.AppendSub(subTreeB);

            iterator.Accumulate(treeHead, node => !node.HasVisited, visitor);
            var expectedPath = "0123453";

            Assert.Contains(expectedPath, visitor.TraversedPath.ToString());
        }
    }
}
