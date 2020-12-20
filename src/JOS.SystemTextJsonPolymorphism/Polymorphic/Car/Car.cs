namespace JOS.SystemTextJsonPolymorphism.Polymorphic.Car
{
    public class Car : Vehicle<CarProperties>
    {
        public Car(string type, string name, VehicleModel model, CarProperties properties) : base(type, name, model, properties)
        {
        }
    }
}
