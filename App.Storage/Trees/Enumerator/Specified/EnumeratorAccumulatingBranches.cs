using Trees.Strategy.Firing;

namespace Trees.Enumerator.Specified
{

    public class EnumeratorAccumulatingBranches : NodeEnumerator
    {
        private readonly PathAccumulator _accumulator;

        public EnumeratorAccumulatingBranches(Node node, PathAccumulator accumulator) : base(node, new DeepFiringStrategy(node))
        {
            _accumulator = accumulator;
        }

        public override bool MoveNext()
        {
            if (FiringStrategy.IsFiringEnd)
                return false;

            Current = FiringStrategy.Current;

            if (Current == null)
                return false;

            _accumulator.UpdateCurrentPath(Current);

            if (FiringStrategy.Current.SubNodes.Count > 1)//acc update
                _accumulator.RememberRoot();

            var stewNode = FiringStrategy.StewNode();

            foreach (var subnode in stewNode.SubNodes)
                FiringStrategy.Burn(subnode);

            if (stewNode.SubNodes.Count > 1)//acc update
                _accumulator.RepeatRoot(stewNode.SubNodes.Count);

            if (Current.SubNodes.Count == 0)//acc update
                _accumulator.NextPath();

            return true;
        }
    }
}
