using System;
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

            var result = box.Find(pattern).Single();
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

            var foundResultByPatternA = box.Find(patternA).Single();
            var foundResultByPatternB = box.Find(patternB).Single();
            
            var expectedResultA = "0123456789";
            var expectedResultB = "1123456789";

            Assert.Equal(expectedResultA, foundResultByPatternA);
            Assert.Equal(expectedResultB, foundResultByPatternB);
        }
    }
}
