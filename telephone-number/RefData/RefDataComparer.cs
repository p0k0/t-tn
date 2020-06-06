using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Storage
{
    public class RefDataComparer
    {
        /*
         given:
         refData A = "12345"
         refData B = "12397"
         assume:
         comparer(A,B) return "***97"
         or 
         A.Compare(B) return "***97" //return part of B that different from A
         B.Compare(A) return "***45"//return part of A that different from B
         '*' means that some part(lead part only) are mached


        given :
        refData A = "12345"
        refData B = "397"

        A.Compare(B) return "397" //return part of B that different from A
        B.Compare(A) return "12345" //return part of A that different from B

        no '*' mean absent any lead-maching

         */

        public string Compare(RefData a, RefData b)
        {
            var bHead = b;
            var aHead = a;
            var visitor = new FindVisitor(bHead);
            var traverser = new RefDataDownsideTraverseWithCondition();
            var matchedParts = string.Empty;

            for (var matchSuccess = true;
                 matchSuccess;
                 matchSuccess = traverser.Traverse(aHead, visitor))
            {
                matchedParts += "*";

                aHead = aHead.SubNodes.FirstOrDefault();
                bHead = bHead.SubNodes.FirstOrDefault();

                visitor = new FindVisitor(bHead);
            }

            //accumulateTraverser(bHead).Traverse -> 
            var accumulateTraverser = new RefDataDownsideAccumulateTraverseWithStraightBranch(bHead);
            var remainPartVisitor = new AccumulateVisitor();
            accumulateTraverser.Traverse(bHead, remainPartVisitor);

            matchedParts += remainPartVisitor.GetTraversedPath();

            return matchedParts;
        }
    }
}
