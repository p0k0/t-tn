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
        Node FlamePeek { get; }

        /// <summary>
        /// Тушим верхушку пламени
        /// </summary>
        /// <returns>Возвращается сгоревший узел дерева (графа)</returns>
        Node StewFlamesTongue();

        /// <summary>
        /// Кормим пламя. Пожигаем дальше
        /// </summary>
        /// <param name="node">Узел дерева (графа)</param>
        void FeedFlame(Node node);
    }
}
