using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Storage
{
    public class RefDataScope // compactifyed refData groups, where two group with same lead digits can use same data
    {
        /*
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
            var traverser = head.CreateTraverser();
            if (!traverser.TryFind())
            {

            }
        }

        public RefData FirstUnequal(RefData source, char digit)
        {
            return source.Data != digit
                 ? source
                 : source.SubNodes.FirstOrDefault(subNode => FirstUnequal(subNode, digit) != RefData.Null);
        }*/
    }
}
