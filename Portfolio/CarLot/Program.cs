using System;
using System.Collections.Generic;

namespace CarLot
{
    class Program
    {
        static void Main(string[] args)
        {
            CarLot smith = new CarLot("Smith's");
            CarLot brown = new CarLot("Brown's");

            Car s1 = new Car("sedan", 4, 140466, "Ford", "Fiesta", 8992.89);
            smith.AddVehicle(s1);
            Truck s2 = new Truck("short", 131602, "Toyota", "Tundra", 20220.49);
            smith.AddVehicle(s2);
            Truck s3 = new Truck("standard", 280793, "Chevrolet", "Silverado", 32433.72);
            smith.AddVehicle(s3);
            Car s4 = new Car("coupe", 2, 662012, "Mercury", "Cougar", 2995.98);
            smith.AddVehicle(s4);

            Car b1 = new Car("hatchback", 4, 201506, "Chrysler", "PT Cruiser", 5898.26);
            brown.AddVehicle(b1);
            Car b2 = new Car("coupe", 2, 772023, "Ford", "Mustang", 10276.99);
            brown.AddVehicle(b2);
            Truck b3 = new Truck("long", 140203, "GMC", "Sierra", 26782.58);
            brown.AddVehicle(b3);
            Car b4 = new Car("sedan", 4, 260615,"Mini", "Countryman", 16822.78);
            brown.AddVehicle(b4);

            Console.WriteLine("Which lot would you like to visit: Smith's (S) or Brown's (B)?");
            string answer = Console.ReadLine().ToUpper();

            if (answer == "S")
            {
                Console.WriteLine();
                Console.WriteLine("Vehicles currently available at Smith's:");
                smith.Inventory();
                Console.Read();

            }
            else if (answer == "B")
            {
                Console.WriteLine();
                Console.WriteLine("Vehicles currently available at Brown's:");
                brown.Inventory();
                Console.Read();
              
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Invalid entry.");
                Console.Read();

            }




        }
    }

    public class CarLot
    {
        public string Name { get; set; }
        public List<Vehicle> available = new List<Vehicle>();

        public CarLot(string name)
        {
            name = Name;
           
        }
        public void AddVehicle(Vehicle vehicle)
        {
            available.Add(vehicle);
        }
        public void Inventory()
        {
            foreach (Vehicle vehicle in available)
            {
                Console.WriteLine(vehicle.VehicleInfo());
            }
        }




    }


}
