using System;
using System.Collections;
using System.Collections.Generic;
using Trees.Enumerator;

namespace Trees.Enumerable
{
    public class EnumerableByBreadthFindSearch : IEnumerable, IEnumerable<Node>
    {
        private readonly Node _startNode;

        public EnumerableByBreadthFindSearch(Node startNode)
        {
            _startNode = startNode;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public BreadthFindSearchEnumerator GetEnumerator() => new BreadthFindSearchEnumerator(_startNode);

        IEnumerator<Node> IEnumerable<Node>.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
