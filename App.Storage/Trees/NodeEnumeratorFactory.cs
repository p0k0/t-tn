using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Trees
{
    public enum NodeTraverseType
    {
        InDeepByConcretePath,
        InDeepByAllSubnodes
    }

    public class NodeEnumeratorFactory
    {
        private readonly Node _node;

        public NodeEnumeratorFactory(Node node)
        {
            _node = node;
        }

        public NodeEnumerator Create(NodeTraverseType type)
        {
            switch (type)
            {
                case NodeTraverseType.InDeepByConcretePath:
                    return new NodeInDeepByConcretePathEnumerator(_node);
                case NodeTraverseType.InDeepByAllSubnodes:
                    return new NodeInDeepByAllSubnodesEnumerator(_node);
                default:
                    throw new NotSupportedException();
            }
        }
    }

    public abstract class NodeEnumerator : IEnumerator
    {
        public object Current => throw new NotImplementedException();

        public virtual bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }

    public class NodeInDeepByConcretePathEnumerator : NodeEnumerator
    {
        private readonly Node _node;

        public NodeInDeepByConcretePathEnumerator(Node node)
        {
            _node = node;
        }

        public override bool MoveNext()
        {
            return base.MoveNext();
        }
    }

    public class NodeInDeepByAllSubnodesEnumerator : NodeEnumerator
    {
        private readonly Node _node;

        public NodeInDeepByAllSubnodesEnumerator(Node node)
        {
            _node = node;
        }

        public override bool MoveNext()
        {
            return base.MoveNext();
        }
    }
}
