namespace Trees.Visitor
{
    public class CounterVisitor : IVisitor
    {
        public int Counter { get; private set; }

        public void Visit(BaseNode node)
        {
            node.HasVisited = true;
            Counter++;
        }
    }
}
