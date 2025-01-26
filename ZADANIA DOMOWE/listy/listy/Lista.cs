using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace listy
{
    internal class Lista
    {
        public NodeL head;
        public NodeL tail;
        public int count;

        public void AddFirst(int data)
        {
            NodeL n = new NodeL(data);
            if (this.head == null)
            {
                this.head = n;
                this.tail = n;
            }
            else
            {
                this.head.prev = n;
                n.next = this.head;
                this.head = n;
            }
            this.count++;
        }

        public void AddLast(int data)
        {
            NodeL n = new NodeL(data);
            if (this.tail == null)
            {
                this.head = n;
                this.tail = n;
            }
            else
            {
                this.tail.next = n;
                n.prev = this.tail;
                this.tail = n;
            }
            this.count++;
        }

        public void RemoveFirst()
        {
            if (this.head != null)
            {
                if (this.head == this.tail)
                {
                    this.head = null;
                    this.tail = null;
                }
                else
                {
                    this.head = this.head.next;
                    this.head.prev = null;
                }
                this.count--;
            }
        }

        public void RemoveLast()
        {
            if (this.tail != null)
            {
                if (this.tail == this.head)
                {
                    this.tail = null;
                    this.head = null;
                }
                else
                {
                    this.tail = this.tail.prev;
                    this.tail.next = null;
                }
                this.count--;
            }
        }

        public NodeL Get(int index)
        {
            NodeL obecny = this.head;
            for (int i = 0; i < index; i++)
            {
                obecny = obecny.next;
            }
            return obecny;
        }

        public override string ToString()
        {
            var result = new System.Text.StringBuilder();
            NodeL obecny = this.head;
            while (obecny != null)
            {
                result.Append(obecny.data + " ");
                obecny = obecny.next;
            }
            return result.ToString().Trim();
        }
        static void Main(string[] args)
        {
            Lista lista = new Lista();

            lista.AddFirst(10);
            lista.AddFirst(20);
            lista.AddFirst(30);
            Console.WriteLine(lista.ToString());

            lista.AddLast(40);
            lista.AddLast(50);
            Console.WriteLine(lista.ToString());

            lista.RemoveFirst();
            Console.WriteLine(lista.ToString());

            lista.RemoveLast();
            Console.WriteLine(lista.ToString());

            Console.WriteLine(lista.Get(1).data);
        }
    }
}
