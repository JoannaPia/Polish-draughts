using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warcaby
{

    /*
There is a class Game which contains all game logic and actions.
There is a method Start() that starts whole game between players.
There is a method Round() that determines one round actions i.e. check who plays next or is there a winner yet.
There is a method that checks if starting position from user input is a valid pawn and if ending position is within board boundaries. If so, it calls TryToMakeMove() on pawn instance.
There is a method CheckForWinner() that checks after each round is there an a winner.
Method CheckForWinner() checks also for draws.
    */
    class Game
    {
        private Board board;
        private bool isFinished = false;
        private int player = 2;

     
        public void Start()
        {
            board = new Board();
            while (!isFinished)
            {
                Round();
                Console.Clear();
                Console.Out.WriteLine(board.ToString());
            }
        }

        public void Round()
        {
            player = player == 2 ? 1 : 2;
            TryToMakeMove();
            CheckForWinner();
        }

        public void TryToMakeMove()
        {
            AskForMove move = new AskForMove();
            (int, int)[] moveCoordinates = move.MakeMove(board.board, board.Size, player);
            board.MovePawn(moveCoordinates[0], moveCoordinates[1]);
            
        }

        public void CheckForWinner()
        {
            int W = 0, B = 0;

            for (int row = 0; row < board.Size; row++)
            {
                for (int col = 0; col < board.Size; col++)
                {
                    Pawn p = board.board[row, col];
                    if (board.board[row,col] != null)
                    {
                        if (board.board[row, col].IsWhite)
                            W++;
                        else
                            B++;
                    }
                }
            }

            ValidateResult(W, B);
        }

        public void ValidateResult(int white, int black)
        {
            if (white == 1 && black == 1)
            {
                printEndScreen(3);
                isFinished = true;
            }
            else if (white == 0)
            {
                printEndScreen(2);
                isFinished = true;
            }
            else if (black == 0)
            {
                printEndScreen(1);
                isFinished = true;
            }

            isFinished = false;
        }

        private void printEndScreen(int ending)
        {
            if (ending == 1)
            {
                Console.WriteLine("**************White has won**************");
            }
            else if (ending == 2)
            {
                Console.WriteLine("**************Black has won**************");
            }
            else
            {
                Console.WriteLine("************** Tied **************"); 
            }
        }
    }
}
