using System;
using System.Collections.Generic;
using System.Text;

namespace CarLot
{
    public class Truck : Vehicle
    {
        public string BedSize;
        public Truck(string bedSize, int licenseNumber, string make, string model, double price) : base(licenseNumber, make, model, price)
        {
            BedSize = bedSize;
        }
        public override string VehicleInfo() { return string.Format("Truck: License {0}, {1}-bed {2} {3}, ${4}", LicenseNumber, BedSize, Make, Model, Price); }

    }

   
}
