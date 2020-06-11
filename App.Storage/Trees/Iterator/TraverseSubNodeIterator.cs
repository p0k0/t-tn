
using Trees.Visitor;

namespace Trees.Iterator
{
    public class TraverseSubNodeIterator
    {
        private readonly IVisitor _accumulateVisitor;

        public TraverseSubNodeIterator(IVisitor accumulateVisitor)
        {
            _accumulateVisitor = accumulateVisitor;
        }

        public void Accumulate(Node startNode)
        {
            _accumulateVisitor.Visit(startNode);

            foreach (var sub in startNode.SubNodes)
                Accumulate(sub);
        }
    }
}
