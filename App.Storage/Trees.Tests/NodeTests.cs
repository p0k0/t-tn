using Trees.Factory;
using Xunit;

namespace Trees.Tests
{
    public class NodeTests
    {
        [Fact]
        public void Should_return_correct_subnodes_count()
        {
            var factory = new ChainFactory();
            var patternA = "0123";
            var patternB = "456789";
            var headA = factory.Create(patternA);
            var headB = factory.Create(patternB);
            headA.AppendSub(headB);

            var result = headA.OverallSubNodeCount;
            var expected = 10;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Should_return_correct_subnodes_count_case_two()
        {
            var factory = new ChainFactory();
            var patternA = "0123";
            var patternAAppendix = "873";
            var patternB = "456789";
            var headA = factory.Create(patternA);
            var headAAppendix = factory.Create(patternAAppendix);
            var headB = factory.Create(patternB);

            headA.AppendSub(headB);
            headA.AppendSub(headAAppendix);

            var result = headA.OverallSubNodeCount;
            var expected = 13;

            Assert.Equal(expected, result);
        }
    }
}
