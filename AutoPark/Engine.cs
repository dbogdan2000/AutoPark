namespace AutoPark
{
    public class Engine
    {
        public string EngineType { get; set; }
        public double TaxCoefficientByEngine { get; set; }

        public int HorsePowers { get; set; }

        public Engine(string engineType, double taxCoefficientByEngine)
        {
            EngineType = engineType;
            TaxCoefficientByEngine = taxCoefficientByEngine;
        }
    }
}