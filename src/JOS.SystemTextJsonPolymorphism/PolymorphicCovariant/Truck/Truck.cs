namespace JOS.SystemTextJsonPolymorphism.PolymorphicCovariant.Truck
{
    public class Truck : Vehicle
    {
        public Truck(
            string type,
            string name,
            VehicleModel model,
            TruckProperties properties,
            TruckTrailer trailer) : base(type,
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
