using System;

namespace Warcaby
{
    public class Pawn
    {

        public bool IsWhite { get; }
        public (int, int) Coordinates { get; set; }
        public bool IsCowned { get; set; }
        public Pawn[] pawns { get; }

        public Pawn((int, int) coordinates, bool isWhite = true, bool isCrowned = false)
        {
            this.IsWhite = isWhite;
            this.Coordinates = coordinates;
            this.IsCowned = isCrowned;
        }
    }
}