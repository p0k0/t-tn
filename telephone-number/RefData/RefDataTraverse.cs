using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Storage
{
    public class RefDataTraverse
    {
        public void Traverse(RefData node, Visitor visitor)
        {
            visitor.Visit(node);
            foreach (var sub in node.SubNodes)
            {
                Traverse(sub, visitor);
            }
        }
    }

    public class RefDataDownsideTraverseWithCondition
    {
        public virtual bool Traverse(RefData node, VisitorWithCondition visitor)
        {
            if (visitor.Visit(node))
                return true;

            foreach (var sub in node.SubNodes)
            {
                if (Traverse(sub, visitor))
                    return true;
            }

            return false;
        }
    }

    //because possible path select when one branch is splitting - in that case we should use some kind of selection logic
    public class RefDataDownsideAccumulateTraverseWithBranch
    {
        private Expression<Func<RefData, bool>> _branchSelectCondition;
        private readonly string _sourceForCompare;

        public RefDataDownsideAccumulateTraverseWithBranch(string sourceForCompare)
        {
            _sourceForCompare = sourceForCompare ?? throw new ArgumentNullException(nameof(sourceForCompare));
        }

        public virtual void Traverse(RefData node, AccumulateVisitor visitor)
        {
            visitor.Visit(node);

            _branchSelectCondition = x => _sourceForCompare
                                            .TrimStart(visitor.GetTraversedPath().ToCharArray())
                                            .StartsWith(x.Data.ToString());

            foreach (var sub in node.SubNodes.Where(_branchSelectCondition.Compile()))
            {
                Traverse(sub, visitor);
            }
        }
    }

    public class RefDataDownsideAccumulateTraverseWithStraightBranch
    {
        private RefData _currentHead;

        public RefDataDownsideAccumulateTraverseWithStraightBranch(RefData sourceHead)
        {
            _currentHead = sourceHead ?? throw new ArgumentNullException(nameof(sourceHead));
        }

        public virtual void Traverse(RefData node, AccumulateVisitor visitor)
        {
            visitor.Visit(node);

            _currentHead = _currentHead.SubNodes.FirstOrDefault();

            foreach (var sub in node.SubNodes.Where(sub => _currentHead != null && sub.Data == _currentHead.Data))
            {
                Traverse(sub, visitor);
            }
        }
    }
}
