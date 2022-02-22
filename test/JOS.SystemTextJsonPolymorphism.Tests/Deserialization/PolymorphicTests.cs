using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using JOS.SystemTextJsonPolymorphism.Deserialization.Polymorphic;
using JOS.SystemTextJsonPolymorphism.Models.Polymorphic;
using JOS.SystemTextJsonPolymorphism.Models.Polymorphic.Car;
using JOS.SystemTextJsonPolymorphism.Models.Polymorphic.Truck;
using JOS.SystemTextJsonPolymorphism.Serialization;
using Shouldly;
using Xunit;

namespace JOS.SystemTextJsonPolymorphism.Tests.Deserialization
{
    public class PolymorphicTests
    {
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public PolymorphicTests()
        {
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                Converters = { new VehicleJsonConverter() },
                PropertyNameCaseInsensitive = DefaultJsonSerializerOptions.Instance.PropertyNameCaseInsensitive
            };
        }

        [Fact]
        public async Task ShouldDeserializeVehiclesCorrectly()
        {
            await using var jsonFile = File.OpenRead(Path.Combine("Deserialization", "example.json"));
            var result = await JsonSerializer.DeserializeAsync<List<Vehicle>>(
                jsonFile,
                _jsonSerializerOptions);

            result.Count.ShouldBe(2);
            result.ShouldContain(x => x.GetType() == typeof(Car));
            result.ShouldContain(x => x.GetType() == typeof(Truck));
            var car = result.Single(x => x.Type == "car") as Car;
            var truck = result.Single(x => x.Type == "truck") as Truck;
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
