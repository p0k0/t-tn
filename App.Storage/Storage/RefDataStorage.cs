using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Storage
{
    public class RefDataStorage // compactifyed refData groups, where two group with same lead digits can use same data
    {
        /*
         root (does not store any data just search entry point)
         |      |      |
         |      |      |
         head1  head2  head3 (telephone number beginning)
         |
         .
         .
         . and so on...

         */

        private RefData _root;
        private RefDataFactory _factory;
        private RefDataComparer _comparer;


        internal RefDataStorage()
        {
            _factory = new RefDataFactory();
            _root = _factory.CreateRoot();
            _comparer = _factory.CreateComparer();
        }

        public IEnumerable<string> FindCorrelations(string numberPart)
        {
            var node = _factory.Create(numberPart);
            /*
             find at root node
             when traverse root with target path except found nodes via visitor
             itera while that node exists
             */
            yield return string.Empty;
        }


        /*
        1 create number
        2 compare with other existing number (head)
          a. match found - append subtree
          aa.match not found - new head
         */

        /*
         required feature:
         1. autocopletition 
         2. memory manage as RefData (don't repeat leading digits)

         important note:
         case:
           store same number:
           - store number of user1 as '1234'
           - store number of user2 as '1234'
           assume that we store '1234' but save both user?
         */
        public RefData Save(string number)
        {
            var node = _factory.Create(number);

            var resultString = _comparer.Compare(_root, node);
            var compareResult = _factory.Create(resultString);

            if (compareResult == node)//this mean that given node does not still exists
                _root.AppendSub(node);
            /*else
            {
                var branchRemainPart = node - separatePoint;
                separatePoint.AppendSub(branchRemainPart);
            }*/

            return node;
        }

        public int GetMemoryComsumption()
        {
            throw new NotImplementedException();
        }
    }
}
