using Trees.Strategy.Firing;

namespace Trees.Enumerator
{
    public class EnumeratorDFS : NodeEnumerator
    {
        public EnumeratorDFS(Node node) : base(node, new DeepFiringStrategy(node))
        {
        }
    }
}
