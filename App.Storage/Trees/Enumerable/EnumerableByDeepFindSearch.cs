using System;
using System.Collections;
using System.Collections.Generic;
using Trees.Enumerator;

namespace Trees.Enumerable
{
    public class EnumerableByDeepFindSearch : IEnumerable, IEnumerable<Node>
    {
        private readonly Node _startNode;

        public EnumerableByDeepFindSearch(Node startNode)
        {
            _startNode = startNode;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public EnumeratorByDeepFindSearch GetEnumerator() => new EnumeratorByDeepFindSearch(_startNode);

        IEnumerator<Node> IEnumerable<Node>.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
