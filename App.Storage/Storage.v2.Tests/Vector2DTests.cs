using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Storage.v2.Tests
{
    public class Vector2DTests
    {
        [Fact]
        public void Two_dim_vector_init_should_success()
        {
            var v1 = new SparseVector2D<int, int>();
            v1[0][50] = 100;

            Assert.Equal(100, v1[0][50]);
        }

        [Fact]
        public void Two_dim_vector_init_should_success_another_indexer()
        {
            var v1 = new SparseVector2D<int, int>();
            v1[0,50] = 100;

            Assert.Equal(100, v1[0,50]);
        }
    }
}
