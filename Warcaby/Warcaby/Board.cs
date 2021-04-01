using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warcaby
{
    public class Board
    {
        private Pawn[,] _board;
        private int size;
        public Pawn[,] board
        {
            get { return _board; }
        }
        public int Size
        {
            get { return size; }
        }
        public Board()
        {
            Console.WriteLine("Please input the size of the board (10-20): ");
            size = Convert.ToInt32(Console.ReadLine());
            _board = new Pawn[size, size];
            InitBoard();
            Console.WriteLine(this.ToString());
        }

        public void InitBoard()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    List<int> allowedRows = new List<int>() { 0, 1, 2, 3, size - 1, size - 2, size - 3, size - 4 };
                    if (allowedRows.Contains(i))
                    {
                        /* sprawdzanie czy wiersz (czyli rzad planszy) jest parzysty*/
                        if (i % 2 == 0)
                        {
                            if (j % 2 == 0)
                            {
                                if (i > size / 2)
                                    board[i, j] = new Pawn(true, i, j);
                                else
                                    board[i, j] = new Pawn(false, i, j);
                            }
                            else
                                board[i, j] = null;
                        }
                        else
                        {
                            /* sprawdzanie czy jest nieparzysty*/
                            if (j % 2 == 1)
                            {
                                if (i > size / 2)
                                    board[i, j] = new Pawn(true, i, j);
                                else
                                    board[i, j] = new Pawn(false, i, j);
                            }
                            else
                                board[i, j] = null;
                        }

                    }
                }
            }
        }

        public override string ToString()
        {
            string b = "";
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (board[i, j] == null)
                        //Console.Write("O ");
                        b += "O ";
                    else
                    {
                        string pionek = board[i, j].IsWhite ? "W " : "B ";
                        //Console.Write(pionek + " ");
                        b += pionek;
                    }
                }
                b += "\n";
            }

            return b;
        }

        public void RemovePawn((int row, int col) pawnCoordinate)
        {
            board[pawnCoordinate.row, pawnCoordinate.col] = null;
        }

        public void MovePawn((int row, int col) pawnCoordinate, (int row, int col) nextCoordinate)
        {

            board[nextCoordinate.row, nextCoordinate.col] = board[pawnCoordinate.row, pawnCoordinate.col];
            board[nextCoordinate.row, nextCoordinate.col].coordinates = Tuple.Create(nextCoordinate.row, nextCoordinate.col);
            board[pawnCoordinate.row, pawnCoordinate.col] = null;
        }
    }

}
