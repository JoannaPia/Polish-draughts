namespace Warcaby
{
    public class Player
    {
        public string ColorPawns { get; set; }
        public int Id { get; set; }

        public Player(string colorPawns, int id)
        {
            colorPawns = ColorPawns;
            id = Id;
        }
    }
}