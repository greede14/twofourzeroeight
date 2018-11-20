using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace twozerofoureight
{
    class TwoZeroFourEightModel : Model
    {
        protected int boardSize; // default is 4
        protected int[,] board;
        protected Random rand;
        public int boardsize = 0;
        public bool isfull = true;
        public int score = 0;
        public TwoZeroFourEightModel() : this(4)
        {
            // default board size is 4 
        }

        public int GetScore()
        {
            score = 0;
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    score += board[i, j];
                }
            }
            return score;
        }
        public int[,] GetBoard()
        {
            return board;
        }

        public TwoZeroFourEightModel(int size)
        {
            boardSize = size;
            board = new int[boardSize, boardSize];
            var range = Enumerable.Range(0, boardSize);
            foreach (int i in range)
            {
                foreach (int j in range)
                {
                    board[i, j] = 0;
                }
            }
            rand = new Random();
            board = Random(board);
            NotifyAll();
        }

        private void checkfull()
        {
            boardsize = 0;
            isfull = false;

            for (int i =0;i<4;i++)
                {
                    for (int j =0;j<4;j++)
                    {
                        if (board[j, i] != 0)
                        {

                            boardsize++;
                            if (boardsize >= 16)
                            {
                                boardsize = 16;
                            
                            break;
                            }
                            
                        }
                  //  score += board[i, j];
                    
                    }
                }
            
            

        }

        private int[,] Random(int[,] input)
        {
            while (true)
            {
                int x = rand.Next(boardSize);
                int y = rand.Next(boardSize);
                 int temp = 0;

                if (board[x, y] == 0)
                {
                    board[x, y] = 2;
                    break;
                }
                else
                {

                    while (board[x, y] != 0)
                    {
                        temp++;
                        x = rand.Next(boardSize);
                        y = rand.Next(boardSize);
                        if (board[x, y] == 0)
                        {
                            board[x, y] = 2;
                            break;
                        }
                        else if (temp >= 16) break;
                    }
                    break;
                }
            }
            checkfull();
            return input;
        }

        public void PerformDown()
        {
            int[] buffer;
            int pos;
            int[] rangeX = Enumerable.Range(0, boardSize).ToArray();
            int[] rangeY = Enumerable.Range(0, boardSize).ToArray();
            Array.Reverse(rangeY);
            foreach (int i in rangeX)
            {
                pos = 0;
                buffer = new int[4];
                foreach (int k in rangeX)
                {
                    buffer[k] = 0;
                }
                //shift left
                foreach (int j in rangeY)
                {
                    if (board[j, i] != 0)
                    {
                        buffer[pos] = board[j, i];
                        pos++;
                    }
                }
                // check duplicate
                foreach (int j in rangeX)
                {
                    if (j > 0 && buffer[j] != 0 && buffer[j] == buffer[j - 1])
                    {
                        buffer[j - 1] *= 2;
                        buffer[j] = 0;
                    }
                }
                // shift left again
                pos = 3;
                foreach (int j in rangeX)
                {
                    if (buffer[j] != 0)
                    {
                        board[pos, i] = buffer[j];
                        pos--;
                    }
                }
                // copy back
                for (int k = pos; k != -1; k--)
                {
                    board[k, i] = 0;
                }
            }
            board = Random(board);
            NotifyAll();
        }

        public void PerformUp()
        {
            int[] buffer;
            int pos;
            int[] range = Enumerable.Range(0, boardSize).ToArray();
            foreach (int i in range)
            {
                pos = 0;
                buffer = new int[4];
                foreach (int k in range)
                {
                    buffer[k] = 0;
                }
                //shift left
                foreach (int j in range)
                {
                    if (board[j, i] != 0)
                    {
                        buffer[pos] = board[j, i];
                        pos++;
                    }
                }
                // check duplicate
                foreach (int j in range)
                {
                    if (j > 0 && buffer[j] != 0 && buffer[j] == buffer[j - 1])
                    {
                        buffer[j - 1] *= 2;
                        buffer[j] = 0;

                    }
                    
                }
                // shift left again
                pos = 0;
                foreach (int j in range)
                {
                    if (buffer[j] != 0)
                    {
                        board[pos, i] = buffer[j];
                        pos++;
                    }
                }
                // copy back
                for (int k = pos; k != boardSize; k++)
                {
                    board[k, i] = 0;
                }
            }
            board = Random(board);
            NotifyAll();
        }

        public void PerformRight()
        {
            int[] buffer;
            int pos;
            int[] rangeX = Enumerable.Range(0, boardSize).ToArray();
            int[] rangeY = Enumerable.Range(0, boardSize).ToArray();
            Array.Reverse(rangeX);
            foreach (int i in rangeY)
            {
                pos = 0;
                buffer = new int[4];
                foreach (int k in rangeY)
                {
                    buffer[k] = 0;
                }
                //shift left
                foreach (int j in rangeX)
                {
                    if (board[i, j] != 0)
                    {
                        buffer[pos] = board[i, j];
                        pos++;
                    }
                }
                // check duplicate
                foreach (int j in rangeY)
                {
                    if (j > 0 && buffer[j] != 0 && buffer[j] == buffer[j - 1])
                    {
                        buffer[j - 1] *= 2;
                        buffer[j] = 0;
                        
                    }
                    
                }
                // shift left again
                pos = 3;
                foreach (int j in rangeY)
                {
                    if (buffer[j] != 0)
                    {
                        board[i, pos] = buffer[j];
                        pos--;
                    }
                }
                // copy back
                for (int k = pos; k != -1; k--)
                {
                    board[i, k] = 0;
                }
            }
            board = Random(board);
            NotifyAll();
        }

        public void PerformLeft()
        {
            int[] buffer;
            int pos;
            int[] range = Enumerable.Range(0, boardSize).ToArray();
            foreach (int i in range)
            {
                pos = 0;
                buffer = new int[boardSize];
                foreach (int k in range)
                {
                    buffer[k] = 0;
                }
                //shift left
                foreach (int j in range)
                {
                    if (board[i, j] != 0)
                    {
                        buffer[pos] = board[i, j];
                        pos++;
                    }
                }
                // check duplicate
                foreach (int j in range)
                {
                    if (j > 0 && buffer[j] != 0 && buffer[j] == buffer[j - 1])
                    {
                        buffer[j - 1] *= 2;
                        buffer[j] = 0;
                    }
                }
                // shift left again
                pos = 0;
                foreach (int j in range)
                {
                    if (buffer[j] != 0)
                    {
                        board[i, pos] = buffer[j];
                        pos++;
                    }
                }
                for (int k = pos; k != boardSize; k++)
                {
                    board[i, k] = 0;
                }
            }
            board = Random(board);
            NotifyAll();
        }

        public bool Check()
        {
            bool a = true;
            for (int i = 0; i < boardSize - 1; i++)
            {
                for (int j = 0; j < boardSize - 1; j++)
                {
                    if (board[i, j] == board[i, j + 1] || board[j, i] == board[j + 1, i]|| board[i,j]==0)
                        a = false;
                }
            }
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    if (board[i, j] == 0)
                        a = false;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 3] == board[i + 1, 3] || board[3, i] == board[3, i + 1] )
                    a = false;
            }
            
            return a;
        }

            
                
        
    }
}
