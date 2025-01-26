using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace huffman
{
    internal class Node
    {
        public char znak;
        public uint czestosc;
        public Node lewe, prawe;

        public Node(char znak, uint czestosc)
        {
            lewe = prawe = null;
            this.znak = znak;
            this.czestosc = czestosc;
        }
    }
}
