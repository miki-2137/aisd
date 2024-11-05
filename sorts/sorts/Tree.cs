using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace sorts
{
    internal class Tree
    {
        public NodeT korzen;

        public void AddInto(NodeT node)
        {
            if (this.korzen == null)
            {
                this.korzen = node;
            }
            else
            {
                Add(node, this.korzen);
            }
        }

        public void Add(NodeT node, NodeT korzen)
        {
            if (node.data < korzen.data)
            {
                if (korzen.lewe != null)
                {
                    Add(node, korzen.lewe);
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
                    Add(node, korzen.prawe);
                }
                else
                {
                    korzen.prawe = node;
                }
            }
        }

        public void InOrder(NodeT root)
        {
            if (root.lewe != null)
            {
                InOrder(root.lewe);
            }
            Console.WriteLine(root.data);
            if (root.prawe != null)
            {
                InOrder(root.prawe);
            }
        }

        public static void Main(string[] args)
        {
            Tree tr = new Tree();
            tr.AddInto(new NodeT(5));
            tr.AddInto(new NodeT(3));
            tr.AddInto(new NodeT(7));
            tr.AddInto(new NodeT(1));
            tr.AddInto(new NodeT(9));

            /*Console.WriteLine(tr.korzen.data);
            Console.WriteLine(tr.korzen.lewe.data);
            Console.WriteLine(tr.korzen.prawe.data);*/
            tr.InOrder(tr.korzen);
        }
    }
}
