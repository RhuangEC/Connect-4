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
        const int win = 9999;
        const int lose = -9999;
        int strength;
        int number;
        string type;

        public AI(int number, string type): base(number, type)
        {
            this.number = number;
            this.type = type;
        }

        public int GetMove()
        {

            move = RandomMove();

            return move;
        }

        public int RandomMove()
        {
            Random rnd = new Random();

            move = rnd.Next(0, 6);

            

            return move;
        }

        public void CalculateMove()
        {

        }

    }
}
