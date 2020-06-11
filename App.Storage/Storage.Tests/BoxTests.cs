using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Storage.Tests
{
    public class BoxTests
    {
        [Fact]
        public void Should_find_pattern_when_exists_one_pattern()
        {
            var box = new Box();
            var pattern = "0467123456";
            box.Add(pattern);

            var result = box.Find(pattern).FirstOrDefault();
            var expected = "0467123456";

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Should_find_patterns_when_exists_more_one_pattern()
        {
            var box = new Box();
            var patternA = "0123456789";
            var patternB = "1123456789";
            
            box.Add(patternA);
            box.Add(patternB);

            var foundResultByPatternA = box.Find(patternA).FirstOrDefault();
            var foundResultByPatternB = box.Find(patternB).FirstOrDefault();
            
            var expectedResultA = "0123456789";
            var expectedResultB = "1123456789";

            Assert.Equal(expectedResultA, foundResultByPatternA);
            Assert.Equal(expectedResultB, foundResultByPatternB);
        }

        [Fact]
        public void Should_find_patterns_when_exists_more_one_pattern_with_equal_leading_part()
        {
            var box = new Box();
            var leadingPart = "0123";
            
            var patternA = $"{leadingPart}";
            var patternB = $"{leadingPart}456789";

            box.Add(patternB);
            box.Add(patternA);

            var foundResults = box.Find(leadingPart).ToList();

            Assert.Contains(patternA, foundResults);
            Assert.Contains(patternB, foundResults);
        }

        [Theory]
        [ClassData(typeof(BoxTestCountData))]
        public void CountNode_should_be_correct(List<string> patterns, int expectedNodeCount)
        {
            var box = new Box();

            patterns.ForEach(pattern => box.Add(pattern));

            var count = box.CountNode();

            Assert.Equal(expectedNodeCount, count);
        }
    }

    internal class BoxTestCountData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new List<string> { "0467123456" }, 10 };
            yield return new object[] { new List<string> { "0123456789", "1123456789" }, 20 };
            yield return new object[] { new List<string> { "0123456789", "0123" }, 10 };
            yield return new object[] { new List<string> { "0412578440", "0412199803", "0468892011", "112", "15" }, 28 };
        }

        IEnumerator<object[]> IEnumerable<object[]>.GetEnumerator() => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
