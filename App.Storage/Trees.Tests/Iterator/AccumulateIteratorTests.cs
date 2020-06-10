using System.Linq;
using Trees.Iterator;
using Trees.Visitor;
using Xunit;

namespace Trees.Tests.Iterator
{
    public class AccumulateIteratorTests
    {
        [Fact]
        public void Should_fill_visitor_travesed_path_that_present_all_tree()
        {
            var factory = new TreeFactory();
            var iterator = new AccumulateIterator();
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
