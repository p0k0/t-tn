using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Storage.v2.Tests
{
    public class Vector1DTests
    {
        [Fact]
        public void One_dim_vector_init_should_success()
        {
            var v1 = new SparseVector1D<int>();
            v1[0] = 100;

            Assert.Equal(100, v1[0]);
        }
    }
}
