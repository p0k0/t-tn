using Trees.Factory;
using Trees.Iterator;
using Xunit;

namespace Trees.Tests.Iterator
{
    public class ChainMinusIteratorTests
    {
        [Fact]
        public void Minus_should_work_correct()
        {
            var factory = new ChainFactory();
            var chainA = factory.Create("012345678");
            var chainB = factory.Create("01234");

            var minusIterator = new ChainMinusIterator();
            var resultHead = minusIterator.Minus(chainA, chainB);
            var expected = factory.Create("5678");

            Assert.Equal(expected, resultHead);
        }
    }
}
