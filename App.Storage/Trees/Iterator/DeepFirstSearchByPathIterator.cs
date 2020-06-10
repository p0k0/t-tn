using System;
using System.Linq;
using System.Linq.Expressions;
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

        public void FindLastSatisfiedNode(BaseNode startNode, Expression<Func<BaseNode, bool>> predicate, BaseNode straightTraversePathHead)
        {
            if (startNode == null)
                return;

            Visitor.Visit(startNode);
            
            if (predicate.Compile().Invoke(startNode) && 
                straightTraversePathHead != null && !straightTraversePathHead.SubNodes.Any())
                return;

            if (straightTraversePathHead == null)
                return;
            
            foreach (var sub in startNode.SubNodes.Where(x => x.Data == straightTraversePathHead.Data))
                FindLastSatisfiedNode(startNode: sub, predicate, straightTraversePathHead.SubNodes.SingleOrDefault());
        }
    }
}
