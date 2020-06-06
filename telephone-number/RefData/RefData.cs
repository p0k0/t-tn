using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Storage
{
    public class RefData
    {
        public static RefData Null = null;

        public RefData Root { get; private set; } = Null;
        public IEnumerable<RefData> SubNodes { get; private set; } = new List<RefData>();

        public char Data { get; set; }

        internal RefData(char data)
        {
            Data = data;
        }

        public void AppendSub(RefData subRefData)
        {
            subRefData.Root = this;
            SubNodes = new List<RefData>{ subRefData }.Concat(SubNodes);
        }

        public override bool Equals(object obj)
        {
            return Data.Equals(((RefData)obj).Data);
        }

        public override int GetHashCode()
        {
            return Data.GetHashCode();
        }
    }
}
