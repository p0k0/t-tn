using System.Collections.Generic;

namespace Trees.Strategy.Firing
{
    /// <summary>
    /// Реализации обхода дерева (графа) в ширину
    /// </summary>
    public class BreadthFiringStrategy : IFiringStrategy
    {
        private Queue<Node> _flame;

        public BreadthFiringStrategy(Node node)
        {
            _flame = new Queue<Node>();
            FeedFlame(node);
        }

        public bool IsFiringEnd => _flame.Count == 0;
        public Node FlamePeek => _flame.Peek();

        public Node StewFlamesTongue() => _flame.Dequeue();
        public void FeedFlame(Node node) => _flame.Enqueue(node);
    }
}
