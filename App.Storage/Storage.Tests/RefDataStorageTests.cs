using Storage;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Storage.Tests
{
    public class RefDataStorageTests
    {
        [Fact]
        public void Storage_autocompletition_should_work_success()
        {
            var factory = new RefDataFactory();
            var storage = factory.CreateStorage();
            var numberPart = "041";
            var number1 = $"{numberPart}2578440";
            var number2 = $"{numberPart}2199803";

            storage.Save(number1);
            storage.Save(number2);
            storage.Save("112");

            IEnumerable<string> autocompleteResult = storage.FindCorrelations(numberPart);
            string[] expected = new string[] { number1, number2 };

            Assert.Contains(expected[0], autocompleteResult);
            Assert.Contains(expected[1], autocompleteResult);
        }

        [Fact]
        public void Storage_memory_optimization_should_work_success()
        {
            var factory = new RefDataFactory();
            var storage = factory.CreateStorage();
            var numberPart = "041";
            var number1 = $"{numberPart}2578440";
            var number2 = $"{numberPart}2199803";

            storage.Save(number1);
            storage.Save(number2);
            storage.Save("112");
            storage.Save("15");

            int memoryConsumed = storage.GetMemoryComsumption();
            var expected = 20;

            Assert.Equal(expected, memoryConsumed);
        }
    }
}
