using System.Linq;


namespace Trees.Factory
{
    public class ChainFactory
    {
        public Node DeepCopy(Node node)
        {
            if (node == null)
                return null;

            var newNode = new Node
            {
                Data = node.Data,
            };

            newNode.AppendSub(DeepCopy(node.SubNodes.SingleOrDefault()));

            return newNode;
        }

        public Node ShallowCopy(Node node)
        {
            if (node == null)
                return null;

            var newNode = new Node
            {
                Data = node.Data,
            };

            return newNode;
        }

        public (Node head, Node tail) CreateWithHeadAndTail(string number)
        {
            var head = default(Node);
            var node = default(Node);
            var newNode = default(Node);

            head = node = new Node { Data = number.FirstOrDefault() };

            foreach (var digit in number.Skip(1))
            {
                newNode = new Node { Data = digit };
                node.AppendSub(newNode);
                node = node.SubNodes.First() as Node;
            }

            return (head, node);
        }

        public Node Create(string number) =>
            CreateWithHeadAndTail(number).head;
        
    }
}
