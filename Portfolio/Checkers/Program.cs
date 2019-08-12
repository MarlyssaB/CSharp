using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    class Program
    {
        static void Main(string[] args)
        {
            //this lets the pieces display properly and not as question marks
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Game game = new Game();          
			game.Start();            
        }
    }


    public class Checker
    {
        public string Symbol { get; private set; }
        public Position Position { get; set; }
        public Color Team { get; private set; }

        public Checker(Color player, int row, int col)
        {
            if (player == Color.Black)
            {
                int symbol = int.Parse("25CB", System.Globalization.NumberStyles.HexNumber);
                Symbol = char.ConvertFromUtf32(symbol);
                Team = Color.Black;
            }
            else
            {
                int symbol = int.Parse("25CF", System.Globalization.NumberStyles.HexNumber);
                Symbol = char.ConvertFromUtf32(symbol);
                Team = Color.White;
            }
            Position = new Position(row, col);
        }
    }
   

    public class Board
    {
        public List<Checker> checkers { get; private set; }

     
        public Board()
        {
            checkers = new List<Checker>();
            for (int r = 0; r < 3; r++)
            {
                for (int i = 0; i < 8; i += 2)
                {
                    //makes the top 3 rows white checkers

                    Checker c = new Checker(Color.White, r, (r + 1) % 2 + i); //skips a spot between each checker
                    checkers.Add(c);
                }
                for (int i = 0; i < 8; i += 2)
                {
                    //bottom rows (5, 6, 7) are for black checkers
                    Checker c = new Checker(Color.Black, (r + 5), r % 2 + i); 
                    checkers.Add(c);
                }

                

            }
        }
       

        public Checker GetChecker(Position source)
        {
           
            foreach (Checker c in checkers)
            {
                if (c.Position.Row == source.Row && c.Position.Column == source.Column)
                {
                    return c;
                }
            }
            return null;
            //returns the position of the checker if it finds one or nothing if it doesn't
        }

        public void MoveChecker(Checker checker, Position destination)
        {
            Checker c = new Checker(checker.Team, destination.Row, destination.Column);
            checkers.Add(c);
            checkers.Remove(checker);
            //moves checker to user's desired destination and removes it from the starting position
        }

        public void RemoveChecker(Checker checker)
        {
            if (checker != null)
            {
                checkers.Remove(checker);
            }       
            //moves the checker away from the space if there is a checker to move
        }

     
    }

    
    public class Game
    {
        private Board board;
        public Game()
        {
            this.board = new Board();
        }

        public bool CheckForWin()
        {
            return (board.checkers.All(x => x.Team == Color.White) || board.checkers.All(x => x.Team == Color.Black));
            //checks if there is at least one piece from each team on the board
        }

        public void Start()
        {
            DrawBoard();
            while (!CheckForWin())
            {
				PlayerInput(); //keeps game going if no win is detected
            }
            Console.WriteLine("You won!");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey(); //ends game after a win
        }

        public bool IsLegalMove(Color player, Position source, Position destination)
        {
            // checks that the entered ending position is one on the board (is between 0 and 7)
            if (source.Row < 0 || source.Row > 7 || source.Column < 0 || source.Column > 7
                || destination.Row < 0 || destination.Row > 7 || destination.Column < 0
                || destination.Column > 7) return false;

            //checks that the move is more than 0 but <= 2 spaces 
            int rowDistance = Math.Abs(destination.Row - source.Row);
            int colDistance = Math.Abs(destination.Column - source.Column);

            if (colDistance == 0 || rowDistance == 0) return false;

            if (rowDistance / colDistance != 1) return false;

            if (rowDistance > 2) return false;

            Checker c = board.GetChecker(source);
            if (c == null)  // makes sure there is a checker at the starting position
            {
                return false;
            }

            c = board.GetChecker(destination);
            if (c != null) // makes sure the destination space hasn't already been taken 
            {
                return false;
            }
            // program has found a checker in the starting space, the destination is clear, and the move is valid
            if (rowDistance == 2)
            {
                if (IsCapture(source, destination))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        public bool IsCapture(Position source, Position destination)
        {
           
            int rowDistance = Math.Abs(destination.Row - source.Row);
            int colDistance = Math.Abs(destination.Column - source.Column);
            if (rowDistance == 2 && colDistance == 2)
            {
                //checks for a checker in in between the start and destination
                int row_mid = (destination.Row + source.Row) / 2;
                int col_mid = (destination.Column + source.Column) / 2;
                Position p = new Position(row_mid, col_mid);
                Checker c = board.GetChecker(p);
                Checker player = board.GetChecker(source);
                if (c == null)
                {
                    return false;
                }
                else
                {
                    if (c.Team == player.Team)
                    {
                        return false; //keeps player from jumping themselves
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            else
            {
                return false;
            }
        }

        public Checker GetCaptureChecker(Position source, Position destination)
        {
            // ..
            if (IsCapture(source, destination))
            {
                int row_mid = (destination.Row + source.Row) / 2;
                int col_mid = (destination.Column + source.Column) / 2;
                Position p = new Position(row_mid, col_mid);
                Checker c = board.GetChecker(p);
                return c;
            }
            return null;

        }

        public void PlayerInput()
        {
            Console.WriteLine("Select a checker to move (Row, Column):");
            string[] start = Console.ReadLine().Split(','); 
            Console.WriteLine("Select a square to move to (Row, Column):");
            string[] end = Console.ReadLine().Split(','); 

           
            Position from = new Position(int.Parse(start[0]), int.Parse(start[1]));
            Position to = new Position(int.Parse(end[0]), int.Parse(end[1])); 


            //get checker from the starting position
			Checker startChecker = board.GetChecker(from);
			
			
            //returns an error if the starting space is empty
			if(startChecker == null)
			{
				Console.WriteLine("Empty start position. Please try again");
			}
			 
            //if there is a checker in the starting position, checks that the move is legasl
			else
			{
				if(IsLegalMove(startChecker.Team, from, to))
				{
					if(IsCapture(from, to))
					   {
						   Checker jumpChecker = this.GetCaptureChecker(from, to);
						   board.RemoveChecker(jumpChecker);
						   board.MoveChecker(startChecker, to);
					   }
				board.MoveChecker(startChecker, to);
				}
				else
				{
				Console.WriteLine("Invalid move. Check your starting and ending positions and try again.");
				}
			}
            Console.Clear();
			DrawBoard();
    
        }

        public void DrawBoard()
        {
            String[][] grid = new String[8][];
            for (int r = 0; r < 8; r++)
            {
                grid[r] = new String[8];
                for (int c = 0; c < 8; c++)
                {
                    grid[r][c] = " ";
                }
            }
            foreach (Checker c in board.checkers)
            {
                grid[c.Position.Row][c.Position.Column] = c.Symbol;
            }

            Console.WriteLine("   0   1   2   3   4   5   6   7");
            Console.Write("  ");
            for (int i = 0; i < 32; i++)
            {
               
                Console.Write("\u2501");
            }
            Console.WriteLine();

            for (int r = 0; r < 8; r++)
            {
                Console.Write($"{r} ");
                for (int c = 0; c < 8; c++)
                {
                    Console.Write($" {grid[r][c]} \u2503"); 
                }
                Console.WriteLine();
                Console.Write("  ");
                for (int i = 0; i < 32; i++)
                {
                    Console.Write("\u2501");
                }
                Console.WriteLine();
            }
        }
    }



    public enum Color { White, Black }

   
    public struct Position
    {
        public int Row { get; private set; }
        public int Column { get; private set; }
        public Position(int row, int col)
        {
            Row = row;
            Column = col;
        }
    }
    
}