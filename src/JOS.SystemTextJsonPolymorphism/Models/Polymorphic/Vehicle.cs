using System;

namespace JOS.SystemTextJsonPolymorphism.Models.Polymorphic
{
    public abstract class Vehicle<T> : Vehicle where T : VehicleProperties
    {
        protected Vehicle(string type, string name, VehicleModel model, T properties) : base(type, name, model)
        {
            Properties = properties ?? throw new ArgumentNullException(nameof(properties));
        }
        
        public T Properties { get; }
    }

    public abstract class Vehicle
    {
        protected Vehicle(string type, string name, VehicleModel model)
        {
            Type = type ?? throw new ArgumentNullException(nameof(type));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Model = model ?? throw new ArgumentNullException(nameof(model));
        }
        
        public string Type { get; }
        public string Name { get; }
        public VehicleModel Model { get; }
    }
}
