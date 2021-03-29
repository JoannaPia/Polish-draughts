using System;

namespace Warcaby
{
    class Program
    {
        static void Main(string[] args)
        {
            //Display table
            Board2 board = new Board2();
            Console.Out.WriteLine(board.board);

            
            //Generate pawns array
            Pawn[] pawns = createPawnsSet();
            Pawn pawn1 = pawns[0];

            foreach (var pawn in pawns)
            {
                Console.Out.WriteLine("{0}, {1}, {2}",pawn.IsWhite, pawn.IsCowned, pawn.Coordinates);               
            }
            

        }
        
        static Pawn[] createPawnsSet(int boardSize = 8)
        {
            Pawn[] whiteAndBlackPawns = new Pawn[boardSize * 2];

            for (int i = 0; i < 2; i++)
            {
                onePlayerPawns(boardSize, whiteAndBlackPawns, 0, true);
                onePlayerPawns(boardSize, whiteAndBlackPawns, boardSize, false);
            }

            return whiteAndBlackPawns;
        }
        
        static void onePlayerPawns(int boardSize, object[] pawnsArray, int pawnIndex,  bool isWhite)
        {
            int pawnsNumber = boardSize;
            int startLine = isWhite ? 1 : (boardSize - 1);
                
            for (int i = 0; i < 2; i++)
            {
                for (int p = 0; p < pawnsNumber / 2; p++)
                {
                    Pawn pawn = new Pawn((startLine - i, (p * 2) + i), isWhite);
                    pawnsArray[pawnIndex] = pawn;
                    pawnIndex++;
                }
            }
        }
    }
}