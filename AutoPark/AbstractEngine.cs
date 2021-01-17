namespace AutoPark
{
    public abstract class AbstractEngine
    {
        public string EngineType { get; set; }
        public double TaxCoefficientByEngine { get; set; }

        public int HorsePowers { get; set; }

        public AbstractEngine(string engineType, double taxCoefficientByEngine)
        {
            EngineType = engineType;
            TaxCoefficientByEngine = taxCoefficientByEngine;
        }

        public abstract double GetMaxKilometers(double fuelTank);
    }
}