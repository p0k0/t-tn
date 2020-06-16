using System.Linq;

namespace Trees.Enumerator
{
    public class EnumeratorByConcretePath : NodeEnumerator
    {
        public Node LastTraversedNode => _currentNode;
        public Node TraverseRemainder => _traversePathHead;

        private Node _traversePathHead;
        private Node _currentNode;

        internal EnumeratorByConcretePath(Node startNode, Node traversePathHead)
        {
            _currentNode = _startNode = startNode;
            _traversePathHead = traversePathHead;
        }

        public override object Current => _currentNode;

        public override bool MoveNext()
        {
            if (_currentNode == null)
                return false;

            if (_traversePathHead == null)
                return false;

            _currentNode = _currentNode.SubNodes.Where(x => x.Data == _traversePathHead.Data).FirstOrDefault();
            _traversePathHead = _traversePathHead.SubNodes.SingleOrDefault();

            return true;
        }
    }
}
