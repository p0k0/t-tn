using System;
using System.Linq;
using Xunit;

namespace Storage.v3.Tests
{
    public class RefNodeTests
    {
        [Fact]
        public void Test1()
        {
            var data = RefNode<int>.CreateAndReturnTail(new int[] { 1, 2, 3 });
            var expected = "123";
            Assert.Equal(expected, data.ToString());
        }

        [Fact]
        public void Test2()
        {
            var data = RefNode<char>.CreateAndReturnTail("123");
            var expected = "123";
            Assert.Equal(expected, data.ToString());
        }
    }
}
