namespace AutoPark
{
    public class Stack
    {
        public Vehicle[] Vehicles { get; set; }

        public Stack()
        {
            Vehicles = new Vehicle[0];
        }

        public Stack(Vehicle[] vehicles)
        {
            Vehicles = vehicles;
        }

        public void Push(Vehicle vehicle)
        {
            Vehicle[] tempVehicles = new Vehicle[Vehicles.Length + 1];
            for (int i = 0; i < Vehicles.Length; i++)
            {
                tempVehicles[i] = Vehicles[i];
            }

            tempVehicles[tempVehicles.Length - 1] = vehicle;
            Vehicles = tempVehicles;
        }

        public void Pop()
        {
            Vehicle[] tempVehicles = new Vehicle[Vehicles.Length - 1];
            for (int i = 0; i < tempVehicles.Length; i++)
            {
                tempVehicles[i] = Vehicles[i];
            }

            Vehicles = tempVehicles;
        }
    }
}