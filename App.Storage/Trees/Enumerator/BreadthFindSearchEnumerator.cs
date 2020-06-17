using Trees.Strategy.Firing;

namespace Trees.Enumerator
{
    public class BreadthFindSearchEnumerator : NodeEnumerator
    {
        public BreadthFindSearchEnumerator(Node node) : base(node, new BreadthFiringStrategy(node))
        {
        }
    }
}
