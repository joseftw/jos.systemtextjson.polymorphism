namespace JOS.SystemTextJsonPolymorphism.Models.Polymorphic.Car
{
    public class Car : Vehicle<CarProperties>
    {
        public Car(string name, VehicleModel model, CarProperties properties) : base("car", name, model, properties)
        {
        }
    }
}
