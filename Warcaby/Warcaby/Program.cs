using System;
using System.Collections.Generic;

namespace Warcaby
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();

            AskForMove move = new AskForMove();
            (int?, int?) inputCoordinates = move.AskUserForCoordinates();
            Console.Out.WriteLine("The user entered the following coordinates: {0}", inputCoordinates);
        }
    }
}
