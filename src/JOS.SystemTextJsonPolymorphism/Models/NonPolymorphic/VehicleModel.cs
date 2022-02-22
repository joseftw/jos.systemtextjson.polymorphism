namespace JOS.SystemTextJsonPolymorphism.Models.NonPolymorphic
{
    public class VehicleModel
    {
        public VehicleModel(string brand, string name, string color, int horsepower)
        {
            Brand = brand;
            Name = name;
            Color = color;
            Horsepower = horsepower;
        }

        public string Brand { get; }
        public string Name { get; }
        public string Color { get; }
        public int Horsepower { get; }
    }
}
