using System.Collections;
using System.Collections.Generic;
using Trees.Strategy.Firing;

namespace Trees.Enumerator
{
    public abstract class NodeEnumerator : IEnumerator<Node>
    {
        public NodeEnumerator(NodeEnumerator other)
        {
            StartNode = other.StartNode;
            FiringStrategy = other.FiringStrategy;
        }

        public NodeEnumerator(IEnumerator<Node> other)
        {
            var otherCasted = ((NodeEnumerator)other);
            StartNode = otherCasted.StartNode;
            FiringStrategy = otherCasted.FiringStrategy;
        }

        public NodeEnumerator(Node node) : this(node, new DeepFiringStrategy(node)) { }

        public NodeEnumerator(Node node, IFiringStrategy firingStrategy)
        {
            StartNode = node;
            FiringStrategy = firingStrategy;
        }

        public Node StartNode { get; protected set; }
        public IFiringStrategy FiringStrategy { get; private set; }
        public Node Current { get; protected set; }

        Node IEnumerator<Node>.Current => Current;
        object IEnumerator.Current => Current;

        public void Dispose()
        {
            StartNode = null;
        }

        public virtual bool MoveNext()
        {
            if (FiringStrategy.IsFiringEnd)
                return false;

            Current = FiringStrategy.Current;

            if (Current == null)
                return false;

            var stewNode = FiringStrategy.StewNode();
            foreach (var subnode in stewNode.SubNodes)
                FiringStrategy.Burn(subnode);

            return true;
        }

        public void Reset()
        {
            FiringStrategy = FiringStrategy.Create(StartNode);
        }
    }
}
