using System;
using System.Collections.Generic;

namespace Storage.v2
{
    public class SparseGraph : SparseVector2D<int, int>
    {
        public void AddVertices(string verticeTraverse)
        {
            var vPrev = int.Parse(verticeTraverse[0].ToString());
            var vCurr = int.Parse(verticeTraverse[1].ToString());

            this[vPrev][vCurr] = 1;

            for (int vCurrInd = 1; vCurrInd < verticeTraverse.Length; vCurrInd++)
            {
                vPrev = int.Parse(verticeTraverse[vCurrInd - 1].ToString());
                vCurr = int.Parse(verticeTraverse[vCurrInd].ToString());
                this[vPrev][vCurr] = 1;
            }
        }
    }
}
