using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            hello();
            addition();
            catDog();
            oddEvent();
            height();
            echo();
            kilograms();
            date();
            age();
            guess();
         
        }







        public static void hello()
        {
            Console.Write("Hello! What's your name? :  ");
            string Name = Console.ReadLine();
            Console.WriteLine("It's nice to meet you, {0}", Name);
            Console.WriteLine();
        }


        ///This is the calculator, which asks for two numbers to add and returns the sum
        public static void addition()
        {
            Console.Write("Let's do some addition! Please give me a number: ");
            int Num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please give me another number: ");
            int Num2 = Convert.ToInt32(Console.ReadLine());
            int Sum = Num1 + Num2;
            Console.Write("The sum of those two numbers is {0}", Sum);
            Console.WriteLine();
            Console.WriteLine();
        }


        ///Asks if the user is a dog or a cat person and responds appropriately
        public static void catDog()
        {
            Console.Write("Do you like dogs or cats? Type D for dogs or C for cats: ");
            char pet = Convert.ToChar(Console.ReadLine());
            if (pet == 'd' || pet == 'D')
            {
                Console.Write("Me too! Woof Woof! U・x・U");
            }
            else if (pet == 'c' || pet == 'C')
            {
                Console.Write("Me too! Meoooow! =^_^=");
            }
            else
            {
                Console.Write("I don't recognize that animal. Is that a kind of fish? <><");
            }
            Console.WriteLine();
            Console.WriteLine();
        }


        ///Asks for a number, then declares if it's even or odd.
        public static void oddEvent()
        {
            Console.Write("Please give me a number. I can tell you if it's even or odd:  ");
            int EvOd = Convert.ToInt32(Console.ReadLine());
            int result = EvOd % 2;
            if (result == 0)
            {
                Console.Write("That's an even number! Cool!");
            }
            else if (result == 1)
            {
                Console.Write("That's an odd number! Excellent!");
            }
            else
            {
                Console.Write("Sorry, invalid input :( ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        public static void height()
        {
            Console.Write("I can tell you your height in inches!");
            Console.Write("How many feet tall are you?:");
            int feetIn = Convert.ToInt32(Console.ReadLine());
            int resFeet = feetIn * 12;
            Console.WriteLine("In inches, that's {0}" ,resFeet);
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void echo()
        {
            Console.Write("I can make an echo! Please give me a word: ");
            string Word = Console.ReadLine();
            string upWord = Word.ToUpper();
            string downWord = Word.ToLower();
            Console.Write(upWord);
            Console.Write(downWord);
            Console.Write(downWord);
            Console.WriteLine();
            Console.WriteLine();
         
        }

        public static void kilograms()
        {
            Console.Write("I know how to convert pounds to kilograms. Can you give me a weight in pounds?: ");
            double lbs = Convert.ToDouble(Console.ReadLine());
            double kilo = lbs / 2.205;
            Console.Write("In kilograms, that would be about {0}", kilo);
            Console.WriteLine();
            Console.WriteLine();
        }
        public static void date()
        {
            DateTime today = DateTime.Now;
            string now = Convert.ToString(DateTime.Now.ToShortDateString());
            Console.Write("By the way, today is {0}" ,now);
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void age()
        {
            Console.Write("Let's see if I can figure out your age. What year were you born?: ");
            int year = Convert.ToInt32(Console.ReadLine());
            int age = 2019 - year;
            Console.Write("So you are or are close to {0} ", age);
            Console.WriteLine();
            Console.WriteLine();
            
        }

        public static void guess()
        {
            string correctWord = "csharp";
            bool correct = false;
     
            
            Console.Write("I'm thinking of a word...");
            Console.Write("Enter your guess: ");
            
            while (correct != true)
            {
                string userGuess = Console.ReadLine();

                if (userGuess == correctWord || userGuess == "csharp")
                {
                    Console.Write("Correct! Thanks for playing with me :)");
                    correct = true;
                                     
                }
                else
                {
                    Console.Write("Sorry! Please try again: ");
                    
                
                }
                
            }
            Console.Read();
        }
    }
}

