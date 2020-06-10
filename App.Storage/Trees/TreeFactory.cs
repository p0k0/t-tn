using System.Linq;

namespace Trees
{
    public class TreeFactory
    {
        public StraightTreeNode CreateStraightTree(string number)
        {
            var head = default(BaseNode);
            var node = default(BaseNode);
            var newNode = default(BaseNode);

            head = node = new StraightTreeNode { Data = number[0] };

            foreach (var digit in number.Skip(1))
            {
                newNode = new StraightTreeNode { Data = digit };
                node.AppendSub(newNode);
                node = node.SubNodes[0];
            }

            return head as StraightTreeNode;
        }
    }
}
