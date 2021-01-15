namespace AutoPark
{
    public class ElectricalEngine : Engine
    {
        public double ElectricityConsumption { get; set; }

        public ElectricalEngine(double electricityConsumption, int horsePowers) : base("Electrical", 0.1)
        {
            ElectricityConsumption = electricityConsumption;
            HorsePowers = horsePowers;
        }

        public double GetMaxKilometers(double batterySize)
        {
            return batterySize / ElectricityConsumption;
        }
    }
}