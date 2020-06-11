using Trees.Node;
using Trees.Visitor;

namespace Trees.Accumulator
{
    public class DeepFindSearchAccumulator
    {
        private readonly IVisitor _accumulateVisitor;

        public DeepFindSearchAccumulator(IVisitor accumulateVisitor)
        {
            _accumulateVisitor = accumulateVisitor;
        }

        public void Accumulate(INode startNode)
        {
            _accumulateVisitor.Visit(startNode);

            foreach (var sub in startNode.SubNodes)
                Accumulate(sub);
        }
    }
}
