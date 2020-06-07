using System.Linq;
using System.Text;

namespace Storage
{
    public class RefDataComparer
    {
        internal RefDataComparer()
        {

        }

        public string Compare(RefData a, RefData b)
        {
            var bHead = b;
            var aHead = a;
            var visitor = new FindVisitor(bHead);
            var traverser = new RefDataDownsideTraverseWithCondition();
            var matchedParts = new StringBuilder();

            for (var matchSuccess = traverser.Traverse(aHead, visitor);
                 matchSuccess;
                 matchSuccess = traverser.Traverse(aHead, visitor), matchedParts.Append("*")
                 )
            {
                aHead = aHead.SubNodes.FirstOrDefault();
                bHead = bHead.SubNodes.FirstOrDefault();

                visitor = new FindVisitor(bHead);
            }

            var accumulateTraverser = new RefDataDownsideAccumulateTraverseWithStraightBranch(bHead);
            var remainPartVisitor = new AccumulateVisitor();
            accumulateTraverser.Traverse(bHead, remainPartVisitor);

            matchedParts.Append(remainPartVisitor.GetTraversedPath());

            return matchedParts.ToString();
        }
    }
}
