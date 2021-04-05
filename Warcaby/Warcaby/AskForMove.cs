using System;
using System.Linq;

namespace Warcaby
{
    public class AskForMove
    {
        private readonly Messages _message = new Messages();
        
        
        public (int, int)[] MakeMove(Pawn[,] fieldsArray, int boardSize = 10, int player = 1)
        {
            (int, int) pawnToMove;
            (int, int) fieldToMoveTo;
            (int, int)[] availableMoves;
            (int, int)[] avilableCaptures;
            (int, int)[] result;
            string messageText;
            bool isValidChoice;
            bool isEmptyList;

            //Player selects pawn
            _message.WriteMessage("choosePawn");
            do
            {
                pawnToMove = AskUserForCoordinates(boardSize, player);
                availableMoves = GetPosibleMoves(pawnToMove, player, boardSize, fieldsArray);
                avilableCaptures = GetPosibleCaptures(pawnToMove, player, boardSize, fieldsArray);
                isValidChoice = ValidPawn(fieldsArray, pawnToMove, player);
                isEmptyList = availableMoves.Length == 0 && avilableCaptures.Length == 0;
                messageText = !isValidChoice ? "wrongPawn" : (isEmptyList ? "noMove" : "whereToPlace");
                _message.WriteMessage(messageText);
            } while (!isValidChoice || isEmptyList);


            //Player decides where to move his pawn
            do
            {
                fieldToMoveTo = AskUserForCoordinates(boardSize, player);
                isValidChoice = availableMoves.Contains(fieldToMoveTo) || avilableCaptures.Contains(fieldToMoveTo);
                if (!isValidChoice)
                    _message.WriteMessage("unavailableMove");
            } while (!isValidChoice);

            Console.Out.WriteLine("Your pawn will move to {0}", fieldToMoveTo);

            // move or capture + move in Game class method MakeMoveOrCapture
            return result = new (int, int)[2] {pawnToMove, fieldToMoveTo};
        }
        
        
        private (int, int) AskUserForCoordinates (int boardSize = 10, int player = 1)
        {
            (int?, int?) pawnCoordinates;

            do
            {
                string userInput = Console.ReadLine();
                pawnCoordinates = ValidateInput(userInput, boardSize);
            } while (pawnCoordinates == (null, null));

            return  ConverrtNullableInts(pawnCoordinates);
        }

        
        private (int?, int?) ValidateInput(string userInput, int boardSize)
        {
            int firstLetterAsciiCode = 65;
            int numberZeroAciiCode = 49;
            //int alphabetLength = 25;
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
                    _message.WriteMessage("outOfRange");
                    (row, col) = (null, null);
                }
            }
            else
            {
                _message.WriteMessage("invalidInput");
                (row, col) = (null, null);
            }

            return (row, col);
        }

        /*
        private (int?, int?) nullCoordinates()
        {
            Console.Out.WriteLine("Invalid input! Please enter correct coordinates");
            return (null, null);
        }
        */
        
        
        private (int, int) ConverrtNullableInts((int? rowNull, int? colNull) coordinates)
        {
            var colConverted = coordinates.colNull ?? default(int); //colConverted = colNull is not null ? colNum : default(int);
            var rowConverted = coordinates.rowNull ?? default(int);

            return (rowConverted, colConverted);
        }
        
     
        private bool ValidPawn(Pawn[,] board, (int row, int col) coordinates, int player = 1)
        {
            Pawn pawn = board[coordinates.row, coordinates.col];

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
        
        
        private (int, int)[] GetPosibleMoves((int pawnRow, int pawnCol) pawnLocation, int player, int bordSize, Pawn[,] firldsArray)
        {
            (int, int)[] possibleCoordinates;

            int newRow = player == 1 ? pawnLocation.pawnRow - 1 : pawnLocation.pawnRow + 1;
            (int, int) rightMoveField = (newRow, pawnLocation.pawnCol + 1);
            (int, int) leftMoveField = (newRow, pawnLocation.pawnCol - 1);

            bool rMoveAvailable = pawnLocation.pawnCol < bordSize - 1 && isAnEmptyField(rightMoveField, firldsArray);
            bool lMoveAvailable = pawnLocation.pawnCol > 0 && isAnEmptyField(leftMoveField, firldsArray);

            if (newRow >= bordSize || newRow < 0 || (!rMoveAvailable && !lMoveAvailable))
                return possibleCoordinates = new (int, int)[] { };
            else if (rMoveAvailable && !lMoveAvailable)
                return possibleCoordinates = new (int, int)[] {rightMoveField};
            else if (!rMoveAvailable)
                return possibleCoordinates = new (int, int)[] {leftMoveField};
            else
                return possibleCoordinates = new (int, int)[] {leftMoveField, rightMoveField};
        }

        
        private bool isAnEmptyField((int row, int col) fieldCoordinates, Pawn[,] firldsArray)
        {
            return (firldsArray[fieldCoordinates.row, fieldCoordinates.col] is null) ? true : false;
        }

        private (int, int)[] GetPosibleCaptures((int pawnRow, int pawnCol) pawnLocation, int player, int boardSize,
            Pawn[,] fieldsArray)
        {
            (int, int)[] possibleCoordinatesCapture;
            
            int newRow = player == 1 ? pawnLocation.pawnRow - 2 : pawnLocation.pawnRow + 2;
            (int newRow, int newCol) rightMoveField = (newRow, pawnLocation.pawnCol + 2);
            (int newRow, int newCol) leftMoveField = (newRow, pawnLocation.pawnCol - 2);
            
            int rowBetween = player == 1 ? pawnLocation.pawnRow - 1 : pawnLocation.pawnRow + 1;
            (int newRow, int newCol) rightFieldBetween = (rowBetween, pawnLocation.pawnCol + 1);
            (int newRow, int newCol) leftFieldBetween = (rowBetween, pawnLocation.pawnCol - 1);
            
            bool rMoveAvailable = rightMoveField.newCol < boardSize - 1 && isAnEmptyField(rightMoveField, fieldsArray) && isFieldWithOppositePawn(rightFieldBetween, fieldsArray, player);
            bool lMoveAvailable = leftMoveField.newCol > 0 && isAnEmptyField(leftMoveField, fieldsArray) && isFieldWithOppositePawn(leftFieldBetween, fieldsArray, player);

            if (newRow >= boardSize || newRow < 0 || (!rMoveAvailable && !lMoveAvailable))
            {
                return possibleCoordinatesCapture = new (int, int)[] { };
            }
            else if(rMoveAvailable && !lMoveAvailable)
            {
                return possibleCoordinatesCapture = new (int, int)[] {rightMoveField};
            }
            else if(!rMoveAvailable && lMoveAvailable)
            {
                return possibleCoordinatesCapture = new (int, int)[] {leftMoveField};
            }
            else
            {
                return possibleCoordinatesCapture = new (int, int)[] {leftMoveField, rightMoveField};
            }
        }

        private bool isFieldWithOppositePawn((int row, int col) fieldCoordinate, Pawn[,] fieldsArray, int player)
        {
            if (!isAnEmptyField(fieldCoordinate, fieldsArray))
            {
                if (player == 1)
                {
                    return (!fieldsArray[fieldCoordinate.row, fieldCoordinate.col].IsWhite) ? true : false;
                }
                else
                {
                    return (fieldsArray[fieldCoordinate.row, fieldCoordinate.col].IsWhite) ? true : false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}