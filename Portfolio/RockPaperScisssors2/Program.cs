using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors2
{
    class Program
    {
        static void Main(string[] args)
        {
           do 
            {
                Console.WriteLine();
                rockPaperScissors();
                Console.WriteLine("Would you like to start a new game? Y/N");
         
            } while (Console.ReadLine().ToLower() == "y");

            Console.WriteLine("Thanks for playing!");
        }
        public static void rockPaperScissors()
        {
            Console.WriteLine("Let's play! Choose rock, paper, or scissors:");
            string userChoice = Console.ReadLine().ToLower();
        Console.WriteLine();
            ///makes it easier to read

            Random r = new Random();
        int computerChoice = r.Next(4);

            if (computerChoice == 1)
            {
                if (userChoice == "rock")
                {
                    Console.WriteLine("The computer also chose rock");
                    Console.WriteLine("It's a tie! Press enter ");
                }
                else if (userChoice == "paper")
                {
                    Console.WriteLine("The computer also chose paper");
                    Console.WriteLine("It's a tie! Press enter  ");

                }
                else if (userChoice == "scissors")
                {
                    Console.WriteLine("The computer also chose scissors");
                    Console.WriteLine("It's a tie! Press enter ");
                }
                else
                {
                    Console.WriteLine("No cheating! Choose rock, paper, or scissors. Press enter try again ");
                    
                }

            }

            else if (computerChoice == 2)
            {
                if (userChoice == "rock")
                {
                    Console.WriteLine("The computer chose paper ");
                    Console.WriteLine("Paper covers rock. Computer wins! Press enter ");

                }
                else if (userChoice == "paper")
                {
                    Console.WriteLine("The computer chose scissors ");
                    Console.WriteLine("Scissors cuts paper. Computer wins! Press enter ");

                }
                else if (userChoice == "scissors")
                {
                    Console.WriteLine("The computer chose rock ");
                    Console.WriteLine("Rock crushes scissors. Computer wins! Press enter ");
                }
                else
                {
                    Console.WriteLine("No cheating! Choose rock, paper, or scissors. Press enter to try again ");
                }
            }
            else if (computerChoice == 3)
            {
                if (userChoice == "rock")
                {
                    Console.WriteLine("The computer chose scissors");
                    Console.WriteLine("Rock crushes scissors. You win! Press enter ");

                }
                else if (userChoice == "paper")
                {
                    Console.WriteLine("The computer chose rock");
                    Console.WriteLine("Paper covers rock. You win! Press enter ");

                }
                else if (userChoice == "scissors")
                {
                    Console.WriteLine("The computer chose paper");
                    Console.WriteLine("Scissors cuts paper. You win! Press enter ");

                }
                else
                {
                    Console.WriteLine("No cheating! Choose rock, paper, or scissors. Press enter to try again ");

                }
        }

            Console.ReadLine();
        }
    }
}