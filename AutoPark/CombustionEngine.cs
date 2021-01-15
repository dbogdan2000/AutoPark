namespace AutoPark
{
    public class CombustionEngine : Engine
    {
        public double EngineVolume { get; set; }
        public double FuelConsumptionPer100 { get; set; }

        public CombustionEngine(string engineType, double taxCoefficientByEngine) : base(engineType,
            taxCoefficientByEngine) { }

        public double GetMaxKilometers(double fuelTankCapacity)
        {
            return fuelTankCapacity * 100 / FuelConsumptionPer100;
        }
    }
}