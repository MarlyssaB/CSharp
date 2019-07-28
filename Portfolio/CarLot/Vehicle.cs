using System;
using System.Collections.Generic;
using System.Text;

namespace CarLot
{
    public abstract class Vehicle 
    {
        public virtual int LicenseNumber { get; set; }
        public virtual string Make { get; set; }
        public virtual string Model { get; set; }
        public virtual double Price { get; set; }

        public Vehicle(int licenseNumber, string make, string model, double price)
        {
            LicenseNumber = licenseNumber;
            Make = make;
            Model = model;
            Price = price;
        }

        public virtual string VehicleInfo()
        {
            return string.Format("{0}, {1} {2}, ${3}", LicenseNumber, Make, Model, Price);
        }
    }
  
}
