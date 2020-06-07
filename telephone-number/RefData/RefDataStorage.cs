using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Storage
{
    public class RefDataStorage // compactifyed refData groups, where two group with same lead digits can use same data
    {
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

         */

        internal public RefDataStorage()
        {

        }
    }
}
