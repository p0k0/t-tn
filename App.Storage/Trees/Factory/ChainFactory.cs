using System.Linq;
using Trees.Node;

namespace Trees.Factory
{
    public class ChainFactory
    {
        public ChainNode DeepCopy(INode node)
        {
            if (node == null)
                return null;

            var newNode = new ChainNode
            {
                Data = node.Data,
                HasVisited = node.HasVisited
            };

            newNode.AppendSub(DeepCopy(node.SubNodes.SingleOrDefault()));

            return newNode;
        }

        public ChainNode ShallowCopy(INode node)
        {
            if (node == null)
                return null;

            var newNode = new ChainNode
            {
                Data = node.Data,
                HasVisited = node.HasVisited
            };

            return newNode;
        }

        public ChainNode Create(string number)
        {
            var head = default(ChainNode);
            var node = default(ChainNode);
            var newNode = default(ChainNode);

            head = node = new ChainNode { Data = number[0] };

            foreach (var digit in number.Skip(1))
            {
                newNode = new ChainNode { Data = digit };
                node.AppendSub(newNode);
                node = node.SubNodes[0] as ChainNode;
            }

            return head as ChainNode;
        }
    }
}
