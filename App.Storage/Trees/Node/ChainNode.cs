using System;

namespace Trees
{
    public class ChainNode : TreeNode
    {
        public ChainNode() : base()
        {

        }

        public static void ValidateRestrictions(TreeNode newSubNode)
        {
            if (newSubNode.SubNodes.Count > 1)
                throw new NotSupportedException();
        }

        public static ChainNode operator - (ChainNode minuend, ChainNode subtrahend)
        {
            
            return new ChainNode();
        }
    }
}
