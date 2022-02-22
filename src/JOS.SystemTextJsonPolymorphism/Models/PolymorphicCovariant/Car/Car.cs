using System;

namespace JOS.SystemTextJsonPolymorphism.Models.PolymorphicCovariant.Car
{
    public class Car : Vehicle
    {
        public Car(string name, VehicleModel model, CarProperties properties) : base("car", name, model)
        {
            Properties = properties ?? throw new ArgumentNullException(nameof(properties));
        }

        public override CarProperties Properties { get; }
    }
}
