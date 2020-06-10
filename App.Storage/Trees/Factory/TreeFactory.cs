using System.Linq;
using Trees.Node;

namespace Trees.Factory
{
    public class TreeFactory
    {
        public TreeNode DeepCopy(INode node)
        {
            var newNode = new TreeNode
            {
                Data = node.Data,
                HasVisited = node.HasVisited
            };

            foreach (var sub in node.SubNodes)
                newNode.AppendSub(DeepCopy(sub));

            return newNode;
        }

        public TreeNode ShallowCopy(INode node)
        {
            if (node == null)
                return null;

            var newNode = new TreeNode
            {
                Data = node.Data,
                HasVisited = node.HasVisited
            };

            return newNode;
        }
    }
}
