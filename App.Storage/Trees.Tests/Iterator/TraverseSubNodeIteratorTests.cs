using Trees.Factory;
using Trees.Iterator;
using Trees.Visitor;
using Xunit;

namespace Trees.Tests.Iterator
{
    public class TraverseSubNodeIteratorTests
    {
        [Fact]
        public void Collectively_accumulate_should_fill_visitor_travesed_path_that_present_all_tree()
        {
            var factory = new ChainFactory();
            var visitor = new AccumulatePathAsStringVisitor();

            var treeHead = factory.Create("0");
            var subTreeA = factory.Create("123");
            var subTreeB = factory.Create("453");

            treeHead.AppendSub(subTreeA);
            treeHead.AppendSub(subTreeB);

            var accumulator = new TraverseSubNodeIterator(visitor);
            accumulator.Accumulate(treeHead);

            var expectedPath = "0123453";

            Assert.Equal(expectedPath, visitor.TraversedPath.ToString());
        }
    }
}
