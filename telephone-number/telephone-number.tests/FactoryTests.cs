using Storage;
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
            var resultHead = factory.Create("0412");
            var c1 = factory.Create('0');
            var c2 = factory.Create('4');
            var c3 = factory.Create('1');
            var c4 = factory.Create('2');
            
            c1.AppendSub(c2);
            c2.AppendSub(c3);
            c3.AppendSub(c4);


            Assert.Equal(c1, resultHead);
        }
    }
}
