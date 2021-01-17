namespace AutoPark
{
    public class GasolineEngine : AbstractCombustionEngine
    {
        public GasolineEngine(double engineCapacity, double fuelConsumptionPer100, int horsePowers) : base("Gasoline", 1)
        {
            EngineVolume = engineCapacity;
            FuelConsumptionPer100 = fuelConsumptionPer100;
            HorsePowers = horsePowers;
        }
        
    }
}