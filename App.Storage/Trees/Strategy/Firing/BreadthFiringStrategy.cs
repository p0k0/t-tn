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
            Burn(node);
        }

        public bool IsFiringEnd => _flame.Count == 0;
        public Node Current => _flame.Peek();

        public Node StewNode() => _flame.Dequeue();
        public void Burn(Node node) => _flame.Enqueue(node);

        IFiringStrategy IFiringStrategy.Create(Node node) => Create(node);

        public IFiringStrategy Create(Node node)
        {
            return new BreadthFiringStrategy(node);
        }
    }
}
