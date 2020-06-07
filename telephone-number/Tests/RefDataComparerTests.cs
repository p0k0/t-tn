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
            var comparer = factory.CreateComparer();

            var expected = "***97";
            var result = comparer.Compare(nodeA, nodeB);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Positive_matching_sample_when_one_tree_is_equal_another_tree_part_should_success()
        {
            var factory = new RefDataFactory();
            var nodeA = factory.Create("12345");
            var nodeB = factory.Create("123");
            var comparer = factory.CreateComparer();

            var expected = "***";
            var result = comparer.Compare(nodeA, nodeB);

            Assert.Equal(expected, result);
        }


        [Fact]
        public void Positive_matching_sample_when_one_tree_is_equal_another_tree_part_and_remain_should_be_found_success()
        {
            var factory = new RefDataFactory();
            var nodeA = factory.Create("12345");
            var nodeB = factory.Create("123");
            var comparer = factory.CreateComparer();

            var expected = "***45";
            var result = comparer.Compare(nodeB, nodeA);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Negative_matching_sample_should_success()
        {
            var factory = new RefDataFactory();
            var nodeA = factory.Create("12345");
            var nodeB = factory.Create("897");
            var comparer = factory.CreateComparer();

            var expected = "897";
            var result = comparer.Compare(nodeA, nodeB);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Negative_matching_sample_with_root_should_success()
        {
            var factory = new RefDataFactory();
            var number = "12345";
            var nodeA = factory.Create(number);
            var root = factory.CreateRoot();
            var comparer = factory.CreateComparer();

            var expected = "12345";
            var result = comparer.Compare(root, nodeA);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Positive_match_sample_should_start_with_asterisk()
        {
            var factory = new RefDataFactory();
            var nodeA = factory.Create("12345");
            var nodeB = factory.Create("12397");
            var comparer = factory.CreateComparer();

            var result = comparer.Compare(nodeA, nodeB);

            Assert.StartsWith("***", result);
        }
    }
}
