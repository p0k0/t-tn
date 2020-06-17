using System.Collections.Generic;

namespace Trees
{
    public class Node
    {
        public Node Parent { get; set; }
        public IList<Node> SubNodes { get; set; }
        public char Data { get; set; }

        public Node()
        {
            SubNodes = new List<Node>();
        }

        public virtual void AppendSub(Node newSubNode)
        {
            if (newSubNode == null)
                return;

            newSubNode.Parent = this;
            SubNodes.Add(newSubNode);
        }

        public override bool Equals(object obj)
        {
            return obj is Node node &&
                   Data == node.Data;
        }

        public override int GetHashCode()
        {
            return -301143667 + Data.GetHashCode();
        }

        public static bool operator ==(Node left, Node right)
        {
            return EqualityComparer<Node>.Default.Equals(left, right);
        }

        public static bool operator !=(Node left, Node right)
        {
            return !(left == right);
        }
    }
}
