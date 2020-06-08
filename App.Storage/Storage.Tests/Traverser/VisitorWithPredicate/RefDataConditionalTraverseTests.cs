using Xunit;

namespace Storage.Tests.Traverser.VisitorWithPredicate
{
    public class RefDataConditionalTraverseTests
    {
        [Fact]
        public void Conditional_traverse_should_find_target_node()
        {
            var factory = new RefDataFactory();
            var node = factory.Create("0123456789");
            var target = factory.Create('7');
            var visitor = new FindVisitor(target);
            var traverser = new RefDataDownsideTraverseWithCondition();

            var traversResult = traverser.Traverse(node, visitor);

            Assert.True(traversResult);
        }
    }
}
