namespace JOS.SystemTextJsonPolymorphism.Models.PolymorphicCovariant.Truck
{
    public class Truck : Vehicle
    {
        public Truck(
            string name,
            VehicleModel model,
            TruckProperties properties,
            TruckTrailer trailer) : base("truck",
            name,
            model)
        {
            Trailer = trailer;
            Properties = properties;
        }
        
        public TruckTrailer Trailer { get; }
        public override TruckProperties Properties { get; }
    }
}
