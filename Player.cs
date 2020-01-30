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
        string type;
        public Player(string type)
        {
            this.type = type;

            if(type == "human")
            {
                Human humanplayer = new Human();
            }

            if(type == "AI")
            {

            }

        }

        public int getmove()
        {
            
            
            return move;
        }

        public int makemove()
        {


            return move;
        }

        public string PlayerType()
        {
            return this.type;
        }

    }
}
