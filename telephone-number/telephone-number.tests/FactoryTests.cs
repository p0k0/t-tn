using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace telephone_number.tests
{
    public class FactoryTests
    {
        [Fact]
        public void Factory_should_success_create_reference_structure()
        {
            var factory = new RefDataFactory();
            var result = factory.Create("0412").ToList();
            var expected = new List<RefData> { new RefData('0'), new RefData('4'), new RefData('1'), new RefData('2') };
            expected[3].Parent = expected[2];
            expected[2].Parent = expected[1];
            expected[1].Parent = expected[0];

            Assert.Equal(expected, result);
        }
    }
}
