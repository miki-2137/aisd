﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sorts
{
    internal class NodeL
    {
        public NodeL next;
        public NodeL prev;
        public int data;

        public NodeL(int data)
        {
            this.data = data;
        }
    }
}