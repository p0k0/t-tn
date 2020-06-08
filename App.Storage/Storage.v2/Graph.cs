using System;
using System.Collections.Generic;

namespace Storage.v2
{
    public class Graph
    {
        public IDictionary<int, IDictionary<int, char>> Adj;

        public Graph()
        {
            Adj = new Dictionary<int, IDictionary<int, char>>();
        }

        public void AddVertices(string vertices)
        {
            int vPrev = 0;
            int vNext = 0;

            var v = int.Parse(vertices[0].ToString());
            AddVertex(v);

            vNext = int.Parse(vertices[1].ToString());
            AddAdjVertex(v, vNext);

            for (int vCurrInd = 1; vCurrInd < vertices.Length; vCurrInd++)
            {
                v = int.Parse(vertices[vCurrInd].ToString());
                AddVertex(v);

                vPrev = int.Parse(vertices[vCurrInd - 1].ToString());
                AddAdjVertex(v, vPrev);

                if (vCurrInd < vertices.Length - 1)
                {
                    vNext = int.Parse(vertices[vCurrInd + 1].ToString());
                    AddAdjVertex(v, vNext);
                }
            }
        }

        private void AddAdjVertex(int vFrom, int vTo)
        {
            Adj[vFrom].Add(vTo, '1');
        }

        public void AddVertex(int v)
        {
            if (!Adj.ContainsKey(v))
            {
                Adj.Add(v, new Dictionary<int, char>());
            }
        }
    }
}
