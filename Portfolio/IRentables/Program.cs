using System;
using System.Collections.Generic;
namespace IRentables
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IRentable> avail = new List<IRentable>();
            avail.Add(new Boat("Bright red motorboat", 10));
            avail.Add(new Boat("25ft bass boat", 55));
            avail.Add(new Boat("Blue swan paddleboat", 7));
            avail.Add(new Car("Blue 2018 Honda Accord", 35));
            avail.Add(new Car("Green 2015 Ford Mustang Convertible", 65));
            avail.Add(new Car("Grey 2019 Dodge Grand Caravan", 40));
            avail.Add(new House("3/1 Townhome in Chesapeake", 325));
            avail.Add(new House("4/2 Split Level in Bremerton", 598));
            avail.Add(new House("2/1.5 Ranch House in Dallas", 288));

            foreach (IRentable rentables in avail)
            {
                rentables.rate();
                Console.WriteLine();
            }

            Console.Read();

        }
    }
    public interface IRentable
    {
        void rate();
    }

    public class Boat : IRentable
    {
        string Description;
        byte Rate;
        double HourRate;


        public Boat(string description, byte rate)
        {
            Description = description;
            Rate = rate;
            HourRate = rate * 24;
           
        }

        public void rate()
        {
            Console.WriteLine("Boat: A {0}. Rental rates: ${1}/hour or ${2}/day.", Description, Rate, HourRate);
        }
    }

    public class House : IRentable
    {
        string Description;
        int Rate;
        double DayRate;

        public House(string description, int rate)
        {
            Description = description;
            Rate = rate;
            DayRate = rate / 7;
        }

        public void rate()
        {
            Console.WriteLine("House: A {0}. Rental rates: ${1}/day or ${2}/week.", Description, DayRate, Rate);
        }
    }

    public class Car : IRentable
    {
        string Description;
        byte Rate;

        public Car(string description, byte rate)
        {
            Description = description;
            Rate = rate;
        }
        
        public void rate()
        {
            Console.WriteLine("Car: A {0}. Rental rate: ${1}/day.", Description, Rate);
        }
    }
}
