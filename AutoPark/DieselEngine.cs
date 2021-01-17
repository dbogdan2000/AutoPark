namespace AutoPark
{
    public class DieselEngine : AbstractCombustionEngine
    {
        public DieselEngine(double engineVolume, double fuelConsumptionPer100, int horsePowers) : base("Diesel", 1.2)
        {
            EngineVolume = engineVolume;
            FuelConsumptionPer100 = fuelConsumptionPer100;
            HorsePowers = horsePowers;
        }
    }
}