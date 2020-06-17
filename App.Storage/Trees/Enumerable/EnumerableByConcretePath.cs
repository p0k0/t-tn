using System.Collections;
using System.Collections.Generic;
using Trees.Enumerator;

namespace Trees.Enumerable
{
    public class EnumerableByConcretePath : IEnumerable, IEnumerable<Node>
    {
        private readonly Node _startNode;
        private readonly Node _pathStartNode;

        public EnumerableByConcretePath(Node startNode, Node pathStartNode)
        {
            _startNode = startNode;
            _pathStartNode = pathStartNode;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public ConcretePathEnumerator GetEnumerator() => new ConcretePathEnumerator(_startNode, _pathStartNode);

        IEnumerator<Node> IEnumerable<Node>.GetEnumerator() => GetEnumerator();
    }
}
