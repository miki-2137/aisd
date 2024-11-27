using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sorty
{
    internal class Graf1
    {
        public List<NodeG1> nodes;
        public List<Edge> edges;

        public Graf1(List<NodeG1> nodes, List<Edge> edges)
        {
            this.nodes = nodes;
            this.edges = edges;
        }

        public Graf1(Edge k)
        {
            this.edges.Add(k);
        }

        public int IleNowych(Edge k)//dokonczyc
        {
            return;
        }

        public void Add(Edge k)//dokonczyc
        {
            this.edges.Add(k);
            if (!this.nodes.Contains(k.start))
            {
                this.nodes.Add(k.start);
            }
            if (!this.nodes.Contains(k.end))
            {
                this.nodes.Add(k.end);
            }
            if (IleNowych(k) == 2)
            {
                Graf1 g2 = new Graf1(k);
            }
        }

        public void Join(Graf1 g1)
        {
            for(int i=0; i < this.edges.Count; i++)
            {
                this.Add(g1.edges[i]);
            }
        }

        //napisac algorytm kruskala
    }
}
