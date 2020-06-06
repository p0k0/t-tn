using Storage;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace telephone_number.tests
{
    public class RefDataComparerTests
    {
        [Fact]
        public void Positive_matching_sample_should_success()
        {
            var factory = new RefDataFactory();
            var nodeA = factory.Create("12345");
            var nodeB = factory.Create("12397");
            var comparer = new RefDataComparer();

            var expected = "***97";
            var result = comparer.Compare(nodeA, nodeB);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Negative_matching_sample_should_success()
        {
            var factory = new RefDataFactory();
            var nodeA = factory.Create("12345");
            var nodeB = factory.Create("397");
            var comparer = new RefDataComparer();

            var expected = "397";
            var result = comparer.Compare(nodeA, nodeB);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Positive_match_sample_should_start_with_asterisk()
        {
            var factory = new RefDataFactory();
            var nodeA = factory.Create("12345");
            var nodeB = factory.Create("12397");
            var comparer = new RefDataComparer();

            var result = comparer.Compare(nodeA, nodeB);

            Assert.StartsWith("***", result);
        }
    }
}
