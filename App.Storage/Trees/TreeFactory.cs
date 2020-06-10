using System.Linq;

namespace Trees
{
    public class TreeFactory
    {
        public Node Create(string number)
        {
            var head = default(Node);
            var node = default(Node);
            var newNode = default(Node);

            head = node = new Node { Data = number[0] };

            foreach (var digit in number.Skip(1))
            {
                newNode = new Node { Data = digit };
                node.AppendSub(newNode);
                node = node.SubNodes[0];
            }

            return head;
        }
    }
}
