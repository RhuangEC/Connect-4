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
        int number;
        int opponentNumber;
        string type;
        int[,] board = new int[7, 6];
        int[] nextSpace = new int[7];
        Boolean[] FullRow = new Boolean[7];
        int badMove = -1;
        int[] paths = new int[7];
        int bestMove;
        int depth;
        int threes;
        int mostThrees;


        public Player(int number, string type)
        {
            this.number = number;
            this.type = type;
            this.opponentNumber = (number + 1) % 2;

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
            return this.number.ToString();
        }

        public string PlayerType()
        {
            return this.type;
        }

        public int RandomMove()
        {
            Random rnd = new Random();
            move = rnd.Next(0, 6);

            while (FullRow[move] == true)
            {
                move = rnd.Next(0, 6);
                findNextSpaces();
            }

            return move;
        }
        public void getBoard(int[,] board)
        {
            this.board = board;
        }

        public int CalculateMove()
        {
            findNextSpaces();

            move = tryMoves(number);

            if(depth == 7)
            {
                threes = countThrees(board);
            }

            if (move == -1)
            {
                move = tryMoves(opponentNumber);
            }

            if (move == -1)
            {
                move = RandomMove();

                do
                {
                    board[move, nextSpace[move]] = number;
                    if (tryMoves(opponentNumber) != -1)
                    {
                        badMove = move;
                        move = RandomMove();
                    }
                } while (badMove == move);
            }

            return move;
        }

        public int[,] makeMoveOnBoard(int[,] board)
        {
            this.board = board;
            return this.board;
        }

        public int tryMoves(int number)
        {
            mostThrees = 0;
            bestMove = 0;

            for (int x = 0; x < 7; x++)
            {
                if (FullRow[x] == false)
                {
                    board[x, nextSpace[x]] = number;

                }
                 
                if (checkForWin(board))
                {
                    board[x, nextSpace[x]] = 0;
                    
                    return x;
                   
                }

                if (FullRow[x] == false)
                {
                    board[x, nextSpace[x]] = 0;
                }
               
            }

            return bestMove;
        }

        public void findNextSpaces()
        {

            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 6; y++)
                {

                    if (board[x, y] == 0)
                    {
                        nextSpace[x] = y;
                        break;
                    }
                    if (board[x, 5] != 0)
                    {
                        FullRow[x] = true;
                    }

                }
            }

        }

        public Boolean checkForWin(int[,] board)
        {
            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 3; y++)
                {

                    if (board[x, y] != 0 && board[x, y] == board[x, y + 1] && board[x, y] == board[x, y + 2] && board[x, y] == board[x, y + 3])
                    {

                        return true;
                    }

                }
            }

            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 6; y++)
                {

                    if (board[x, y] != 0 && board[x, y] == board[x + 1, y] && board[x, y] == board[x + 2, y] && board[x, y] == board[x + 3, y])
                    {
                        return true;
                    }

                }
            }

            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 3; y++)
                {

                    if (board[x, y] != 0 && board[x, y] == board[x + 1, y + 1] && board[x, y] == board[x + 2, y + 2] && board[x, y] == board[x + 3, y + 3])
                    {
                        return true;
                    }

                }
            }

            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (board[6 - x, y] != 0 && board[6 - x, y] == board[(6 - x) - 1, y + 1] && board[6 - x, y] == board[(6 - x) - 2, y + 2] && board[6 - x, y] == board[(6 - x) - 3, y + 3])
                    {

                        return true;
                    }
                }
            }

            return false;
        }

        public int countThrees(int[,] board)
        {
            int count = 0;


            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    int spaces = 0;

                    if (board[x, y] != 0 && board[x, y] == board[x, y + 1] || board[x, y +1] == 0)
                    {
                        if(board[x, y +1] == 0)
                        {
                            spaces++;
                        }

                        if(board[x, y] == board[x, y + 2] || board[x, y + 2] == 0 && spaces == 0)
                        {
                        
                            if(board[x, y + 2] == 0)
                            {
                                spaces++;
                            }

                            if(board[x, y] == board[x, y + 3] || board[x, y + 3] == 0 && spaces == 0)
                            {
                             
                                count++;

                            }

                        }

                    }

                }
            }

            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    int spaces = 0;

                    if ((board[x, y] != 0 && board[x, y] == board[x + 1, y]) || (board[x + 1, y] == 0 && spaces == 0))
                    {
                        if (board[x + 1, y] == 0)
                        {
                            spaces++;
                        }

                        if ((board[x, y] == board[x + 2, y]) || (board[x + 2, y] == 0 && spaces < 2))
                        {
                            if (board[x + 2, y] == 0)
                            {
                                spaces++;
                            }

                            if ((board[x, y] == board[x + 3, y]) || (board[x + 3, y] == 0 && spaces < 2))
                            {
                                count++;
                            }

                        }

                    }
                }
            }

            for (int x = 0; x < 4; x++)
			{
                for (int y = 0; y < 3; y++)
			    {
                    int spaces = 0;

                    if(board[x,y] == board[x+1,y+1] && board[x, y] != 0 || board[x+1, y+1] == 0)   
                    {
                        if(board[x+1, y+1] == 0)
                        {
                            spaces++;
                        }            
                        
                        if(board[x,y] == board[x + 2,y + 2] || (board[x+2,y+2] == 0 && spaces == 2))    
                        {     
                            if(board[x+2, y+2] == 0)
                            {
                                spaces++;
                            }

                            if(board[x, y] == board[x+3, y+3] || board[x + 3, y + 3] == 0 && spaces == 0)
                            {
                                count++;
                            }

                        }

                    }

			    }
			}


            return count;
        }

        public int recursionMiniMax(int[,] board)
        {
            bestMove = CalculateMove();

            if (checkForWin(board) == true)
            {
                return bestMove;
            }
            else if(checkForWin(board) == false && depth < 8)
            {
                recursionMiniMax(board);

                return bestMove;
            }
            else
            {
                return bestMove;
            }
        }
    }
}

