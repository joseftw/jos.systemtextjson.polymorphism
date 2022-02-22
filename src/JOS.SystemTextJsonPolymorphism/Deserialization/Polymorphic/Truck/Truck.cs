namespace JOS.SystemTextJsonPolymorphism.Deserialization.Polymorphic.Truck
{
    public class Truck : Vehicle<TruckProperties>
    {
        public Truck(
            string type,
            string name,
            VehicleModel model,
            TruckProperties properties,
            TruckTrailer trailer) : base(type,
            name,
            model,
            properties)
        {
            Trailer = trailer;
        }
        
        public TruckTrailer Trailer { get; }
    }
}
