using System.Collections;

namespace Trees.Enumerator
{
    public class EnumerableByDeepFindSearch : IEnumerable
    {
        private readonly Node _startNode;

        public EnumerableByDeepFindSearch(Node startNode)
        {
            _startNode = startNode;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public EnumeratorByDeepFindSearch GetEnumerator() => new EnumeratorByDeepFindSearch(_startNode);
    }
}
