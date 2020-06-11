using System;
using System.Collections.Generic;
using System.Linq;
using Trees;
using Trees.Accumulator;
using Trees.Factory;
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

        public IEnumerable<string> Find(string pattern)
        {
            var factory = new ChainFactory();
            var accumulator = new SeparatelyAccumulator();
            var eachBrachVisitors = Enumerable.Empty<IVisitor>();

            var targetNode = factory.Create(pattern);
            if (!_heads.Contains(targetNode))
                return Enumerable.Empty<string>();

            var headForEdit = _heads.SingleOrDefault(x => x.Data == pattern.First());
            eachBrachVisitors = accumulator.Accumulate(startNode: headForEdit, node => !node.HasVisited, new AccumulatePathAsStringVisitor()).ToList();
            
            return eachBrachVisitors.Select(visitor => visitor.ToString()).DefaultIfEmpty();
        }

        public void Add(string pattern)
        {
            if (pattern == string.Empty)
                return;

            var chainFactory = new ChainFactory();
            var (newChainHead, newChainTail)= chainFactory.CreateWithHeadAndTail(pattern);

            if (!newChainHead.SubNodes.Any()) //current node still exists as foundHead and any sub adding does not required
                return;

            if (_heads.Contains(newChainHead))
            {
                var head = _heads.Single(x => x.Data == pattern.First());
                var tailSearchIterator = new DeepFirstSearchByPathIterator();
                var traversePathHead = newChainHead.SubNodes.Single();

                tailSearchIterator.FindLastSatisfiedNode(head, node => node.Data == pattern.First(), traversePathHead);
                /*
                //a
                var last = tailSearchIterator.Visitor.TraversedNodes.Last();
                if (newChainHead.OverallSubNodeCount > tailSearchIterator.Visitor.TraversedNodes.Count)
                {
                    var diffHead = chainFactory.DeepCopy(traversePathHead) - last;
                    NewChainHeadNodeCountGreaterThanEqualTraversedNodeCountAtStoredHead(last, diffHead);
                }
                else
                {
                    var diffHead = chainFactory.DeepCopy(traversePathHead) - last;
                    NewChainHeadNodeCountSmallerThanEqualTraversedNodeCountAtStoredHead(last, diffHead);//require tree rebuild
                }
                //a
                */
                
                //b
                var foundTailNode = tailSearchIterator.Visitor.TraversedNodes.Last();
                var foundHeadNode = tailSearchIterator.Visitor.TraversedNodes.First();

                if (foundTailNode != null)
                {

                    if (foundTailNode.OverallSubNodeCount == foundHeadNode.OverallSubNodeCount)//this pattern already exists and has been found
                        return;

                    if (foundTailNode.OverallSubNodeCount < newChainTail.OverallSubNodeCount)//node for insert still exists
                        foundTailNode.AppendSub(newChainTail - foundTailNode);
                }
                //b   
             
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
