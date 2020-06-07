using Storage;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace telephone_number.tests
{
    public class RefDataStorageTests
    {
        [Fact]
        public void Storage_autocompletition_should_work_success()
        {
            var factory = new RefDataFactory();
            var storage = factory.CreateStorage();
            var number1 = "0412578440";
            var number2 = "0412199803";

            storage.Save(number1);
            storage.Save(number2);
            storage.Save("112");

            IEnumerable<string> autocompleteResult = storage.AssumeComplete("041");
            string[] expected = new string[] { number1, number2 };

            Assert.Contains(expected[0], autocompleteResult);
            Assert.Contains(expected[1], autocompleteResult);
        }

        [Fact]
        public void Storage_memory_optimization_should_work_success()
        {

        }
    }
}
