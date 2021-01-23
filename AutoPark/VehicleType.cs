using System;
using Microsoft.VisualBasic.CompilerServices;

namespace AutoPark
{
    public class VehicleType
    {
        public int VehicleTypeId { get; set; }
        public string TypeName { get; set; }
        public double TaxCoefficient { get; set; }

        public VehicleType() { }

        public VehicleType(string typeName, double taxCoefficient)
        {
            TypeName = typeName;
            TaxCoefficient = taxCoefficient;
        }

        public void Display()
        {
            Console.WriteLine($"TypeName = {TypeName} \nTaxCoefficient = {TaxCoefficient}");
        }

        public override string ToString()
        {
            string format;
            format = string.Format($"{TypeName}, \"{TaxCoefficient}\"");
            return format;
        }
    }
}