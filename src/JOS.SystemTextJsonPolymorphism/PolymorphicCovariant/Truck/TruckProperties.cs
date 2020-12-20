using System;

namespace JOS.SystemTextJsonPolymorphism.PolymorphicCovariant.Truck
{
    public class TruckProperties : VehicleProperties
    {
        public TruckProperties(int wheels, int passengers, TruckTowingCapacity towingCapacity) : base(wheels, passengers)
        {
            TowingCapacity = towingCapacity ?? throw new ArgumentNullException(nameof(towingCapacity));
        }
        public TruckTowingCapacity TowingCapacity { get; }
    }
}