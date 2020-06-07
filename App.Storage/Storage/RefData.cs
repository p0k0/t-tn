using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Storage
{
    public class RefData
    {
        internal static char EqualPathSymbols = '*';
        internal static RefData Null = null;
        internal static RefData EmptyRoot = new RefData('@');

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

        public static RefData operator -(RefData minued, RefData subtrahend)
        {
            var factory = new RefDataFactory();
            var comparer = factory.CreateComparer();
            var result = comparer.Compare(minued, subtrahend);
            if (result.All(x => x == RefData.EqualPathSymbols))
                result = comparer.Compare(subtrahend, minued);

            var pathBuilder = new StringBuilder(result.TrimStart(EqualPathSymbols));
            
            return factory.Create(pathBuilder.ToString());
        }
    }
}
