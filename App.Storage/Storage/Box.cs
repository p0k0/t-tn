using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Trees;
using Trees.Accumulator;
using Trees.Factory;
using Trees.Node;
using Trees.Visitor;

namespace Storage
{
    public class Box
    {
        private HashSet<TreeNode> _heads;

        public Box()
        {
            _heads = new HashSet<TreeNode>();
        }

        public IEnumerable<string> Find(string searchPattern)
        {
            var factory = new ChainFactory();
            var accumulator = new SeparatelyAccumulator();
            var eachBrachVisitors = Enumerable.Empty<IVisitor>();

            var targetNode = factory.Create(searchPattern);
            if (!_heads.Contains(targetNode))
                return Enumerable.Empty<string>();
            
            Expression<Func<INode, bool>> findExpression = node => !node.HasVisited; //пока не прошли до листьев

            var searchHead = _heads.SingleOrDefault(x => x.Data == searchPattern.First());
            
            eachBrachVisitors = accumulator.Accumulate(startNode: searchHead, findExpression, new AccumulatePathAsStringVisitor()).ToList();

            var iterator = new DeepFirstSearchByPathIterator();
            iterator.FindLastSatisfiedNode(searchHead, straightTraversePathHead: targetNode.SubNodes.LastOrDefault());
            var partiallySatisfiedResult = new string(iterator.Visitor.TraversedNodes.Select(node => node.Data).ToArray());
            return eachBrachVisitors.Select(visitor => visitor.ToString()).Concat(new string[] { partiallySatisfiedResult }).DefaultIfEmpty();
        }

        public void Add(string pattern)
        {
            if (pattern == string.Empty)
                return;

            var chainFactory = new ChainFactory();
            var (newChainHead, newChainTail)= chainFactory.CreateWithHeadAndTail(pattern);

            if (_heads.Contains(newChainHead))
            {
                var head = _heads.Single(x => x.Data == pattern.First());
                var pathIterator = new DeepFirstSearchByPathIterator();
                var traversePathHead = newChainHead.SubNodes.Single();

                pathIterator.FindLastSatisfiedNode(head, /*node => node.Data == pattern.First(), */traversePathHead);

                var foundChainTailNode = pathIterator.Visitor.TraversedNodes.Last();
                var foundChainHeadNode = pathIterator.Visitor.TraversedNodes.First();

                if (foundChainTailNode != null &&
                    newChainHead.OverallSubNodeCount > foundChainHeadNode.OverallSubNodeCount)
                {
                    var cutStartIndex = newChainHead.OverallSubNodeCount - foundChainHeadNode.OverallSubNodeCount;
                    var newChain = chainFactory.Create(pattern.Substring(cutStartIndex));
                    foundChainTailNode.AppendSub(newChain);
                }
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

        private void NewChainHeadNodeCountGreaterThanEqualTraversedNodeCountAtStoredHead(ChainNode newChainLastTraversedTail, ChainNode diffHead)
        {

        }

        private void NewChainHeadNodeCountSmallerThanEqualTraversedNodeCountAtStoredHead(ChainNode newChainLastTraversedTail, ChainNode diffHead)
        {

        }
    }
}
