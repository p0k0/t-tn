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
            Burn(node);
        }

        public bool IsFiringEnd => _flame.Count == 0;
        public Node Current => _flame.Peek();

        public Node StewNode() => _flame.Pop();
        public void Burn(Node node) => _flame.Push(node);

        IFiringStrategy IFiringStrategy.Create(Node node) => Create(node);

        public IFiringStrategy Create(Node node)
        {
            return new DeepFiringStrategy(node);
        }
    }
}
