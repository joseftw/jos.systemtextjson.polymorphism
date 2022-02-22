using System;

namespace JOS.SystemTextJsonPolymorphism.Models.PolymorphicCovariant.Car
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
