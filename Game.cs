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
        Player NextPlayer;
        Player[] p = new Player[2];
        int playercounter = 0;
        int move;
        int playerNumber;
        int[,] board = new int[7, 6];

        public Game()
        {
            gameBoard = new Board();
            currentplayer = p[0];
            NextPlayer = p[1];

        }

        public void SetGameType(string gametype, string playerOne, string playerTwo)
        {
            type = gametype;
            PlayerOne = playerOne;
            PlayerTwo = playerTwo;
        }

        public void CreatePlayers()
        {
            if (PlayerOne == "human")
            {
                p[0] = new Human("1", "human");
            }
            else if(PlayerOne == "AI")
            {
                p[0] = new AI("1", "AI");
            }

            if (PlayerTwo == "human")
            {
                p[1] = new Human("2", "human");
            }
            else if (PlayerTwo == "AI")
            {
                p[1] = new AI("2", "AI");
            }

        }

        public void EndOfTurn()
        {
            
            currentplayer = p[playercounter % 2];
            playercounter++;
            NextPlayer = p[playercounter % 2];
        }

        public int[,] MakeMove()
        {
            move = NextPlayer.RandomMove();

            if (NextPlayer == p[0])
            {
                playerNumber = 1;
            }
            if (NextPlayer == p[1])
            {
                playerNumber = 2;
            }
            
                gameBoard.Getmove(move, playerNumber);
                board = gameBoard.MoveOnBoard(board);
                
         

            return board;
        }

        public int[,] updateboard(int[,] board)
        {
            this.board = board;
            gameBoard.updateBoard(this.board);

            return board;
        }

        public Boolean IsHumanMove()
        {
            if (NextPlayer.PlayerType() == "human")
            {
                return true;
            }

            return false;
        }

        public Boolean GameEnded()
        {
            if (gameBoard.checkWin())
            {
                return true;
            }
            return gameBoard.checkFilled();

        }

        public Boolean IsRowFilled()
        {
            return gameBoard.IsRowFilled();
        }
        public string Outcome()
        {
            if (gameBoard.checkWin())
            {
                return "Player " + currentplayer.PlayerNumber() + " WINS";
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

        public int[,] resetBoard()
        {
            currentplayer = p[0];
            NextPlayer = p[1];
            playercounter = 0;

            board = gameBoard.resetBoard();

            return board;
        }

        public Boolean clickable()
        {
            if (NextPlayer.PlayerType() == "AI")
            {
                return false;
            }

            return true;
        }

        public string ShowNextPlayer()
        {
            return NextPlayer.PlayerType();
        }

        public int showMove()
        {
            return move;
        }

    }
}
