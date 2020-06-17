using System;
using System.Collections;
using System.Collections.Generic;
using Trees.Enumerator;

namespace Trees.Enumerable
{
    public class EnumerableTreeByBFS : IEnumerable, IEnumerable<Node>
    {
        private readonly Node _startNode;

        public EnumerableTreeByBFS(Node startNode)
        {
            _startNode = startNode;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public EnumeratorBFS GetEnumerator() => new EnumeratorBFS(_startNode);

        IEnumerator<Node> IEnumerable<Node>.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
