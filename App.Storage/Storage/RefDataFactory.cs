using System.Linq;

namespace Storage
{
    public class RefDataFactory
    {
        public RefData Create(char data) => new RefData(data);

        public RefData CreateRoot() => RefData.EmptyRoot;

        public RefDataComparer CreateComparer() => new RefDataComparer();

        public RefData Create(string number)
        {
            var head = default(RefData);
            var node = default(RefData);
            foreach (var digit in number)
            {
                if (node != null)
                {
                    node.AppendSub(Create(digit));
                    node = node.SubNodes.FirstOrDefault();
                }
                else
                {
                    node = Create(digit);
                    head = node;
                }
            }

            return head;
        }

        public RefDataStorage CreateStorage()
        {
            return new RefDataStorage();
        }
    }
}
