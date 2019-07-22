using System;

namespace PoCos
{
    class Program
    {
        static void Main(string[] args)
        {
            
            DriversLicense dl = new DriversLicense("Paul", "Norman");
            dl.sex = 'm';
            dl.DLNumber = 140466;
            Console.WriteLine(dl.FullName);

            Console.Read();

        }
    }
    public class DriversLicense
    {
        public string firstName;
        public string lastName;
        public char sex;
        public int DLNumber;
        public string FullName { get; }

        public DriversLicense(string initialFirstName, string initialLastName)
        {
            this.firstName = initialFirstName;
            this.lastName = initialLastName;
           this.FullName = (this.firstName + " " + this.lastName);
            
        }
    }
  


    class Book
    {
        public string title;
        public string authors;
        public short pages;
        public int SKU;
        public string publisher;
        public string price;
    }

    class Airplane
    {
        public string manufacturer;
        public string model;
        public string varient;
        public short capacity;
        public byte numberOfEngines;
    }
}

