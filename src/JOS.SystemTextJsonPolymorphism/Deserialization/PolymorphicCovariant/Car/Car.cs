using System;

namespace JOS.SystemTextJsonPolymorphism.Deserialization.PolymorphicCovariant.Car
{
    public class Car : Vehicle
    {
        public Car(string type, string name, VehicleModel model, CarProperties properties) : base(type, name, model)
        {
            Properties = properties ?? throw new ArgumentNullException(nameof(properties));
        }

        public override CarProperties Properties { get; }
    }
}
