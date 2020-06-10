using System;
using System.Collections.Generic;
using System.Linq;
using Trees;
using Trees.Accumulator;
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

        public IEnumerable<string> Find(string pattern)
        {
            var factory = new TreeFactory();
            var accumulator = new SeparatelyAccumulator();
            var eachBrachVisitors = Enumerable.Empty<AccumulateVisitor>();

            var targetNode = factory.CreateStraightTree(pattern);
            if (!_heads.Contains(targetNode))
                return Enumerable.Empty<string>();

            var headForEdit = _heads.SingleOrDefault(x => x.Data == pattern.First());
            eachBrachVisitors = accumulator.Accumulate(startNode: headForEdit, node => !node.HasVisited).ToList();
            
            return eachBrachVisitors.Select(visitor => visitor.ToString()).DefaultIfEmpty();
        }

        public void Add(string pattern)
        {
            if (pattern == string.Empty)
                return;

            var factory = new TreeFactory();
            var newSubTreeHead = factory.CreateStraightTree(pattern);
            
            if (_heads.Contains(newSubTreeHead))
            {
                var head = _heads.Single(x => x == newSubTreeHead);
                var iterator = new DeepFirstSearchByNodeIterator();
                var targetNode = new Node { Data = pattern.First() };
                var foundHead = iterator.FindNode(head, node => node == targetNode);
                if (foundHead != null)
                {
                    if (!newSubTreeHead.SubNodes.Any()) //current node still exists as foundHead and any sub adding does not required
                        return;
                    else
                        foundHead.AppendSub(newSubTreeHead.SubNodes.Single());
                }
            }
            else
            {
                _heads.Add(newSubTreeHead);
            }
        }
    }
}
