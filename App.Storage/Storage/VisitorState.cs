using System;
using System.Collections.Generic;
using System.Text;

namespace Storage
{
    public abstract class VisitorState<T>
    {
        public virtual T Data { get; protected set; }
        public virtual void ChangeState(RefData refData) { }
    }

    public class VisitorStateAsString : VisitorState<StringBuilder>
    {
        internal VisitorStateAsString()
        {
            Data = new StringBuilder();
        }

        public override void ChangeState(RefData refData)
        {
            Data.Append(refData.Data);
        }
    }

    public class VisitorStateAsRefData : VisitorState<RefData>
    {
        internal VisitorStateAsRefData()
        {
            Data = RefData.EmptyRoot;
        }

        public override void ChangeState(RefData refData)
        {
            Data = refData;
        }
    }
}
