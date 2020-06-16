using System.Linq;

namespace Trees.Enumerator
{
    public class EnumeratorByConcretePath : NodeEnumerator
    {
        public Node LastTraversedNode { get; private set; }
        public Node TraverseRemainder { get; private set; }

        private Node _traversePathHead;
        private Node _currentNode;

        public EnumeratorByConcretePath(Node startNode, Node traversePathHead)
        {
            _currentNode = _startNode = startNode;
            _traversePathHead = traversePathHead;
        }

        public bool IsDestinationReached() => MoveNext() == false && TraverseRemainder == Current;

        public override object Current => _currentNode;

        public override bool MoveNext()
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
    }
}
