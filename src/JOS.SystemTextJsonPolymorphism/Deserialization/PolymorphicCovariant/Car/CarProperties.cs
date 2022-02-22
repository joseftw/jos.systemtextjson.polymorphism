using System;

namespace JOS.SystemTextJsonPolymorphism.Deserialization.PolymorphicCovariant.Car
{
    public class CarProperties : VehicleProperties
    {
        public CarProperties(int wheels, int passengers, CarRims rims) : base(wheels, passengers)
        {
            Rims = rims ?? throw new ArgumentNullException(nameof(rims));
        }

        public CarRims Rims { get; }
    }
}
