namespace AutoPark
{
    public class Queue
    {
        public Vehicle[] Vehicles { get; set; }
        
        public Queue(){ }

        public Queue(Vehicle[] vehicles)
        {
            Vehicles = vehicles;
        }

        public void Enqueue(Vehicle vehicle)
        {
            Vehicle[] tempVehicles = new Vehicle[Vehicles.Length + 1];
            for (int i = 0; i < Vehicles.Length; i++)
            {
                tempVehicles[i] = Vehicles[i];
            }
            tempVehicles[tempVehicles.Length - 1] = vehicle;
            Vehicles = tempVehicles;
        }

        public void Dequeue()
        {
            Vehicle[] tempVehicles = new Vehicle[Vehicles.Length - 1];
            for (int i = 1; i < Vehicles.Length; i++)
            {
                tempVehicles[i - 1] = Vehicles[i];
            }
            Vehicles = tempVehicles;
        }
    }
}