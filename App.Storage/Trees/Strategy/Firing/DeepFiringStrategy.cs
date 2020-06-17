using System.Collections.Generic;

namespace Trees.Strategy.Firing
{
    /// <summary>
    /// Реализации обхода дерева (графа) в глубину
    /// </summary>
    public class DeepFiringStrategy : IFiringStrategy
    {
        private Stack<Node> _flame;

        public DeepFiringStrategy(Node node)
        {
            _flame = new Stack<Node>();
            FeedFlame(node);
        }

        public bool IsFiringEnd => _flame.Count == 0;
        public Node FlamePeek => _flame.Peek();

        public Node StewFlamesTongue() => _flame.Pop();
        public void FeedFlame(Node node) => _flame.Push(node);
    }
}
