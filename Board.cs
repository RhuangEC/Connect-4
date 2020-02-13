using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_4
{
    class Board 
    {
        int move;
        int[,] board = new int[7, 6];
        int currentplayer;
        int[] nextMove = new int[7];

        public Board()
        {

            for (int x = 0; x<7; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    board[x, y] = 0;
                }
            }

        }

        public Boolean checkWin()
        {
            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 3; y++)
                {

                    if (board[x, y] != 0 && board[x, y] == board[x, y+1] && board[x,y] == board[x, y+2]&& board[x,y] == board[x,y+3])
                    {
                        return true;
                    }

                }
            }

            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 6; y++)
                {

                    if (board[x, y] != 0 && board[x, y] == board[x+1, y] && board[x, y] == board[x+2, y] && board[x, y] == board[x+3, y])
                    {
                        return true;
                    }

                }
            }

            for (int x = 0; x < 4; x++) {
                for (int y = 0; y < 3; y++)
                {

                    if (board[x, y] != 0 && board[x, y] == board[x+1, y+1] && board[x, y] == board[x+2, y+2] && board[x, y] == board[x+3, y+3])
                    {

                        return true;
                     
                    }

                }
            }

            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (board[6-x, y] != 0 && board[6-x, y] == board[(6-x) - 1, y + 1] && board[6-x, y] == board[(6-x) - 2, y + 2] && board[6-x, y] == board[(6 - x) - 3, y + 3])
                    {

                        return true;

                    }
                }
            }

            return false;
        
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

        public Boolean IsRowFilled()
        {
            if (board[move, 5] != 0)
            {
                return true;
            }
            return false;
        }

        public void Getmove(int move, int currentplayer)
        {
            this.move = move;
            this.currentplayer = currentplayer;

        }

        public int[,] MoveOnBoard(int[,] GameBoard)
        {
            board = GameBoard;

            for(int y = 0; y < 6; y++)
            {
                if (board[move, y] == 0 )
                {
                    board[move, y] = currentplayer;
                    break;
                }

            }

            return board;

        }

        public void updateBoard(int[,] board)
        {
            this.board = board;

        }

        public int[,] resetBoard()
        {
            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    board[x, y] = 0;
                }
            }

            return board;
        }

    }
}
