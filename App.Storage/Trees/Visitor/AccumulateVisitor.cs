using System;
using System.Collections.Generic;
using System.Text;

namespace Trees.Visitor
{
    public class AccumulateVisitor
    {
        public StringBuilder TraversedPath { get; set; }

        public AccumulateVisitor()
        {
            TraversedPath = new StringBuilder();
        }

        public void Visit(Node node)
        {
            node.HasVisited = true;
            TraversedPath.Append(node.Data);
        }
    }
}
