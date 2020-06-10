using System;
using System.Collections.Generic;

namespace Trees
{
    public class Node
    {
        public Node Parent { get; protected set; }
        public ICollection<Node> SubNodes { get; protected set; }
    }
}
