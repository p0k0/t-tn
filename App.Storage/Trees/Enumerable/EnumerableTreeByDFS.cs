using System;
using System.Collections;
using System.Collections.Generic;
using Trees.Enumerator;

namespace Trees.Enumerable
{
    public class EnumerableTreeByDFS : IEnumerable, IEnumerable<Node>
    {
        private readonly Node _startNode;

        public EnumerableTreeByDFS(Node startNode)
        {
            _startNode = startNode;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public EnumeratorDFS GetEnumerator() => new EnumeratorDFS(_startNode);

        IEnumerator<Node> IEnumerable<Node>.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
