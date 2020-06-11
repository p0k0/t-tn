namespace Trees.Factory
{
    public class TreeFactory
    {
        public Node DeepCopy(Node node)
        {
            var newNode = new Node
            {
                Data = node.Data,
            };

            foreach (var sub in node.SubNodes)
                newNode.AppendSub(DeepCopy(sub));

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
    }
}
