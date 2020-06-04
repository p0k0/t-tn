using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Storage
{
    public class RefData
    {
        public static RefData Null = null;

        public RefData Parent { get; private set; } = Null;

        public char Data { get; set; }

        internal RefData(char data)
        {
            Data = data;
        }

        public void AppendSub(RefData subRefData)
        {
            subRefData.Parent = this;
        }

        public bool HasParent() => Parent != Null;

        public override bool Equals(object obj)
        {
            return Data.Equals(((RefData)obj).Data);
        }

        public override int GetHashCode()
        {
            return Data.GetHashCode();
        }
    }

    public class RefDataScope // compactifyed refData groups, where two group with same lead digits can use same data
    {

    }

    public class RefDataTraverser//find numbers over group of refData's
    {
        private readonly IEnumerable<RefData> _refDatas;

        public RefDataTraverser(IEnumerable<RefData> refDatas)
        {
            _refDatas = refDatas ?? throw new ArgumentNullException(nameof(refDatas));
        }
    }

    public class RefDataFactory
    {
        public RefData Create(char data) => new RefData(data);

        public IEnumerable<RefData> Create(string number)
        {
            var result = new List<RefData>();
            var headData = number.Substring(0, 1).ToCharArray()[0];
            var head = new RefData(headData);
            var current = default(RefData);

            result.Add(head);
            for (int i = 1; i < number.Length; i++)
            {
                current = new RefData(number[i]);
                head.AppendSub(current);
                result.Add(current);

                head = current;
            }

            return result;
        }
    }
}
