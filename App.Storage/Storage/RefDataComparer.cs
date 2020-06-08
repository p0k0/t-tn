using System;
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
            var visitor = default(FindVisitor);
            var traverser = new RefDataDownsideTraverseWithCondition();
            var matchedParts = new StringBuilder();

            for (var matchSuccess = false; ;)
            {
                visitor = new FindVisitor(bHead);
                matchSuccess = traverser.Traverse(aHead, visitor);

                if (!matchSuccess)
                    break;

                if (aHead == RefData.Null || bHead == RefData.Null )
                    break;

                matchedParts.Append("*");

                if (aHead.SubNodes.FirstOrDefault() == RefData.Null ||
                    bHead.SubNodes.FirstOrDefault() == RefData.Null)
                {
                    aHead = aHead.SubNodes.FirstOrDefault();
                    bHead = bHead.SubNodes.FirstOrDefault();
                    break;
                }

                aHead = aHead.SubNodes.FirstOrDefault();
                bHead = bHead.SubNodes.FirstOrDefault();

            }
            /*
            if (traverser.Traverse(aHead, visitor))
            {
                matchedParts.Append("*");
            }*/

            if (bHead != RefData.Null)
            {
                var accumulateTraverser = new RefDataDownsideAccumulateTraverseWithStraightBranch(bHead);
                var remainPartVisitor = new AccumulateVisitorWithStateAsString();
                accumulateTraverser.Traverse(bHead, remainPartVisitor);

                matchedParts.Append(remainPartVisitor.GetState());
            }

            return matchedParts.ToString();
        }
    }
}
