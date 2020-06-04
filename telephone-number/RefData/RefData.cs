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
        public IEnumerable<RefData> Nodes { get; private set; } = Enumerable.Empty<RefData>();

        public char Data { get; set; }

        internal RefData(char data)
        {
            Data = data;
        }

        public void AppendSub(RefData subRefData)
        {
            subRefData.Root = this;
            Nodes = new List<RefData>{ subRefData }.Concat(Nodes);
        }

        public bool HasParent() => Root != Null;

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
        //scopeHeads - mean numbers beginnigs
        private IList<RefData> _heads;
        private RefDataHeadTraverser _headTraverser;
        private RefDataFactory _factory;

        public RefDataScope()
        {
            _heads = new List<RefData>();
            _headTraverser = new RefDataHeadTraverser(_heads);
            _factory = new RefDataFactory();
        }

        public void Add(string number)
        {
            var head = default(RefData);
            if (!_headTraverser.TryFind(number, out head))
            {
                var prefixPath = _factory.Create(number);
                head = prefixPath.First();
                _heads.Add(head);
                return;
            }

            //TODO:traverse from node until find unequal digit
        }
    }

    public class RefDataHeadTraverser//find numbers over group of refData's
    {
        private readonly IEnumerable<RefData> _refDatas;

        public RefDataHeadTraverser(IEnumerable<RefData> refDatas)
        {
            _refDatas = refDatas ?? throw new ArgumentNullException(nameof(refDatas));
        }

        public bool TryFind(string prefix, out RefData refData)
        {
            var refHead = default(RefData);
            foreach (var digit in prefix)
            {
                refHead = _refDatas.FirstOrDefault(x => x.Data == digit);
                break;
            }

            refData = refHead;

            if (refHead != default(RefData))
                return true;

            return false;
        }
    }

    public class RefDataNodeTraverser//find numbers over group of refData's
    {
        private readonly RefData _refData;

        public RefDataNodeTraverser(RefData refData)
        {
            _refData = refData ?? throw new ArgumentNullException(nameof(refData));
        }

        public bool TryFind(string prefix, out RefData refData)
        {
            //TODO: find/implement traverse from head to tail using parent referencing tree style
            var refHead = default(RefData);
            foreach (var digit in prefix)
            {
                refHead = _refData.FirstOrDefault(x => x.Data == digit);
                break;
            }

            refData = refHead;

            if (refHead != default(RefData))
                return true;

            return false;
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
