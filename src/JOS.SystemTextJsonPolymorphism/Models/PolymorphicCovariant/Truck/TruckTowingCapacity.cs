namespace JOS.SystemTextJsonPolymorphism.Models.PolymorphicCovariant.Truck
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
