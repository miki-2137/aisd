using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grafy
{
    internal class NodeG
    {
        public List<NodeG> sasiedzi = new List<NodeG>();
        public int data;

        public NodeG(int data)
        {
            this.data = data;
        }

        public override string ToString()
        {
            return this.data.ToString();
        }

        public void DodajSasiada(NodeG sasiad)
        {
            if (!this.sasiedzi.Contains(sasiad))
            {
                this.sasiedzi.Add(sasiad);
            }
        }

        public void BFS()
        {
            var visited = new List<NodeG>();
            var queue = new Queue<NodeG>();
            queue.Enqueue(this);
            visited.Add(this);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                Console.WriteLine(current.data);

                foreach (var neighbor in current.sasiedzi)
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }
        }

        public void DFS(List<NodeG> visited = null)
        {
            if (visited == null)
            {
                visited = new List<NodeG>();
            }

            visited.Add(this);
            Console.WriteLine(this.data);

            foreach (var neighbor in this.sasiedzi)
            {
                if (!visited.Contains(neighbor))
                {
                    neighbor.DFS(visited);
                }
            }
        }

        public void Move()
        {
            Console.WriteLine("BFS:");
            this.BFS();

            Console.WriteLine("\nDFS:");
            this.DFS();
        }

        static void Main(string[] args)
        {
            var nodeA = new NodeG(0);
            var nodeB = new NodeG(1);
            var nodeC = new NodeG(2);
            var nodeD = new NodeG(3);

            nodeA.DodajSasiada(nodeB);
            nodeA.DodajSasiada(nodeC);
            nodeB.DodajSasiada(nodeD);
            nodeC.DodajSasiada(nodeD);

            var graph = new Graf();
            graph.nodes.Add(nodeA);
            graph.nodes.Add(nodeB);
            graph.nodes.Add(nodeC);
            graph.nodes.Add(nodeD);

            // Perform graph traversals
            nodeA.Move();
        }
    }
}
