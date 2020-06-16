using System.Collections.Generic;

namespace Trees.Enumerator
{
    public class EnumeratorByDeepFindSearch : NodeEnumerator
    {
        private Stack<Node> _firingNode;
        private Node _currentNode;

        internal EnumeratorByDeepFindSearch(Node node)
        {
            _firingNode = new Stack<Node>();
            _firingNode.Push(node);
            _startNode = node;
        }

        public override object Current => _currentNode;

        public override bool MoveNext()
        {
            if (_firingNode.Count == 0)
                return false;

            _currentNode = _firingNode.Peek();

            if (_currentNode == null)
                return false;

            var removed = _firingNode.Pop();
            foreach (var sub in removed.SubNodes)
                _firingNode.Push(sub);

            return true;
        }
    }
}
