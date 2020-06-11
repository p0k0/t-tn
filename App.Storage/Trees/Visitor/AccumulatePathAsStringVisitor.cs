using System.Text;
using Trees.Node;

namespace Trees.Visitor
{
    public class AccumulatePathAsStringVisitor : IVisitor
    {
        public StringBuilder TraversedPath { get; set; }

        public AccumulatePathAsStringVisitor()
        {
            TraversedPath = new StringBuilder();
        }

        public AccumulatePathAsStringVisitor(string traversedPath)
        {
            TraversedPath = new StringBuilder(traversedPath);
        }

        public AccumulatePathAsStringVisitor(IVisitor another)
        {
            TraversedPath = new StringBuilder(another.ToString());
        }

        public void Visit(INode node)
        {
            //node.HasVisited = true;
            TraversedPath.Append(node.Data);
        }

        public override bool Equals(object obj)
        {
            return ToString().Equals( ((AccumulatePathAsStringVisitor)obj).ToString() );
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return TraversedPath.ToString();
        }
    }
}
