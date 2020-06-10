using System.Collections.Generic;

namespace Trees
{
    public class Node
    {
        public Node Parent { get; protected set; }
        public IList<Node> SubNodes { get; protected set; }
        public char Data { get; set; }
        public bool HasVisited { get; set; }

        public Node()
        {
            SubNodes = new List<Node>();
        }

        public void AppendSub(Node newSubNode)
        {
            newSubNode.Parent = this;
            SubNodes.Add(newSubNode);
        }

        public override bool Equals(object obj)
        {
            return Data.Equals(((Node)obj).Data);
        }

        public override int GetHashCode()
        {
            return Data.GetHashCode();
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
