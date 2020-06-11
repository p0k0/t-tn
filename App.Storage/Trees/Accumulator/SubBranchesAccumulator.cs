using System.Collections.Generic;
using System.Linq;
using Trees.Node;
using Trees.Visitor;

namespace Trees.Accumulator
{
    public class SubBranchesAccumulator
    {
        public IEnumerable<IVisitor> Accumulate(INode startNode, IVisitor accumulateVisitor)
        {
            accumulateVisitor.Visit(startNode);

            if (startNode.SubNodes.Count == 0)
                yield return accumulateVisitor;

            if (startNode.SubNodes.Count == 1)
            {
                foreach (var subResult in Accumulate(startNode.SubNodes.Single(), accumulateVisitor))
                    yield return subResult;
            }

            if (startNode.SubNodes.Count > 1)//больше 2ух ветвей значит копируем аккумулятор и прокидываем в каждую ветвь
            {
                foreach (var sub in startNode.SubNodes)
                    foreach (var x in Accumulate(sub, new AccumulatePathAsStringVisitor(accumulateVisitor)))//yield unwind
                        yield return x;
            }
        }
    }
}
