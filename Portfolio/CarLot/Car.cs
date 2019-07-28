using System;
using System.Collections.Generic;
using System.Text;

namespace CarLot
{
    public class Car : Vehicle
    {
        public string Type;
        public byte Doors;
        public Car(string type, byte doors, int licenseNumber, string make, string model, double price) : base(licenseNumber, make, model, price)
        {
            Type = type;
            Doors = doors;
        }
        public override string VehicleInfo() { return string.Format("Car: License {0}, {1}-door {2} {3} {4}, ${5}", LicenseNumber, Doors, Make, Model, Type, Price); }

    }
}
