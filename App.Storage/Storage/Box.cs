using System.Collections.Generic;
using System.Linq;
using Trees;
using Trees.Accumulator;
using Trees.Factory;
using Trees.Iterator;
using Trees.Visitor;

namespace Storage
{
    public class Box
    {
        private HashSet<Node> _heads;

        public Box()
        {
            _heads = new HashSet<Node>();
        }

        public IEnumerable<string> Find(string searchPattern)
        {
            var factory = new ChainFactory();

            var targetNode = factory.Create(searchPattern);
            if (!_heads.Contains(targetNode))
                return Enumerable.Empty<string>();

            var searchHead = _heads.SingleOrDefault(x => x.Data == searchPattern.First());

            var accumulator = new AccumulateBranchIterator();
            accumulator.Accumulate(searchHead, new AccumulatePathAsStringVisitor());

            var accVisitor = new AccumulatePathAsNodeVisitor();
            var iterator = new AccumulateNodeIterator(accVisitor);
            iterator.FindLastSatisfiedNode(searchHead, straightTraversePathHead: targetNode.SubNodes.LastOrDefault());

            var partiallySatisfiedResult = new string(accVisitor.TraversedNodes.Select(node => node.Data).ToArray());
            return accumulator.Visitors.Select(visitor => visitor.ToString()).Concat(new string[] { partiallySatisfiedResult }).DefaultIfEmpty();
        }

        public void Add(string pattern)
        {
            if (pattern == string.Empty)
                return;

            var chainFactory = new ChainFactory();
            var newChainHead = chainFactory.Create(pattern);

            if (_heads.Contains(newChainHead))
            {
                var head = _heads.Single(x => x.Data == pattern.First());
                var iterator = new TraverseSubNodeByPathIterator();
                var traversePathHead = newChainHead.SubNodes.Single();

                iterator.Traverse(head, traversePathHead);
                (iterator.LastTraversedNode as Node).AppendSub(iterator.TraverseRemainder);
            }
            else
            {
                _heads.Add(newChainHead);
            }
        }

        public int CountNode()
        {
            return _heads.Sum(head => head.OverallSubNodeCount);
        }
    }
}
