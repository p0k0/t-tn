using Trees.Node;
using Trees.Visitor;

namespace Trees.Accumulator
{
    public class DeepFindSearchAccumulator
    {
        public void Accumulate(INode startNode, IVisitor accumulateVisitor)
        {
            accumulateVisitor.Visit(startNode);

            foreach (var sub in startNode.SubNodes)
                Accumulate(sub, accumulateVisitor);
        }
    }
}
