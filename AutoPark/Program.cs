using System;

namespace AutoPark
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayLevel(1);
            VehicleType[] vehicleTypes = new VehicleType[4];
            vehicleTypes[0] = new VehicleType("Bus", 1.2);
            vehicleTypes[1] = new VehicleType("Car", 1);
            vehicleTypes[2] = new VehicleType("Rink", 1.5);
            vehicleTypes[3] = new VehicleType("Tractor", 1.2);
            vehicleTypes[3].TaxCoefficient = 1.3;
            double max = vehicleTypes[0].TaxCoefficient;
            double avg = 0.0;
            for (int i = 0; i < vehicleTypes.Length; i++)
            {
                vehicleTypes[i].Display();
                if (vehicleTypes[i].TaxCoefficient > max)
                {
                    max = vehicleTypes[i].TaxCoefficient;
                }

                avg += vehicleTypes[i].TaxCoefficient;
                if (i == vehicleTypes.Length - 1)
                {
                    avg /= vehicleTypes.Length;
                }
            }
            Console.WriteLine($"Max value: {max} \nAverage value: {avg}");
            foreach (var vehicleType in vehicleTypes)
            {
                Console.WriteLine(vehicleType.ToString());
            }
            
            DisplayLevel(2);
            Vehicle[] vehicles = new Vehicle[7];
            vehicles[0] = new Vehicle(vehicleTypes[0], "Volkswagen Crafter", "5427 AX-7", 2022,
                2015, 376000, Vehicle.Color.Blue, 75);
            vehicles[1] = new Vehicle(vehicleTypes[0], "Volkswagen Crafter", "6427 AA-7", 2500,
                2014, 227010, Vehicle.Color.White, 75);
            vehicles[2] = new Vehicle(vehicleTypes[0], "Electric Bus E321", "6785 BA-7", 12080,
                2019, 20451, Vehicle.Color.Green, 34);
            vehicles[3] = new Vehicle(vehicleTypes[1], "Golf 5", "8682 AX-7", 1200,
                2006, 230451, Vehicle.Color.Gray, 55);
            vehicles[4] = new Vehicle(vehicleTypes[1], "Tesla Model S70D", "E001 AA-7", 2200,
                2019, 10454, Vehicle.Color.White, 70);
            vehicles[5] = new Vehicle(vehicleTypes[2], "Hamm HD 12 VV", null, 3000,
                2016, 122, Vehicle.Color.Yellow, 42);
            vehicles[6] = new Vehicle(vehicleTypes[3], "МТЗ Беларус-1025.4", "1145 AB-7", 1200,
                2020, 109, Vehicle.Color.Red, 135);
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle.ToString());
            }
            Console.WriteLine();
            Array.Sort(vehicles);
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle.ToString());
            }
            Console.WriteLine();
            int minMileage = vehicles[0].Mileage;
            int vehicleNumbWithMin = 0;
            int maxMileage = vehicles[0].Mileage;
            int vehicleNumbWithMax = 0;
            for(int i = 0; i < vehicles.Length; i++)
            {
                if (minMileage > vehicles[i].Mileage)
                {
                    minMileage = vehicles[i].Mileage;
                    vehicleNumbWithMin = i;
                }

                if (maxMileage < vehicles[i].Mileage)
                {
                    maxMileage = vehicles[i].Mileage;
                    vehicleNumbWithMax = i;
                }
            }
            Console.WriteLine($"Min mileage: {vehicles[vehicleNumbWithMin].ToString()},\nMax mileage: {vehicles[vehicleNumbWithMax].ToString()}");
            
            DisplayLevel(3);
            Vehicle[] vehiclesWithEngine = new Vehicle[7];
            vehiclesWithEngine[0] = new Vehicle(vehicleTypes[0], "Volkswagen Crafter", "5427 AX-7", 2022,
                2015, 376000, Vehicle.Color.Blue, 75);
            vehiclesWithEngine[1] = new Vehicle(vehicleTypes[0], "Volkswagen Crafter", "6427 AA-7", 2500,
                2014, 227010, Vehicle.Color.White, 75);
            vehiclesWithEngine[2] = new Vehicle(vehicleTypes[0], "Electric Bus E321", "6785 BA-7", 12080,
                2019, 20451, Vehicle.Color.Green, 34000);
            vehiclesWithEngine[3] = new Vehicle(vehicleTypes[1], "Golf 5", "8682 AX-7", 1200,
                2006, 230451, Vehicle.Color.Gray, 55);
            vehiclesWithEngine[4] = new Vehicle(vehicleTypes[1], "Tesla Model S70D", "E001 AA-7", 2200,
                2019, 10454, Vehicle.Color.White, 70000);
            vehiclesWithEngine[5] = new Vehicle(vehicleTypes[2], "Hamm HD 12 VV", null, 3000,
                2016, 122, Vehicle.Color.Yellow, 42);
            vehiclesWithEngine[6] = new Vehicle(vehicleTypes[3], "МТЗ Беларус-1025.4", "1145 AB-7", 1200,
                2020, 109, Vehicle.Color.Red, 135);
            vehiclesWithEngine[0].AbstractEngine = new GasolineEngine(2, 8.1, 75);
            vehiclesWithEngine[1].AbstractEngine = new GasolineEngine(2.18, 8.5, 75);
            vehiclesWithEngine[2].AbstractEngine = new ElectricalEngine(50, 150);
            vehiclesWithEngine[3].AbstractEngine = new DieselEngine(1.6, 7.2, 55);
            vehiclesWithEngine[4].AbstractEngine = new ElectricalEngine(25, 70);
            vehiclesWithEngine[5].AbstractEngine = new DieselEngine(3.2, 25, 20);
            vehiclesWithEngine[6].AbstractEngine = new DieselEngine(4.75, 20.1, 135);
            foreach (var vehicle in vehiclesWithEngine)
            {
                Console.WriteLine(vehicle.ToString());
            }
            Console.WriteLine();
            for (int i = 0; i < vehiclesWithEngine.Length; i++)
            {
                for (int j = i+1; j < vehiclesWithEngine.Length; j++)
                {
                    if (vehiclesWithEngine[i].Equals(vehiclesWithEngine[j]))
                    {
                        Console.WriteLine($"Identical vehicles: {vehiclesWithEngine[i].ToString()} and {vehiclesWithEngine[j].ToString()}");
                    }
                }
            }
            
            DisplayLevel(4);
            foreach (var vehicle in vehiclesWithEngine)
            {
                Console.WriteLine(vehicle);
            }
            Console.WriteLine();
            double maxDistance = vehiclesWithEngine[0].AbstractEngine.GetMaxKilometers(vehiclesWithEngine[0].Volume);
            int maxDistanceIndex = 0;
            for (int i = 0; i < vehiclesWithEngine.Length; i++)
            {
                if (vehiclesWithEngine[i].AbstractEngine.GetMaxKilometers(vehiclesWithEngine[i].Volume) > maxDistance)
                {
                    maxDistance = vehiclesWithEngine[i].AbstractEngine.GetMaxKilometers(vehiclesWithEngine[i].Volume);
                    maxDistanceIndex = i;
                }
            }
            Console.WriteLine($"A vehicle that travels a longer distance: {vehiclesWithEngine[maxDistanceIndex].ToString()}");
            
        }

        private static void DisplayLevel(int level)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Level {level}");
            Console.ResetColor();
        }
    }
}