namespace JOS.SystemTextJsonPolymorphism.Models.NonPolymorphic
{
    public class VehicleProperties
    {
        public VehicleProperties(int wheels, int passengers, Rims rims, TruckTowingCapacity towingCapacity)
        {
            Wheels = wheels;
            Passengers = passengers;
            Rims = rims;
            TowingCapacity = towingCapacity;
        }

        public int Wheels { get; }
        public int Passengers { get; }
        public TruckTowingCapacity TowingCapacity { get; }
        public Rims Rims { get; }
    }
}