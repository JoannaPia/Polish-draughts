using System;

namespace Warcaby
{
    public class AskForMove
    {
        public (int?, int?) AskUserForCoordinates (int boardSize = 10, int player = 1)
        {
            (int?, int?) pawnCoordinates;
            
            Console.Out.WriteLine("Please enter your pawn coordinates");
            
            do
            {
                string userInput = Console.ReadLine();
                pawnCoordinates = ValidateInput(userInput, player, boardSize);
            } while (pawnCoordinates == (null, null));

            Console.Out.WriteLine(pawnCoordinates);

            return pawnCoordinates;
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
                    (col, row) = nullCoordinates();
                }
            }
            else
            {
                (col, row) = nullCoordinates();
            }

            return (col, row);
        }

        private (int?, int?) nullCoordinates()
        {
            Console.Out.WriteLine("Invalid input! Please enter correct coordinates");
            return (null, null);
        }
    }
}