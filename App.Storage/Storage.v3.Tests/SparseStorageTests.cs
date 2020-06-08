using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Storage.v3.Tests
{
    public class SparseStorageTests
    {
        [Fact]
        public void Test1()
        {
            var storage = new SparseStorage();
            storage["0"] = new RefNode<int>(0)
        }
    }
}
