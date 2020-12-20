namespace JOS.SystemTextJsonPolymorphism.NonPolymorphic
{
    public class Vehicle
    {
        public Vehicle(string type, string name, int wheels, Trailer trailer, VehicleModel model, VehicleProperties properties)
        {
            Type = type;
            Name = name;
            Wheels = wheels;
            Trailer = trailer;
            Model = model;
            Properties = properties;
        }

        public string Type { get; }
        public string Name { get; }
        public int Wheels { get; }
        public VehicleModel Model { get; }
        public VehicleProperties Properties { get; }
        public Trailer Trailer { get; }
    }
}
