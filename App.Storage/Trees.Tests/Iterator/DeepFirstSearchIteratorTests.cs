using Xunit;

namespace Trees.Tests.Iterator
{
    public class DeepFirstSearchIteratorTests
    {
        [Fact]
        public void Should_find_node_when_it_possible()
        {
            var factory = new TreeFactory();
            var iterator = new DeepFirstSearchIterator();

            var treeHead = factory.CreateStraightTree("01234");
            var searchResult = iterator.Find(treeHead, node => node.Data == '3');
            var expected = new Node { Data = '3' };

            Assert.Equal(expected, searchResult);
        }
    }
}
