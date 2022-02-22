namespace JOS.SystemTextJsonPolymorphism.Models.Polymorphic.Truck
{
    public class Truck : Vehicle<TruckProperties>
    {
        public Truck(
            string name,
            VehicleModel model,
            TruckProperties properties,
            TruckTrailer trailer) : base("truck",
            name,
            model,
            properties)
        {
            Trailer = trailer;
        }
        
        public TruckTrailer Trailer { get; }
    }
}
