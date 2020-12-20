namespace JOS.SystemTextJsonPolymorphism.Polymorphic.Truck
{
    public class TruckTowingCapacity
    {
        public TruckTowingCapacity(int maxKg, int maxPounds)
        {
            MaxKg = maxKg;
            MaxPounds = maxPounds;
        }

        public int MaxKg { get; }
        public int MaxPounds { get; }
    }
}
