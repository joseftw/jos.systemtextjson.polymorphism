using System;
using System.Text.Json.Serialization;
using JOS.SystemTextJsonPolymorphism.PolymorphicCovariant.Serialization;

namespace JOS.SystemTextJsonPolymorphism.PolymorphicCovariant
{
    [JsonConverter(typeof(VehicleJsonConverter))]
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
        public abstract VehicleProperties Properties { get; }
    }
}
