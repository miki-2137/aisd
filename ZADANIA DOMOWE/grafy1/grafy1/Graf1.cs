using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace grafy1
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
            this.nodes = new List<NodeG1>() { k.start, k.end };
            this.edges = new List<Edge>() { k };
        }

        public int IleNowych(Edge k)
        {
            bool startExists = this.nodes.Contains(k.start);
            bool endExists = this.nodes.Contains(k.end);

            if (startExists && endExists)
            {
                return 0; // Both nodes already exist
            }
            else if (startExists || endExists)
            {
                return 1; // One of the nodes already exists
            }
            else
            {
                return 2; // Neither of the nodes exists
            }
        }

        public void Add(Edge k)
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
            foreach (var edge in g1.edges)
            {
                this.Add(edge);
            }
        }

        public Graf1 Kruskal()
        {
            var krawedzie = this.edges.OrderBy(k => k.weight).ToList();
            var grafy = new List<Graf1>() { new Graf1(krawedzie[0]) };

            for (int i = 1; i < krawedzie.Count; i++)
            {
                var k = krawedzie[i];
                var l = -1;

                for (int j = 0; j < grafy.Count; j++)
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
                            break;
                    }
                }
            }
            return grafy[0];

        }

        public List<Element> PrzygotujTabelke(NodeG1 start)
        {
            var tabelka = new List<Element>();

            foreach (var node in nodes)
            {
                int dystans = node == start ? 0 : int.MaxValue;
                tabelka.Add(new Element(node, dystans, null));
            }

            return tabelka;
        }

        public List<Element> Dijkstra(NodeG1 start)
        {
            var tabelka = this.PrzygotujTabelke(start);
            var zbS = new List<NodeG1>();

            while (zbS.Count < nodes.Count)
            {
                var kandydaci = tabelka.Where(e => !zbS.Contains(e.wezel));
                var kandydat = kandydaci.OrderBy(e => e.dystans).First();
                zbS.Add(kandydat.wezel);

                var sasiedzi = this.edges.Where(k => k.start == kandydat.wezel).ToList();
                foreach (var edge in sasiedzi)
                {
                    var sasiedniElement = tabelka.First(e => e.wezel == edge.end);
                    int nowyDystans = kandydat.dystans + edge.weight;

                    if (nowyDystans < sasiedniElement.dystans)
                    {
                        sasiedniElement.dystans = nowyDystans;
                        sasiedniElement.poprzednik = kandydat.wezel;
                    }
                }
            }

            return tabelka;
        }

        static void Main(string[] args)
        {
            var node1 = new NodeG1(1);
            var node2 = new NodeG1(2);
            var node3 = new NodeG1(3);
            var node4 = new NodeG1(4);

            var edge12 = new Edge(node1, node2, 3);
            var edge13 = new Edge(node1, node3, 7);
            var edge23 = new Edge(node2, node3, 5);
            var edge24 = new Edge(node2, node4, 4);
            var edge34 = new Edge(node3, node4, 1);

            var nodes = new List<NodeG1>() { node1, node2, node3, node4 };
            var edges = new List<Edge>() { edge12, edge13, edge23, edge24, edge34 };

            var graf = new Graf1(nodes, edges);

            var spinajace = graf.Kruskal();

            Console.WriteLine("minimalne drzewo spinajace:");
            foreach (var edge in spinajace.edges)
            {
                Console.WriteLine($"krawedz {edge.start.data}{edge.end.data} z waga {edge.weight}");
            }

            var shortestPaths = graf.Dijkstra(node1);

            // Print the shortest paths
            Console.WriteLine("najkrotsze sciezki z node1:");
            foreach (var element in shortestPaths)
            {
                string poprzednik = element.poprzednik != null ? element.poprzednik.data.ToString() : "brak";
                Console.WriteLine($"node: {element.wezel.data}, dystans: {element.dystans}, poprzednik: {poprzednik}");
            }
        }
    }
}
