using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace AutoPark
{
    public class Collections
    {
        public List<Vehicle> Vehicles { get; set; }
        public List<VehicleType> Types { get; set; }

        public Collections(string type, string vehicles, string rents)
        {
            Types = LoadTypes(type);
            Vehicles = LoadVehicles(vehicles);
            LoadRents(rents);
        }

        public List<VehicleType> LoadTypes(string inFile)
        {
            var types = new List<VehicleType>();
            try
            {
                using (StreamReader streamReader = new StreamReader(inFile, Encoding.Default))
                {
                    string line;
                    while (!streamReader.EndOfStream)
                    {
                        line = streamReader.ReadLine();
                        types.Add(CreateType(line));
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File {inFile} wasn't found");
                
            }
            return types;
        }

        public List<Vehicle> LoadVehicles(string inFile)
        {
            var vehicles = new List<Vehicle>();
            try
            {
                using (StreamReader streamReader = new StreamReader(inFile,Encoding.Default))
                {
                    string line;
                    while (!streamReader.EndOfStream)
                    {
                        line = streamReader.ReadLine();
                        vehicles.Add(CreateVehicle(line));
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File {inFile} wasn't found");
            }

            return vehicles;
        }

        public void LoadRents(string inFile)
        {
            NumberFormatInfo numbInfo = new NumberFormatInfo() {NumberDecimalSeparator = "."};
            try
            {
                using (StreamReader streamReader = new StreamReader(inFile,Encoding.Default))
                {
                    string line;
                    string[] values;
                    while (!streamReader.EndOfStream)
                    {
                        line = streamReader.ReadLine();
                        values = line.Split(',');
                        foreach (var vehicle in Vehicles)
                        {
                            if (int.Parse(values[0]) == vehicle.VehicleId)
                            {
                                vehicle.Rents.Add(new Rent(DateTime.Parse(values[1]), double.Parse(values[2], numbInfo)));
                            }
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File {inFile} wasn't found");
            }
        }

        public VehicleType CreateType(string csvString)
        {
            NumberFormatInfo numbInfo = new NumberFormatInfo() {NumberDecimalSeparator = "."};
            string[] line = csvString.Split(',');
            var type = new VehicleType();
            type.VehicleTypeId = int.Parse(line[0]);
            type.TypeName = line[1];
            type.TaxCoefficient = double.Parse(line[2], numbInfo);
            return type;
        }

        public Vehicle CreateVehicle(string csvString)
        {
            NumberFormatInfo numbInfo = new NumberFormatInfo() {NumberDecimalSeparator = "."};
            string[] line = csvString.Split(',');
            var vehicle = new Vehicle();
            vehicle.VehicleId = int.Parse(line[0]);
            vehicle.Type = new VehicleType();
            string typesLine = Path.GetFullPath("../../../../type.csv");
            var types = new List<VehicleType>();
            types = LoadTypes(typesLine);
            foreach (var type in types)
            {
                if (type.VehicleTypeId == int.Parse(line[1]))
                {
                    vehicle.Type = type;
                }
            }
            vehicle.ModelName = line[2];
            vehicle.RegistrationNumber = line[3];
            vehicle.Weight = int.Parse(line[4]);
            vehicle.ManufactureYear = int.Parse(line[5]);
            vehicle.Mileage = int.Parse(line[6]);
            vehicle.Clr = Enum.Parse<Vehicle.Color>(line[7]);
            switch (line[8])
            {
                case "Gasoline":
                    vehicle.AbstractEngine = new GasolineEngine(double.Parse(line[9], numbInfo), double.Parse(line[10], numbInfo),
                        int.Parse(line[11]));
                    break;
                case "Elecrtical":
                    vehicle.AbstractEngine = new ElectricalEngine(double.Parse(line[10], numbInfo),
                        int.Parse(line[11]));
                    break;
                case  "Diesel":
                    vehicle.AbstractEngine =
                        new DieselEngine(double.Parse(line[9], numbInfo), double.Parse(line[10],numbInfo), int.Parse(line[11]));
                    break;
                default:
                    vehicle.AbstractEngine = null;
                    break;
            }

            vehicle.Volume = int.Parse(line[11]);
            vehicle.Rents = new List<Rent>();
            return vehicle;
        }

        public void Insert(int index, Vehicle vehicle)
        {
            Vehicles.Insert(index,vehicle);
        }

        public int Delete(int index)
        {
            if (index > Vehicles.Count || index < 0)
            {
                return -1;
            }
            Vehicles.RemoveAt(index);
            return index;
        }

        public double SumTotalProfit()
        {
            double sum = 0.0;
            foreach (var vehicle in Vehicles)
            {
                sum += vehicle.GetTotalProfit();
            }

            return sum;
        }

        public void Print()
        {
            Console.WriteLine("{0,-5}{1,-10}{2,-25}{3,-15}{4,-15}{5,-10}{6,-10}{7,-10}{8,-10}{9,-10}{10,-10}",
                "Id",
                "Type",
                "ModelName",
                "Number",
                "Weight (kg)",
                "Year",
                "Mileage",
                "Color",
                "Income",
                "Tax",
                "Profit");
            foreach (var vehicle in Vehicles)
            {
                Console.WriteLine("{0,-5}{1,-10}{2,-25}{3,-15}{4,-15}{5,-10}{6,-10}{7,-10}{8,-10}{9,-10}{10,-10}",
                    vehicle.VehicleId,
                    vehicle.Type.TypeName,
                    vehicle.ModelName,
                    vehicle.RegistrationNumber,
                    vehicle.Weight,
                    vehicle.ManufactureYear,
                    vehicle.Mileage,
                    vehicle.Clr,
                    vehicle.GetTotalIncome().ToString("0.00"),
                    vehicle.GetCalcTaxPerMonth().ToString("0.00"),
                    vehicle.GetTotalProfit().ToString("0.00"));
            }
        }

        public void Sort(IComparer<Vehicle> comparer)
        {
            for (int i = 0; i < Vehicles.Count - 1; i++)
            {
                for (int j = i + 1; j < Vehicles.Count; j++)
                {
                    if (comparer.Compare(Vehicles[i],Vehicles[j]) == 1)
                    {
                        var temp = Vehicles[i];
                        Vehicles[i] = Vehicles[j];
                        Vehicles[j] = temp;
                    }
                }
            }
        }
    }
}