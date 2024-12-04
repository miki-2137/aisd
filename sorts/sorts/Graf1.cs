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

        public Graf1 Kruskal()
        {
            var krawedzie = this.edges.OrderBy(k => k.weight).ToList();
            var grafy = new List<Graf1>() { new Graf1(krawedzie[0]) };

            for(int i = 1; i < krawedzie.Count; i++)
            {
                var k = krawedzie[i];
                var l = -1;

                for(int j=0;j<grafy.Count; j++)
                {
                    var g = grafy[j];
                    switch (g.IleNowych(k))
                    {
                        case 2:
                            grafy.Add(new Graf1(k));
                            j = grafy.Count;
                            break;
                        case 0:
                            j = grafy.Count;
                            break;
                        case 1:
                            if (l == -1)
                            {
                                g.Add(k);
                                l = j;
                            }
                            else
                            {
                                grafy[l].Join(g);
                                grafy.RemoveAt(j);
                                j = grafy.Count;
                                break;
                            }
                    }
                }
            }
            return grafy[0];
        }
        public PrzygotujTabelke(NodeG1 start)//dokonczyc
        {
            return;
        }
        public List<Element> Dijkstra(NodeG1 start)
        {
            var tabelka = this.PrzygotujTabelke(start);
            var zbS = new List<NodeG1>();
            var kandydaci = tabelka.Where(e => !zbS.Contains(e.wezel));
            var kandydat = kandydaci.OrderBy(e => e.dystans).First();
            var sasiedzi = this.edges.Where(k => k.start == kandydat.wezel).ToList();
        }
    }
}
