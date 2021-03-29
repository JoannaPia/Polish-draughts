using System.Diagnostics.Tracing;
using System.Linq;

namespace Warcaby
{
    public class Board2
    {
        public string board { get; }
        private string topBorderLine = "|¯¯¯|";
        private string whiteFieldLine = "|   |";
        private string blackFieldLine = "| X |";
        private string bottomBorderLine = "|___|";

        bool blackField = false;

        public Board2(int boardSize = 8)
        {
            string row = null;
            
            for (int i = 0; i < boardSize; i++)
            {
                row += AddLine(topBorderLine, boardSize);
                row += AddLine(whiteFieldLine, boardSize, true);
                row += AddLine(bottomBorderLine, boardSize);

                board = row;
                blackField = blackField ? false : true;
            }
        }

        private string AddLine(string piece, int counter, bool middle = false)
        {
            string line = null;
            
            if (!middle)
            {
                line = string.Concat(Enumerable.Repeat(piece, counter));
            }
            else
            {
                for (int i = 0; i < counter; i++)
                {
                    line += blackField ? blackFieldLine : whiteFieldLine;
                    blackField = blackField ? false : true;
                }
            }
            return line += "\n";
        }

    }
}