namespace Warcaby
{
    public class Ewelina
    {
         public class Board
    {
        private static int n = 10;
        private char[,] board = new char[n, n];
        private const char WhiteField = ' ';
        private const char BlackField= '.';
        private const char BlackPawn = 'B';
        private const char WhitePawn = 'W';
        
        public override string ToString()
        {
            
            string boardToString = "   A B C D E F G H I J " + System.Environment.NewLine;
            for (int row = 0; row < n; row++)
            {
                if (row == n - 1)
                {
                    boardToString += row + 1 + " ";
                }
                else
                {
                    boardToString += row + 1 + "  ";
                }
                
                for (int col = 0; col < n; col++)
                {
                    boardToString += board[row, col] + " ";
                }
                boardToString += System.Environment.NewLine;
            }

            return boardToString;
        }
        
        public void CreateBoard()
        {
            
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (((row + 1) % 2 != 0) && (col + 1) % 2 == 0)
                    {
                        board[row, col] = BlackField;
                    }
                    else if (((row + 1) % 2 == 0) && (col + 1) % 2 != 0)
                    {
                        board[row, col] = BlackField;
                    }
                    else
                    {
                        board[row, col] = WhiteField;
                    }
                }
            }
        }
        
        private void ArrangementWhitePawns(int howManyPawns, int howManyRowsWithPawns)
        {
            Pawn[] whitePawns = new Pawn[howManyPawns];
            for (int i = 0; i < howManyPawns; i++)
            {
                for (int row = 0; row < howManyRowsWithPawns; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        if (board[row, col] == BlackField)
                        {
                            whitePawns[i] = new Pawn(true, (row, col));
                            board[row, col] = WhitePawn;
                        }
                    }
                }
            }
        }
        private void ArrangementBlackPawns(int howManyPawns, int howManyRowsWithPawns)
        {
            Pawn[] blackPawns = new Pawn[howManyPawns];
            for (int i = 0; i < howManyPawns; i++)
            {
                for (int row = n - howManyRowsWithPawns; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        if (board[row, col] == BlackField)
                        {
                            blackPawns[i] = new Pawn(false, (row, col));
                            board[row, col] = BlackPawn;
                        }
                    }
                }
            }
        }

        public void ArrangementPawns()
        {
            int howManyPawns = 2 * n;
            int howManyFieldsForPawnsInRow = n / 2;
            int howManyRowsWithPawns = howManyPawns / howManyFieldsForPawnsInRow;
            ArrangementBlackPawns(howManyPawns, howManyRowsWithPawns);
            ArrangementWhitePawns(howManyPawns, howManyRowsWithPawns);

        }
        
        public void RemovePawn()
        {
            
        }

        public void MovePawn()
        {
            
        }
        
    }
         public class Pawn
         {
             public bool IsWhite { get; set; }
             public (int x, int y) Coordinates { get; set; }

             public Pawn(bool isWhite, (int x, int y) coordinates)
             {
                 isWhite = IsWhite;
                 coordinates = Coordinates;
             }
         }
         /*
         static void Main(string[] args)
         {
             Board board = new Board();
             board.CreateBoard();
             board.ArrangementPawns();
             Console.Out.WriteLine(board);
            
         }
         */
    }
    
}