using Storage;
using Xunit;

namespace telephone_number.tests
{
    public class RefDataTests
    {
        [Fact]
        public void RefData_minus_operator_when_minuend_greter_when_subtrahend_by_path_should_work_success()
        {
            var factory = new RefDataFactory();
            var minuend = factory.Create("12345");
            var subtrahend = factory.Create("123");

            var result = minuend - subtrahend;
            var expected = factory.Create("45");

            Assert.Equal(expected, result);
        }

        [Fact]
        public void RefData_minus_operator_when_minuend_smaller_when_subtrahend_by_path_should_work_success()
        {
            var factory = new RefDataFactory();
            var minued = factory.Create("123");
            var subtrahend = factory.Create("12345");

            var result = minued - subtrahend;
            var expected = factory.Create("45");

            Assert.Equal(expected, result);
        }

        [Fact]
        public void RefData_minus_operator_should_work_as_commutative_operator()
        {
            var factory = new RefDataFactory();
            var minued = factory.Create("123");
            var subtrahend = factory.Create("12345");

            var result1 = minued - subtrahend;
            var result2 = subtrahend - minued;
            var expected = factory.Create("45");

            Assert.Equal(expected, result1);
            Assert.Equal(expected, result2);
        }
    }
}
