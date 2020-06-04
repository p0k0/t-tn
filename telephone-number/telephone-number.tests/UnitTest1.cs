using System;
using System.Linq;
using Xunit;

namespace telephone_number.tests
{
    public class UnitTest1
    {
        [Fact]
        public void Add_number_with_same_begin_part_should_have_expected_count()
        {
            var tree = new Tree();

            tree.Insert("0412");
            tree.Insert("0468");

            Assert.Equal(6, tree.NodeCount());
        }

        [Fact]
        public void Find_number_with_pattern_should_success()
        {
            var tree = new Tree();

            tree.Insert("0412");
            tree.Insert("0468");

            var foundNumbers = tree.Find("04");

            Assert.Equal(2, foundNumbers.Count());
            Assert.Contains(foundNumbers, telephoneNumber => telephoneNumber == "0412");
            Assert.Contains(foundNumbers, telephoneNumber => telephoneNumber == "0468");
        }

        [Fact]
        public void Telephone_numbers_different_leading_digits_should_not_overlap()
        {
            var tree = new Tree();

            tree.Insert("0412");
            tree.Insert("1468");

            Assert.Equal(8, tree.NodeCount());
        }
    }
}
