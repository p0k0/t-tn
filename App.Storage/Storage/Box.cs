using System.Collections.Generic;
using System.Linq;
using Trees;
using Trees.Enumerable;
using Trees.Enumerator;
using Trees.Enumerator.Specified;
using Trees.Factory;

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

            var searchHead = _heads.SingleOrDefault(x => x.Data.Equals(searchPattern.First()));

            var accumulator = new PathAccumulator();
            var enumerator = new EnumeratorAccumulatingBranches(searchHead, accumulator);
            while(enumerator.MoveNext()) { }

            var pathEnumerator = new EnumeratorTraversingSpecifiedPath(searchHead, targetNode.SubNodes.LastOrDefault());
            while (pathEnumerator.MoveNext()) { }

            IEnumerable<string> result = accumulator.Paths;

            if (pathEnumerator.IsDestinationReached)
                result = result.Concat(new string[] { searchPattern });

            return result;
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
                var traversePathHead = newChainHead.SubNodes.Single();
                var enumerator = new EnumeratorTraversingSpecifiedPath(head, traversePathHead);
                
                while (enumerator.MoveNext()) { }

                if (!enumerator.IsDestinationReached && 
                    !enumerator.LastTraversedNode.SubNodes.Contains(enumerator.TraverseRemainder))
                    enumerator.LastTraversedNode.AppendSub(enumerator.TraverseRemainder);
            }
            else
            {
                _heads.Add(newChainHead);
            }
        }

        public int CountNode()
        {
            return _heads.Sum(head => new EnumerableTreeByDFS(head).Count());
        }
    }
}
