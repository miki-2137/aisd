using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sorty
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
        /*napisac przechodzenie wszerz(dwie petle, jedna po nowej liscie, druga po sosiadach danego wezla;wierzcolek jako parametr) 
         i wglab(rekurencja;wierzcholek i lista jako parametry)*/
        public void Move(NodeG a)
        {
            List<NodeG> odwiedzone = new List<NodeG>();
            for(int i = 0; i < this.sasiedzi.Count; i++)
            {

            }
        }
    }
}
