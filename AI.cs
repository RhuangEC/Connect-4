using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_4
{
    class AI : Player
    {
        int move;
        string number;

        public AI(string number): base(number)
        {
            this.number = number;
        }

    }
}
