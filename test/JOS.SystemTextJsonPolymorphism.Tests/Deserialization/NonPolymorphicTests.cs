using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using JOS.SystemTextJsonPolymorphism.Models.NonPolymorphic;
using JOS.SystemTextJsonPolymorphism.Serialization;
using Shouldly;
using Xunit;

namespace JOS.SystemTextJsonPolymorphism.Tests.Deserialization
{
    public class NonPolymorphicTests
    {
        [Fact]
        public async Task ShouldDeserializeVehiclesCorrectly()
        {
            using var jsonFile = File.OpenRead(Path.Combine("Deserialization", "example.json"));
            var result = await JsonSerializer.DeserializeAsync<List<Vehicle>>(jsonFile, DefaultJsonSerializerOptions.Instance);
                
            result.Count.ShouldBe(2);
            var car = result.Single(x => x.Type == "car");
            var truck = result.Single(x => x.Type == "truck");
            car.Type.ShouldBe("car");
            car.Name.ShouldBe("Josefs Car");
            car.Model.Brand.ShouldBe("Ferrari");
            car.Model.Name.ShouldBe("458 Spider");
            car.Model.Color.ShouldBe("red");
            car.Model.Horsepower.ShouldBe(562);
            car.Properties.Wheels.ShouldBe(4);
            car.Properties.Passengers.ShouldBe(2);
            car.Properties.Rims.Name.ShouldBe("Nutek");
            truck.Type.ShouldBe("truck");
            truck.Name.ShouldBe("Josefs Truck");
            truck.Model.Name.ShouldBe("FH");
            truck.Model.Brand.ShouldBe("Volvo");
            truck.Model.Color.ShouldBe("black");
            truck.Model.Horsepower.ShouldBe(540);
            truck.Properties.Wheels.ShouldBe(8);
            truck.Properties.Passengers.ShouldBe(2);
            truck.Properties.TowingCapacity.MaxKg.ShouldBe(18000);
            truck.Properties.TowingCapacity.MaxPounds.ShouldBe(39683);
            truck.Trailer.Name.ShouldBe("my trailer");
            truck.Trailer.Wheels.ShouldBe(8);
        }
    }
}
