using System.Linq;
using Trees.Iterator;

namespace Trees
{
    public class ChainNode : TreeNode
    {
        public ChainNode() : base()
        {

        }

        public static ChainNode Emtpy => new ChainNode { Data = char.MinValue };

        /*
         minus operator act like this:
         a -> b -> c -> d (minuend)
         a -> b           (subtrahend)
                   c -> d (result)
             
         */

        public static ChainNode operator - (ChainNode minuend, ChainNode subtrahend)
        {
            var iterator = new ChainMinusIterator();
            
            return iterator.Minus(minuend, subtrahend) as ChainNode;
        }
    }
}
