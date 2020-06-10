using System;
using System.Collections.Generic;
using System.Linq;
using Trees;

namespace Storage
{
    public class Box
    {
        private Node _head;
        
        public IEnumerable<string> Find(string pattern)
        {
            return Enumerable.Empty<string>();
        }

        public void Add(string pattern)
        {
            var factory = new TreeFactory();
            var newSubTreeHead = factory.CreateStraightTree(pattern);
            var iterator = new DeepFirstSearchByNodeIterator();
            
        }
    }
}
