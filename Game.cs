using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_4
{
    class Game
    {
        private string type;
        public Board gameBoard;
        string PlayerOne;
        string PlayerTwo;
        Player currentplayer;
        Player[] p = new Player[2];
        int playercounter = 0;
        int move;
        int playerNumber;
        int[,] board = new int[7, 6];

        public Game(string gametype, string playerOne, string playerTwo)
        {
            type = gametype;
            PlayerOne = playerOne;
            PlayerTwo = playerTwo;
            gameBoard = new Board();

            p[0] = new Player(PlayerOne);
            p[1] = new Player(PlayerTwo);

            currentplayer = p[1];

        }   

        public void getmove()
        {

            currentplayer = p[(playercounter + 1) % 2];
            move = currentplayer.makemove();


        }

        public void MakeMove()
        {
            if (currentplayer == p[0])
            {
                playerNumber = 1;
            }
            if (currentplayer == p[1])
            {
                playerNumber = 2;
            }

            gameBoard.Getmove(move, playerNumber);
        
        }

        public int[,] updateboard()
        {

            board = gameBoard.getBoard();

            return board;
        }

        public string LastMove()
        {
            if (currentplayer.PlayerType() == "human")
            {
                return "human";
            }
            else
            {
                return "AI";
            }
        }

        public Boolean status()
        {
            return gameBoard.checkWin();

        }
        public string Outcome()
        {
            if (gameBoard.checkWin())
            {
                return "WIN";
            }
            if (gameBoard.checkFilled())
            {
                return "draw";
            }
            else
            {
                return "error";
            }
        }
    }
}
