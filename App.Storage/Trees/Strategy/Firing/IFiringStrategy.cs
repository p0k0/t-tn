namespace Trees.Strategy.Firing
{
    /// <summary>
    /// Сигнатуры методов для обстракции над обходм дерева (графа)
    /// на примере "поджёга" дерева (графа)
    /// </summary>
    public interface IFiringStrategy
    {
        /// <summary>
        /// Догорело ли плямя
        /// </summary>
        bool IsFiringEnd { get; }

        /// <summary>
        /// Смотрим верхушку пламени. При этом верхушка продолжает гореть
        /// </summary>
        Node Current { get; }

        /// <summary>
        /// Тушим текущий узел
        /// </summary>
        /// <returns>Возвращается сгоревший узел дерева (графа)</returns>
        Node StewNode();

        /// <summary>
        /// Поджигаем узел
        /// </summary>
        /// <param name="node">Узел дерева (графа)</param>
        void Burn(Node node);

        IFiringStrategy Create(Node node);
    }
}
