using Trees.Node;

namespace Trees.Visitor
{
    public interface IVisitor
    {
        void Visit(INode node);
    }
}
