using System;
using System.Collections;

namespace Trees.Enumerator
{
    public abstract class NodeEnumerator : IEnumerator
    {
        protected Node _startNode;

        public virtual object Current { get; protected set; }

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
