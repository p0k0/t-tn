using System;
using System.Linq;
using System.Linq.Expressions;
using Trees.Node;

namespace Trees.Iterator
{
    public class ChainMinusIterator
    {
        /*
         minus act like this:
         a -> b -> c -> d (minuend)
         a -> b           (subtrahend)
                   c -> d (result)
             
         */

        public INode Minus(INode minuend, INode subtrahend)
        {
            if (minuend == null)
                return null;

            if (subtrahend == null)
                return minuend.SubNodes.SingleOrDefault();

            var subtrahendNextHead = subtrahend.SubNodes.SingleOrDefault();
            var minuendNextHead = subtrahendNextHead != null
                                ? minuend.SubNodes.Where(x => x.Data == subtrahendNextHead.Data).SingleOrDefault()
                                : minuend.SubNodes.Single();
            
            if (minuendNextHead == null)
                return minuend;
            
            if (subtrahendNextHead == null)
                return minuendNextHead;
            
            return Minus(minuendNextHead, subtrahendNextHead);
        }
    }
}
