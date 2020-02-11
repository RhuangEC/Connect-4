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
        string type;
        int[,] board = new int[7, 6];

        public Player(string number, string type)
        {
            this.number = number;
            this.type = type;

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
        
        public string PlayerType()
        {
            return this.type;
        }

        public int RandomMove() 
        {
            Random rnd = new Random();
            move = rnd.Next(0, 6);

            return move;
        }

        public int CalculateMove(int[,] board)
        {

            this.board = board;


            return move;
        }

    }
}
