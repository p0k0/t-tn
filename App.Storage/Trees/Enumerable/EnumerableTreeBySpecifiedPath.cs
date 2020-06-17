using System.Collections;
using System.Collections.Generic;
using Trees.Enumerator;

namespace Trees.Enumerable
{
    public class EnumerableTreeBySpecifiedPath : IEnumerable, IEnumerable<Node>
    {
        private readonly Node _startNode;
        private readonly Node _pathStartNode;

        public EnumerableTreeBySpecifiedPath(Node startNode, Node pathStartNode)
        {
            _startNode = startNode;
            _pathStartNode = pathStartNode;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public EnumeratorTraversingSpecifiedPath GetEnumerator() => new EnumeratorTraversingSpecifiedPath(_startNode, _pathStartNode);

        IEnumerator<Node> IEnumerable<Node>.GetEnumerator() => GetEnumerator();
    }
}
