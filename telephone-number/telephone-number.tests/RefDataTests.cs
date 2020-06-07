using Storage;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace telephone_number.tests
{
    public class RefDataTests
    {
        [Fact]
        public void RefData_minus_operator_should_work_success()
        {
            var factory = new RefDataFactory();
            var nodeA = factory.Create("12345");
            var nodeB = factory.Create("123");

            var result = nodeA - nodeB;
            var expected = factory.Create("45");

            Assert.Equal(expected, result);
        }
    }
}
