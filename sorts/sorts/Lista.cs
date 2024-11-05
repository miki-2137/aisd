using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace sorts
{
    internal class Lista
    {
        public NodeL head;
        public NodeL tail;
        public int count;
        public void AddFirst(int data)//head zamiast tail
        {
            NodeL n = new NodeL(data);
            this.head.prev = n;
            n.next=this.head;
            this.count++;
            this.head = n;
        }
        public void AddLast(int data)
        {
            NodeL n = new NodeL(data);
            this.tail.next = n;
            n.prev = this.tail;
            this.count++;
            this.tail = n;
        }
        public void RemoveFirst() { }
        public void RemoveLast() { }//to samo ale od konca
        /*Node Get(int index)
        {
            Node obecny = this.head;
            while (obecny != this.tail)
            {
                obecny = obecny.next;
            }
        }*/
        //string ToString(int data) { }
    }
}
