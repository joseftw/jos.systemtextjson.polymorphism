using System;

namespace JOS.SystemTextJsonPolymorphism.Deserialization.Polymorphic
{
    public class VehicleModel
    {
        public VehicleModel(string brand, string name, string color, int horsepower)
        {
            Brand = brand ?? throw new ArgumentNullException(nameof(brand));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Color = color ?? throw new ArgumentNullException(nameof(color));
            Horsepower = horsepower;
        }

        public string Brand { get; }
        public string Name { get; }
        public string Color { get; }
        public int Horsepower { get; }
    }
}
