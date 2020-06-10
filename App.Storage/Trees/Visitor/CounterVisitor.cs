using Trees.Node;

namespace Trees.Visitor
{
    public class CounterVisitor : IVisitor
    {
        public int Counter { get; private set; }
        
        public void Visit(INode node)
        {
            node.HasVisited = true;
            Counter++;
        }
    }
}
