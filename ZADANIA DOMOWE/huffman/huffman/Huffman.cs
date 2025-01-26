using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace huffman
{
    internal class Huffman
    {
        static void DrukujKody(Node korzen, string kod)
        {
            if (korzen == null)
                return;

            if (korzen.znak != '$')
                Console.WriteLine(korzen.znak + ": " + kod);

            DrukujKody(korzen.lewe, kod + "0");
            DrukujKody(korzen.prawe, kod + "1");
        }

        static void KodyHuffmana(char[] znaki, uint[] czestosci, int rozmiar)
        {
            Node lewe, prawe, szczyt;
            var kopiec = new SortedSet<Node>(new NodeCompare());

            for (int i = 0; i < rozmiar; ++i)
                kopiec.Add(new Node(znaki[i], czestosci[i]));

            while (kopiec.Count != 1)
            {
                lewe = kopiec.Min;
                kopiec.Remove(lewe);

                prawe = kopiec.Min;
                kopiec.Remove(prawe);

                szczyt = new Node('$', lewe.czestosc + prawe.czestosc);
                szczyt.lewe = lewe;
                szczyt.prawe = prawe;

                kopiec.Add(szczyt);
            }

            DrukujKody(kopiec.Min, "");
        }

        static void Main()
        {
            char[] znaki = { 'A', 'B', 'C', 'D' };
            uint[] czestosci = { 1, 2, 3, 4 };
            int rozmiar = znaki.Length;
            KodyHuffmana(znaki, czestosci, rozmiar);
        }
    }
}
