using System;

namespace TicTacToe
{
    class Program
    {
        // Array with all of the positions on the board. 0 must be present in the array, but it will not be used on the board
        private static string[] square  = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        private static void DrawBoard() // Draws out the board so that the players can see their positions
        {
            Console.WriteLine("   {0}  |  {1}  |  {2}   ", square[1], square[2], square[3]);
            Console.WriteLine("-------------------");
            Console.WriteLine("   {0}  |  {1}  |  {2}   ", square[4], square[5], square[6]);
            Console.WriteLine("-------------------");
            Console.WriteLine("   {0}  |  {1}  |  {2}   ", square[7], square[8], square[9]);
        }

        private static string[] EnterPlayers()
        {
            Console.WriteLine("Welcome to Tic-Tac-Toe! Let's meet our players.");
            Console.WriteLine("Who is Player 1?: ");
            var player1 = Console.ReadLine();
            Console.WriteLine("Nice to meet you! And who is Player 2?: ");
            var player2 = Console.ReadLine();
            Console.WriteLine("Great! {0} will be O and {1} will be X.", player1, player2);
            Console.WriteLine("{0} goes first.", player1);
            Console.ReadLine();
            Console.Clear(); //clears out the player name input screen. It will return with a gameboard and scoreboard to start the game
            return new[] { player1, player2 };
        }

        public static void Main(string[] args) //starts everything empty for player names, wins, etc
        {
            string[] players = EnterPlayers();
            string[] pieces = { "O", "X" };
            int[] scores = { 0, 0 };

            bool playing = true; //starts up a new game if the players decide to keep going
            while (playing)
            {
                PlayGame(players, scores, pieces);
                playing = PlayAgain();
            }
        }

        private static void PlayGame(string[] players, int[] scores, string[] pieces)
        {
            bool hasWon = false;
            bool isGameOver = false;
            int playerIndex = 0;

            while (isGameOver == false)
            {
                var nextPlayerIndex = 1 - playerIndex;
                var player = players[playerIndex];
                var piece = pieces[playerIndex];
                var opponentPiece = pieces[nextPlayerIndex];

                PlayerMakesAMove(players, scores, player, piece, opponentPiece);

                hasWon = CheckWin();
                isGameOver = hasWon || CheckDraw(); //will end the game when it detects a win or draw

                if (isGameOver == false) //keeps gameplay going while it doesn't detect a win or loss
                {
                    playerIndex = nextPlayerIndex;
                }
            }

            Console.Clear();
            DrawBoard();
            ResetBoard();

            if (hasWon) // One of the players has won
            {
                IncrementPlayerScore(scores, playerIndex);
                Console.WriteLine("{0} wins!", players[playerIndex]);
            }
            else // No one has won
            {
                Console.WriteLine("It's a draw!");
            }

            ReportScores(players, scores);
        }

        private static void PlayerMakesAMove(string[] players, int[] scores, string player, string piece, string opponentPiece)
        {
            do
            {
                Console.Clear();
                DrawBoard();
                Console.WriteLine("");
                ReportScores(players, scores);
            } while (!TryToPlaceAPiece(player, piece, opponentPiece));
        }

        private static bool CheckDraw()
        {
            //need to finish this
                     return false;
        }

        private static void IncrementPlayerScore(int[] scores, int playerIndex)
        {
            scores[playerIndex] = scores[playerIndex] + 1;
        }

        private static void ReportScores(string[] players, int[] scores) //prints out the players names and the scores 
        {
            Console.WriteLine("Score: {0} - {1}     {2} - {3}", players[0], scores[0], players[1], scores[1]);
        }

        private static bool TryToPlaceAPiece(string player, string playerPiece, string opponentsPiece) //asks player which space they want, places piece, then changes players
        {
            Console.WriteLine("{0}'s ({1}) turn", player, playerPiece);
            var move = AskTheUser("Which square would you like to take?", 1, 9);
            if (!IsMoveTaken(playerPiece, opponentsPiece, move)) //determines if the move has been taken and will switch players if it has
            {
                square[move] = playerPiece;
                return true;
            }

            Console.WriteLine("Sorry! That square is already taken.");
            Console.Write("Please try again.");
            Console.ReadLine();
            Console.Clear();
            return false; //returing false will let the player to try again
        }

        private static bool IsMoveTaken(string playerPiece, string opponentsPiece, int move) //determines if player 1/2 has taken their turn
        {
            return square[move] == opponentsPiece || square[move] == playerPiece;
        }

        private static bool PlayAgain()
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to do now?");
            Console.WriteLine("To start another game, enter 1");
            Console.WriteLine("To quit, enter 2");

            var choice = AskTheUser("Please enter your choice: ", 1, 2);

            Console.Clear();
            if (choice == 1) return true;

            Console.WriteLine("Thanks for playing!");
            Console.ReadLine();
            return false;
        }

        private static int AskTheUser(string prompt, int min, int max)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                int choice = int.Parse(Console.ReadLine());

                if (choice >= min && choice <= max)
                {
                    return choice;
                }
            }
        }

        private static void ResetBoard()
        {
            for (int i = 1; i < 10; i++)
            {
                square[i] = i.ToString();
            }
        }

        static bool CheckWin() // Checks for a winner
        {
            return IsHorizontalWin(1) ||
                   IsHorizontalWin(4) ||
                   IsHorizontalWin(7) ||
                   IsAnyLine(1, 4) ||  // checks the diagonals
                   IsAnyLine(3, 2) ||  // also checks diagonals
                   IsVerticalWin(1) ||
                   IsVerticalWin(2) ||
                   IsVerticalWin(3);
        }

        private static bool IsLine(int index0, int index1, int index2, string piece)
        {
            return square[index0] == piece && square[index1] == piece && square[index2] == piece;
        }

        private static bool IsAnyLine(int start, int step) //starts and takes steps along the lines to find a possible win 
        {
            return IsLine(start, start + step, start + step + step, square[start]);
        }

        private static bool IsHorizontalWin(int startindex)
        {
            return IsAnyLine(startindex, 1);
        }

        private static bool IsVerticalWin(int startindex)
        {
            return IsAnyLine(startindex, 3);
        }
    }
}
