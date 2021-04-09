using System;
using System.Collections.Generic;

namespace Warcaby
{
    /* class TestGame
     {
         public Pawn[,] endgameBlackHasWon;
         public Pawn[,] endgameWhiteHasWon;
         public Pawn[,] remis;


         public TestGame(int size = 10)
         { 
             remis = new Pawn[size,size];
             remis[0, 0] = new Pawn(true,0,0);
             remis[size-1, size-1] = new Pawn(false, size-1, size-1);

             endgameBlackHasWon = new Pawn[size, size];
             endgameBlackHasWon[0, 0] = new Pawn(false, 0, 0);

             endgameWhiteHasWon = new Pawn[size, size];
             endgameWhiteHasWon[size-1, size-1] = new Pawn(true, 0, 0);
         }


         public void TestRemis()
         {
             Game game = new Game();
             Board board = new Board(remis);
             game.Board = board;
             game.CheckForWinner();
         }

         public void TestBlackWon()
         {
             Game game = new Game();
             Board board = new Board(endgameBlackHasWon);
             game.Board = board;
             game.CheckForWinner();
         }

         public void TestWhiteWon()
         {
             Game game = new Game();
             Board board = new Board(endgameWhiteHasWon);
             game.Board = board;
             game.CheckForWinner();
         }

         public void TestGameNotEnding()
         {
             Game game = new Game();
             Board board = new Board(remis);
             game.Board = board;
             game.GameTest();
         }
     }
    */
    class Program
    {
        static void Main(string[] args)
        {
        /*TestGame test = new TestGame();
        test.TestRemis();
        test.TestBlackWon();
        test.TestWhiteWon();
        //test.TestGameNotEnding();
        //game.Start();*/
        Game game = new Game();
        game.Start();


            //Board b = new Board();
            //b.InitBoard();
            //Console.Write(b.ToString());
            //Pawn[,] boardArrey = b.board;
            //AskForMove move = new AskForMove();
        
            //(int?, int?) inputCoordinates = move.AskUserForCoordinates();
            //Console.Out.WriteLine("The user entered the following coordinates: {0}", inputCoordinates);
        
            //move.MakeMove(boardArrey, 10);
        }
    }

}
