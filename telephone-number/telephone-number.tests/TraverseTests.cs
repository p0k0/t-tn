using Storage;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;

namespace telephone_number.tests
{
    public class TraverseTests
    {
        [Fact]
        public void Conditional_traverse_should_find_target_node()
        {
            var factory = new RefDataFactory();
            var node = factory.Create("0123456789");
            var target = factory.Create('7');
            var visitor = new FindVisitor(target);
            var traverser = new RefDataTraverseWithCondition();

            var traversResult = traverser.Traverse(node, visitor);

            Assert.True(traversResult);
        }
    }
}
