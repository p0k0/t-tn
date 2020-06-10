using System;
using Xunit;

namespace Trees.Tests
{
    public class TreeFactoryTests
    {
        [Fact]
        public void Should_create_tree()
        {
            var factory = new TreeFactory();
            
            var treeHead = factory.Create("123678");
            var treeTail = treeHead      //1
                            .SubNodes[0] //2
                            .SubNodes[0] //3
                            .SubNodes[0] //6
                            .SubNodes[0] //7
                            .SubNodes[0];//8
            
            var expectedHead = '1';
            var expectedTail = '8';

            Assert.NotNull(treeHead);
            Assert.Equal(expectedHead, treeHead.Data);
            Assert.Equal(expectedTail, treeTail.Data);
        }
    }
}
