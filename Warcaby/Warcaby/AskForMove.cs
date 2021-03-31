using System;
using System.Linq;

namespace Warcaby
{
    public class AskForMove
    {
        public void MakeMove(Pawn[,] fieldsArray, int boardSize = 10, int player = 1)
        {
            (int, int) pawnToMove;
            (int, int) fieldToMoveTo;
            int count = 0;

            do
            {
                pawnToMove = AskUserForCoordinates(boardSize, player);
            } while (!ValidPawn(fieldsArray, pawnToMove, player));

            (int, int)[] availableMoves = GetPosibleMoves(pawnToMove, player, boardSize, fieldsArray);
            
            do
            {
                if (count > 0)
                    Console.Out.WriteLine("This move is unavailable");
                fieldToMoveTo = AskUserForCoordinates(boardSize, player);
                count++;
            } while (!availableMoves.Contains(fieldToMoveTo));

            Console.Out.WriteLine("Your pawn will move to {0}", fieldToMoveTo);
        }
        
        
        public (int, int) AskUserForCoordinates (int boardSize = 10, int player = 1)
        {
            (int?, int?) pawnCoordinates;
            
            Console.Out.WriteLine("Please enter your pawn coordinates");
            
            do
            {
                string userInput = Console.ReadLine();
                pawnCoordinates = ValidateInput(userInput, player, boardSize);
            } while (pawnCoordinates == (null, null));

            Console.Out.WriteLine(pawnCoordinates);

            return  ConverrtNullableInts(pawnCoordinates);
        }

        
        private (int?, int?) ValidateInput(string userInput, int player, int boardSize)
        {
            int firstLetterAsciiCode = 65;
            int numberZeroAciiCode = 49;
            int alphabetLength = 25;
            int? col, row;


            if (userInput.Length > 1 && userInput.Length < 4)
            {
                char[] charArr = userInput.ToUpper().ToCharArray(0, userInput.Length);
                col = (int) charArr[0] - firstLetterAsciiCode;
                row = userInput.Length == 2
                    ? charArr[1] - numberZeroAciiCode
                    : (((charArr[1] - numberZeroAciiCode + 1) * 10) + (charArr[2] - numberZeroAciiCode));

                if (col >= boardSize || col < 0 || row >= boardSize || row < 0)
                {
                    (row, col) = nullCoordinates();
                }
            }
            else
            {
                (row, col) = nullCoordinates();
            }

            return (row, col);
        }

        
        private (int?, int?) nullCoordinates()
        {
            Console.Out.WriteLine("Invalid input! Please enter correct coordinates");
            return (null, null);
        }
        
        
        private (int, int) ConverrtNullableInts((int?, int?) coordinates)
        {
            (int? rowNull, int? colNull) = coordinates;

            var colConverted = colNull ?? default(int); //colConverted = colNull is not null ? colNum : default(int);
            var rowConverted = rowNull ?? default(int);

            return (rowConverted, colConverted);
        }
        
     
        private bool ValidPawn(Pawn[,] board, (int, int) coordinates, int player = 1)
        {
            (int row, int col) = coordinates;
            Pawn pawn = board[row, col];

            if (pawn is null)
                return false;
            else 
                switch (player)
                {
                    case 1 when pawn.IsWhite:
                    case 2 when !pawn.IsWhite:
                        return true;
                    default:
                        return false;
                };
        }
        
        
        private (int, int)[] GetPosibleMoves((int, int) pawnLocation, int player, int bordSize, Pawn[,] firldsArray)
        {
            (int pawnRow, int pawnCol) = pawnLocation; ;
            (int, int)[] possibleCoordinates;

            int newRow = player == 1 ? pawnRow - 1 : pawnRow + 1;
            (int, int) rightMoveField = (newRow, pawnCol + 1);
            (int, int) leftMoveField = (newRow, pawnCol - 1);

            bool rMoveAvailable = pawnCol < bordSize - 1 && isAnEmptyField(rightMoveField, firldsArray);
            bool lMoveAvailable = pawnCol > 0 && isAnEmptyField(leftMoveField, firldsArray);

            if (newRow >= bordSize || newRow < 0 || (!rMoveAvailable && !lMoveAvailable))
                return possibleCoordinates = new (int, int)[] { };
            else if (rMoveAvailable && !lMoveAvailable)
                return possibleCoordinates = new (int, int)[] {rightMoveField};
            else if (lMoveAvailable && !rMoveAvailable)
                return possibleCoordinates = new (int, int)[] {leftMoveField};
            else
                return possibleCoordinates = new (int, int)[] {leftMoveField, rightMoveField};
        }

        
        private bool isAnEmptyField((int, int) fieldCoordinates, Pawn[,] firldsArray)
        {
            (int row, int col) = fieldCoordinates;
            return (firldsArray[row, col] is null) ? true : false;
        }
    }
}