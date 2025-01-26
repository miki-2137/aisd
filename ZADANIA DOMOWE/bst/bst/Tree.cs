using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace bst
{
    internal class Tree
    {
        public NodeT korzen;

        public void Add(NodeT node)
        {
            if (this.korzen == null)
            {
                this.korzen = node;
            }
            else
            {
                AddInto(node, this.korzen);
            }
        }

        public void AddInto(NodeT node, NodeT korzen)
        {
            if (node.data < korzen.data)
            {
                if (korzen.lewe != null)
                {
                    AddInto(node, korzen.lewe);
                }
                else
                {
                    korzen.lewe = node;
                }
            }
            else if (node.data > korzen.data)
            {
                if (korzen.prawe != null)
                {
                    AddInto(node, korzen.prawe);
                }
                else
                {
                    korzen.prawe = node;
                }
            }
        }

        public void InOrder(NodeT korzen)
        {
            if (korzen.lewe != null)
            {
                InOrder(korzen.lewe);
            }
            Console.WriteLine(korzen.data);
            if (korzen.prawe != null)
            {
                InOrder(korzen.prawe);
            }
        }
        public NodeT Remove(NodeT root, int key)
        {
            if (root == null)
            {
                return null;
            }
            if (key < root.data)
            {
                root.lewe = Remove(root.lewe, key);
            }
            else if (key > root.data)
            {
                root.prawe = Remove(root.prawe, key);
            }
            else
            {
                if (root.lewe == null)
                {
                    return root.prawe;
                }
                else if (root.prawe == null)
                {
                    return root.lewe;
                }

                NodeT minNode = FindMin(root.prawe);
                root.data = minNode.data;
                root.prawe = Remove(root.prawe, root.data);
            }
            return root;
        }

        private NodeT FindMin(NodeT node)
        {
            while (node.lewe != null)
            {
                node = node.lewe;
            }
            return node;
        }

        public static void Main(string[] args)
        {
            Tree tr = new Tree();
            tr.Add(new NodeT(5));
            tr.Add(new NodeT(3));
            tr.Add(new NodeT(7));
            tr.Add(new NodeT(1));
            tr.Add(new NodeT(9));

            /*Console.WriteLine(tr.korzen.data);
            Console.WriteLine(tr.korzen.lewe.data);
            Console.WriteLine(tr.korzen.prawe.data);*/
            tr.InOrder(tr.korzen);
            Console.WriteLine("-----");
            tr.Remove(tr.korzen, 5);
            tr.InOrder(tr.korzen);
        }
    }
}
