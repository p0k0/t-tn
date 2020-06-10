using System.Collections.Generic;

namespace Trees.Node
{
    public interface INode
    {
        INode Parent { get; set; }
        IList<INode> SubNodes { get; set; }
        char Data { get; set; }
        bool HasVisited { get; set; }
    }
}
