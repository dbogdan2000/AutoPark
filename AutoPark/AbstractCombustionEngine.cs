namespace AutoPark
{
    public abstract class AbstractCombustionEngine : AbstractEngine
    {
        public double EngineVolume { get; set; }
        public double FuelConsumptionPer100 { get; set; }

        protected AbstractCombustionEngine(string engineType, double taxCoefficientByEngine) : base(engineType,
            taxCoefficientByEngine) { }

        public override double GetMaxKilometers(double fuelTankCapacity)
        {
            return fuelTankCapacity * 100 / FuelConsumptionPer100;
        }
    }
}