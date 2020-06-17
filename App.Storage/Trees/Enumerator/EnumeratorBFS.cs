using Trees.Strategy.Firing;

namespace Trees.Enumerator
{
    public class EnumeratorBFS : NodeEnumerator
    {
        public EnumeratorBFS(Node node) : base(node, new BreadthFiringStrategy(node))
        {
        }
    }
}
