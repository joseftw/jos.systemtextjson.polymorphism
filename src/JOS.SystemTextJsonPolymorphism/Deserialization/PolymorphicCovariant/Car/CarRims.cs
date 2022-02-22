using System;

namespace JOS.SystemTextJsonPolymorphism.Deserialization.PolymorphicCovariant.Car
{
    public class CarRims
    {
        public CarRims(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public string Name { get; }
    }
}
