﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_4
{
    class Human : Player
    {
        string number;
        string type;
        public Human(int number, string type) : base(number, type)
        {
            this.number = number.ToString();
            this.type = type;
        }
        public int move()
        {
            return -9999;
        }

    }
}
