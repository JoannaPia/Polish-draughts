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

        private (int?, int?) ValidateInput (string userInput, int player, int boardSize)
        {
            int firstLetterAsciiCode = 65;
            int numberZeroAciiCode = 48;
            int alphabetLength = 25;
            int? col, row;
            string message = "Invalid input! Please enter correct coordinates";

            if (userInput.Length == 2)
            {
                char[] charArr = userInput.ToUpper().ToCharArray(0, 2);
                col = (int) charArr[0] - firstLetterAsciiCode;
                row = charArr[1] - numberZeroAciiCode;

                if (col > alphabetLength || col < 0 || row > 9 || row < 0)
                {
                    Console.Out.WriteLine(message);
                    col = null;
                    row = null;
                }
            }
            else
            {
                Console.Out.WriteLine(message);
                col = null;
                row = null;
            }

            return (col, row);
        }
    }
}