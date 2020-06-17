using Trees.Strategy.Firing;

namespace Trees.Enumerator
{
    public class DeepFindSearchEnumerator : NodeEnumerator
    {
        public DeepFindSearchEnumerator(Node node) : base(node, new DeepFiringStrategy(node))
        {
        }
    }
}
