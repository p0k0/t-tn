using System;
using Xunit;

namespace telephone_number.tests
{
    public class UnitTest1
    {
        [Fact]
        public void Add_number_with_same_begin_part_should_have_expected_count()
        {
            var tree = new Tree();

            tree.Insert(0);
            tree.Insert(4);
            tree.Insert(1);
            tree.Insert(2);

            tree.Insert(0);
            tree.Insert(4);
            tree.Insert(6);
            tree.Insert(8);

            Assert.Equal(6, tree.NodeCount());
        }

        [Fact]
        public void Find_number_with_pattern_should_success()
        {
            var tree = new Tree();

            tree.Insert(0);
            tree.Insert(4);
            tree.Insert(1);
            tree.Insert(2);

            tree.Insert(0);
            tree.Insert(4);
            tree.Insert(6);
            tree.Insert(8);

            var foundNumbers = tree.Find("04");

            Assert.Equal(2, foundNumbers.Count());
            Assert.True(foundNumbers.Any(telephoneNumber => telephoneNumber = "0412"));
            Assert.True(foundNumbers.Any(telephoneNumber => telephoneNumber = "0468"));
        }
    }
}
