using System.Collections;
using System.Collections.Generic;
using Trees.Strategy.Firing;

namespace Trees.Enumerator
{
    public class NodeEnumerator : IEnumerator<Node>
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
        public IFiringStrategy FiringStrategy { get; }
        public Node Current { get; protected set; }

        Node IEnumerator<Node>.Current => Current;
        object IEnumerator.Current => Current;

        public void Dispose()
        {
            StartNode = null;
            Current = null;
        }

        public virtual bool MoveNext()
        {
            if (FiringStrategy.IsFiringEnd)
                return false;

            Current = FiringStrategy.FlamePeek;

            if (Current == null)
                return false;

            var stewNode = FiringStrategy.StewFlamesTongue();
            foreach (var subnode in stewNode.SubNodes)
                FiringStrategy.FeedFlame(subnode);

            return true;
        }

        public void Reset()
        {
            Current = StartNode;
        }
    }
}
