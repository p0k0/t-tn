using System.Collections.Generic;

namespace Trees.Enumerator
{
    public class BreadthFindSearchEnumerator : NodeEnumerator
    {
        private Queue<Node> _firingNode;
        private Node _currentNode;

        internal BreadthFindSearchEnumerator(Node node)
        {
            _firingNode = new Queue<Node>();
            _firingNode.Enqueue(node);
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

            var removed = _firingNode.Dequeue();
            foreach (var sub in removed.SubNodes)
                _firingNode.Enqueue(sub);

            return true;
        }
    }
}
