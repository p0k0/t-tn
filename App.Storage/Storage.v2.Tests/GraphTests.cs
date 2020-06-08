using System;
using Xunit;

namespace Storage.v2.Test
{
    public class GraphTests
    {
        [Fact]
        public void Create_graph_with_fourth_vertices_should_success()
        {
            var g = new SparseGraph();
            g.AddVertices("0165");

            Assert.Equal(3, g.Count);
        }

        [Fact]
        public void Created_graph_with_fourth_vertices_should_has_valid_adj_values()
        {
            var g = new SparseGraph();
            g.AddVertices("0165");

            Assert.Equal(1, g[0][1]);
            Assert.Equal(1,    g[1][6]);
            Assert.Equal(1,       g[6][5]);
        }
    }
}
