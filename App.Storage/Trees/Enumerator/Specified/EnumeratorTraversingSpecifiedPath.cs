using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Trees.Enumerator.Specified
{
    public class EnumeratorTraversingSpecifiedPath : IEnumerator<Node>
    {
        public Node LastTraversedNode { get; private set; }
        public Node TraverseRemainder { get; private set; }

        public Node Current => _currentNode;
        object IEnumerator.Current => Current;

        private Node _startNode;
        private Node _traversePathHead;
        private Node _currentNode;

        public EnumeratorTraversingSpecifiedPath(Node startNode, Node traversePathHead)
        {
            _currentNode = _startNode = startNode;
            _traversePathHead = traversePathHead;
        }

        public bool IsDestinationReached() => MoveNext() == false && TraverseRemainder == Current;

        public bool MoveNext()
        {
            if (_currentNode == null)
                return false;

            if (_traversePathHead == null)
                return false;

            LastTraversedNode = _currentNode;
            TraverseRemainder = _traversePathHead;

            _currentNode = _currentNode.SubNodes.Where(x => x.Data == _traversePathHead.Data).FirstOrDefault();
            _traversePathHead = _traversePathHead.SubNodes.SingleOrDefault();

            return true;
        }

        public void Reset()
        {
            _currentNode = _startNode;
        }

        public void Dispose()
        {
            _currentNode = _startNode = _traversePathHead = null;
        }
    }
}
