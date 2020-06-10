using Xunit;

namespace Trees.Tests
{
    public class NodeTests
    {
        [Fact]
        public void Should_return_correct_subnodes_count()
        {
            var factory = new TreeFactory();
            var patternA = "0123";
            var patternB =     "456789";
            var headA = factory.CreateStraightTree(patternA);
            var headB = factory.CreateStraightTree(patternB);
            headA.AppendSub(headB);
            
            var result = headA.CountOverallSubNode();
            var expected = 10;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Should_return_correct_subnodes_count_case_two()
        {
            var factory = new TreeFactory();
            var patternA = "0123";
            var patternAAppendix = "873";
            var patternB = "456789";
            var headA = factory.CreateStraightTree(patternA);
            var headAAppendix = factory.CreateStraightTree(patternAAppendix);
            var headB = factory.CreateStraightTree(patternB);

            headA.AppendSub(headB);
            headA.AppendSub(headAAppendix);

            var result = headA.CountOverallSubNode();
            var expected = 13;

            Assert.Equal(expected, result);
        }
    }
}
