using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_4
{
    class Board 
    {

        Boolean win = false;
        int move;
        int[,] board = new int[7, 7];
        int currentplayer;

        public Board()
        {

            for (int x = 0; x<7; x++)
            {
                for (int y = 0; y < 7; y++)
                {
                    board[x, y] = 0;
                }
            }

        }

        public Boolean checkWin()
        {
            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 2; y++)
                {

                    if (board[x, y] == board[x, y+1] && board[x,y] == board[x, y+2]&& board[x,y] == board[x,y+3] && board[x,y] == board[x,y+4] && board[x,y]!= 0)
                    {
                        win = true;
                    }

                }
            }

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 6; y++)
                {

                    if (board[x, y] == board[x+1, y] && board[x, y] == board[x+2, y] && board[x, y] == board[x+3, y] && board[x, y] == board[x+4, y] && board[x, y] != 0)
                    {
                        win = true;
                    }

                }
            }

            for (int x = 0; x < 7; x++) { 
            }

            return win;
        
        }

        public Boolean checkFilled()
        {

            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    if (board[x, y] == 0)
                    {
                        return false;
                    }
                }
            }
            
            return true;
        }

        public void Getmove(int move, int currentplayer)
        {
            this.move = move;
            this.currentplayer = currentplayer;

        }

        public int[,] getBoard(int[,] GameBoard)
        {
            board = GameBoard;

            for(int y =0; y < 6; y++)
            {
                if (board[move, 5 - y] == 0)
                {
                    board[move, y] = currentplayer;
                    y = 6;
                }

            }

            return board;

        }

    }
}
