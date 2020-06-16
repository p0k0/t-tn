using System;
using System.Collections;
using System.Collections.Generic;

namespace Trees.Enumerator
{
    public abstract class NodeEnumerator : IEnumerator, IEnumerator<Node>
    {
        protected Node _startNode;

        public virtual object Current { get; protected set; }

        Node IEnumerator<Node>.Current => throw new NotImplementedException();

        public void Dispose()
        {
            _startNode = null;
            Current = null;
        }

        public virtual bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            Current = _startNode;
        }
    }
}
