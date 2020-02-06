using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_4
{
    class Player
    {

        int move;
        string number;

        public Player(string number)
        {
            this.number = number;

        }

        public int getmove()
        {
            
            return move;
        }

        public int makemove()
        {

            return move;
        }

        public string PlayerNumber()
        {
            return this.number;
        }

    }
}
