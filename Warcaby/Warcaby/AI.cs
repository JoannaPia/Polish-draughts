using System;
using System.Collections.Generic;

namespace Warcaby
{
    public class AI
    {
        Random rdm = new Random();
        private AskForMove move = new AskForMove();
        
        (int, int)[] availableMoves = new (int, int)[] {};
        private (int, int)[] avilableCaptures = new (int, int)[] { };


        public (int, int)[] aiMove(int player, Board board)
        {
            (int, int) fieldToMoveTo = (-1, -1);

            (int, int) pawn = ChooseRandomPawn(player, board);

            while (fieldToMoveTo == (-1, -1) && pawn != (-1, -1))
            {
                fieldToMoveTo = avilableCaptures.Length != 0
                    ? avilableCaptures[rdm.Next(avilableCaptures.Length)]
                    : (availableMoves.Length != 0
                        ? availableMoves[rdm.Next(availableMoves.Length)]
                        : (-1, -1));
            }


            return new (int, int)[2] {pawn, fieldToMoveTo};
        }

        private (int, int) ChooseRandomPawn(int player, Board board)
        {
            List<(int, int)> pawns = GetPawnList(player, board);
            (int, int) pawn;
            bool noMove;

            foreach (var coord in pawns)
            {
                avilableCaptures = move.GetPosibleCaptures(coord, player, board);
                if (avilableCaptures.Length != 0)
                    return coord;
            }
            //tu wywala
            do
            {
                int randomIndex = rdm.Next(pawns.Count);
                pawn = pawns[randomIndex];
                availableMoves = move.GetPosibleMoves(pawn, player, board);
                avilableCaptures = move.GetPosibleCaptures(pawn, player, board);
                noMove = availableMoves.Length == 0 && avilableCaptures.Length == 0;
                if (noMove)
                    pawns.RemoveAt(randomIndex);
            } while (noMove && pawns.Count > 0);

            if (pawns.Count <= 0 )
                pawn = (-1, -1);

                return pawn;
        }


        private List<(int, int)> GetPawnList(int player, Board board)
        {
            List<(int, int)> coordinatesList = new List<(int, int)>();
            
            for (int row = 0; row < board.Size; row ++)
            {
                for (int col = 0; col < board.Size; col++)
                {
                    var pawn = board.board[row, col];
                    if (pawn != null && ((player == 1 && pawn.IsWhite) || (player == 2 && !pawn.IsWhite)))
                        coordinatesList.Add((row, col));
                }
            }
            
            return coordinatesList;
        }
    }
}