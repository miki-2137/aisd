using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace huffman
{
    internal class NodeCompare : IComparer<Node>
    {
        public int Compare(Node x, Node y)
        {
            return x.czestosc.CompareTo(y.czestosc);
        }
    }
}
