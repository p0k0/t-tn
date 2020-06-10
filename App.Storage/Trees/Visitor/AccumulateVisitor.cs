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

        public AccumulateVisitor(string traversedPath)
        {
            TraversedPath = new StringBuilder(traversedPath);
        }

        public AccumulateVisitor(AccumulateVisitor another)
        {
            TraversedPath = new StringBuilder(another.ToString());
        }

        public void Visit(Node node)
        {
            node.HasVisited = true;
            TraversedPath.Append(node.Data);
        }

        public override bool Equals(object obj)
        {
            return ToString().Equals( ((AccumulateVisitor)obj).ToString() );
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
