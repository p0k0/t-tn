using System;
using System.Linq;
using System.Linq.Expressions;
using Trees.Node;
using Trees.Visitor;

namespace Trees
{
    public class DeepFirstSearchByPathIterator
    {
        public AccumulatePathAsNodeVisitor Visitor { get; protected set; }

        public DeepFirstSearchByPathIterator()
        {
            Visitor = new AccumulatePathAsNodeVisitor();
        }

        public void FindLastSatisfiedNode(INode startNode, Expression<Func<INode, bool>> predicate, INode straightTraversePathHead)
        {
            if (startNode == null)
                return;

            Visitor.Visit(startNode);
            
            if (straightTraversePathHead == null ||
                straightTraversePathHead != null && !straightTraversePathHead.SubNodes.Any() && predicate.Compile().Invoke(startNode))
                return;

            foreach (var sub in startNode.SubNodes.Where(x => x.Data == straightTraversePathHead.Data))
                FindLastSatisfiedNode(startNode: sub, predicate, straightTraversePathHead.SubNodes.SingleOrDefault());
        }
    }
}
