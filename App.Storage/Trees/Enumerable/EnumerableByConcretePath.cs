using System.Collections;
using Trees.Enumerator;

namespace Trees.Enumerable
{
    public class EnumerableByConcretePath : IEnumerable
    {
        private readonly Node _startNode;
        private readonly Node _pathStartNode;

        public EnumerableByConcretePath(Node startNode, Node pathStartNode)
        {
            _startNode = startNode;
            _pathStartNode = pathStartNode;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public EnumeratorByConcretePath GetEnumerator() => new EnumeratorByConcretePath(_startNode, _pathStartNode);
    }
}
