using System;

namespace MasterMind
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] colors = { "blue", "red", "yellow" };
            Random rand = new Random();
            bool correct = false;

            int col1 = rand.Next(colors.Length);
            string color1 = colors[col1];
            int col2 = rand.Next(colors.Length);
            string color2 = colors[col2];


            Console.WriteLine("Welcome to MasterMind!");
            Console.WriteLine();
            Console.WriteLine("To play: Try to guess the two colors the computer picked from red, blue, & yellow and the order it chose them in. The two colors can be the same. ");
            Console.WriteLine("0-0 = no correct colors");
            Console.WriteLine("1-0 = 1 correct color, but in the wrong spot");
            Console.WriteLine("0-1 = 1 correct color in the correct position");
            Console.WriteLine("2-0 = both colors correct, but in the wrong position");
            Console.WriteLine();
                       
                        
            do
            {
                playGame(color1, color2, correct);
               
            } while (correct == false);
            
            Console.WriteLine("Thanks for playing!");
            Console.Read();

        
        }
        public static void playGame(string color1, string color2, bool correct)
        {
           
            Console.WriteLine("Type your guess for the first color: ");
            string guess1 = Console.ReadLine();
            Console.WriteLine("And for the second color: ");
            string guess2 = Console.ReadLine();

            if (guess1 == color1)
            {
                if (guess2 == color2)
                {
                    Console.WriteLine("Correct! Good Job.");
                    correct = true;
                    Console.Read();
                    
                }
                else
                {
                    Console.WriteLine("0 - 1");
                    Console.WriteLine();
                }
            }

            else if (guess1 == color2)
            {
                if (guess2 == color1)
                {
                    Console.WriteLine("2 - 0");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("1 - 0");
                    Console.WriteLine();
                }
            }

            else if (guess1 != color1 || guess1 != color2)
            {
                if (guess2 == color2)
                {
                    Console.WriteLine("0 - 1");
                    Console.WriteLine();
                }
                else if (guess2 == color1)
                {
                    Console.WriteLine("0 - 1");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("0 - 0");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("I'm a chicken! Bockbockbockbock");
            }
        }

    }
}
