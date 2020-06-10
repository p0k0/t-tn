using System;
using System.Linq;
using Xunit;

namespace Storage.Tests
{
    public class BoxTests
    {
        [Fact]
        public void Should_find_added_node()
        {
            var box = new Box();
            var pattern = "0467123456";
            box.Add(pattern);

            var result = box.Find(pattern).Single();
            var expected = "0467123456";

            Assert.Equal(expected, result);
        }
    }
}
