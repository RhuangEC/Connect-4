using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_4
{
    class Human : Player
    {
        string number;
        public Human(string number) : base(number)
        {
            this.number = number;
        }
        public int move()
        {
            return 0;
        }

    }
}
