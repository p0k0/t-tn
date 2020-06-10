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

            var factory = new ChainFactory();
            var newSubTreeHead = factory.Create(pattern);
            
            if (_heads.Contains(newSubTreeHead))
            {
                var head = _heads.Single(x => x.Data == pattern.First());
                var iterator = new DeepFirstSearchByPathIterator();
                var traversePathHead = newSubTreeHead.SubNodes.Single();
                iterator.FindLastSatisfiedNode(head, node => node.Data == pattern.First(), traversePathHead);
                var foundNode = iterator.Visitor.TraversedNodes.Last();
                if (foundNode != null)
                {
                    if (!newSubTreeHead.SubNodes.Any()) //current node still exists as foundHead and any sub adding does not required
                        return;

                    if (foundNode.CountOverallSubNode() == traversePathHead.GetLeaf().CountOverallSubNode())//this pattern already exists and has been found
                        return;

                    foundNode.AppendSub(newSubTreeHead - foundNode);
                }
            }
            else
            {
                _heads.Add(newSubTreeHead);
            }
        }

        public int CountNode()
        {
            return _heads.Sum(head => head.CountOverallSubNode());
        }
    }
}
