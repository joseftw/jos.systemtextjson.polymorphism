namespace JOS.SystemTextJsonPolymorphism.Models.NonPolymorphic
{
    public class Trailer
    {
        public Trailer(string name, int wheels)
        {
            Name = name;
            Wheels = wheels;
        }

        public string Name { get; }
        public int Wheels { get; }
    }
}
