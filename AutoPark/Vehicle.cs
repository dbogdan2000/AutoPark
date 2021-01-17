using System;

namespace AutoPark
{
    public class Vehicle : IComparable<Vehicle>
    {
        public VehicleType Type { get; set; }
        public string ModelName { get; set; }

        public AbstractEngine AbstractEngine { get; set; }
        public string RegistrationNumber { get; set; }
        public int Weight { get; set; }
        public int ManufactureYear { get; set; }
        public int Mileage { get; set; }
        public enum Color 
        {
            White,
            Blue,
            Green,
            Yellow,
            Red,
            Gray
        }

        public Color Clr { get; set; }
        
        public int Volume { get; set; }

        public Vehicle() { }
        
        public Vehicle(VehicleType type, string modelName, string registrationNumber, int weight, int manufactureYear,
            int mileage, Color clr, int volume)
        {
            Type = type;
            ModelName = modelName;
            RegistrationNumber = registrationNumber;
            Weight = weight;
            ManufactureYear = manufactureYear;
            Mileage = mileage;
            Clr = clr;
            Volume = volume;
        }
        public double GetCalcTaxPerMonth()
        {
            if (AbstractEngine == null)
                return Weight * 0.0013 + Type.TaxCoefficient * 30 + 5;
            return Weight * 0.0013 + Type.TaxCoefficient * AbstractEngine.TaxCoefficientByEngine * 30 + 5;
        }

        public override string ToString()
        {
            string format;
            if (AbstractEngine == null)
            {
                format = string.Format(
                    $"{Type.TypeName}, {ModelName}, {RegistrationNumber}, {Weight} kg, {ManufactureYear}, {Mileage} km, {Clr}, {Volume} l(kWh), \"{GetCalcTaxPerMonth().ToString("0.00")}\"");    
            }
            else
            {
                format = string.Format(
                    $"{Type.TypeName}, {ModelName}, {AbstractEngine.EngineType}, {RegistrationNumber}, {Weight} kg, {ManufactureYear}, {Mileage} km, {Clr}, {Volume} l(Wh), \"{GetCalcTaxPerMonth().ToString("0.00")}\"");
            }
            return format;
        }

        public override bool Equals(object obj)
        {
            Vehicle secVehicle = obj as Vehicle;
            if (secVehicle == null)
                return false;
            return ModelName == secVehicle.ModelName && Type == secVehicle.Type;
        }

        public int CompareTo(Vehicle secVehicle)
        {
            if (GetCalcTaxPerMonth() < secVehicle.GetCalcTaxPerMonth())
            {
                return -1;
            }
            else if (GetCalcTaxPerMonth() == secVehicle.GetCalcTaxPerMonth())
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}