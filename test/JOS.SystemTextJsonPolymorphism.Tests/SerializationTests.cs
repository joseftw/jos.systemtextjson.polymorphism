using System.Text.Json;
using JOS.SystemTextJsonPolymorphism.Models;
using JOS.SystemTextJsonPolymorphism.Models.PolymorphicCovariant;
using JOS.SystemTextJsonPolymorphism.Models.PolymorphicCovariant.Car;
using JOS.SystemTextJsonPolymorphism.Serialization;
using Shouldly;
using Xunit;

namespace JOS.SystemTextJsonPolymorphism.Tests;

public class SerializationTests
{
    [Fact]
    public void ShouldNotContainRimsPropertyOnPropertiesWhenUsingDefaultBehaviour()
    {
        var vehicleModel = new VehicleModel(
            "Ferrari",
            "458 Spider",
            "Red",
            562);
        var carProperties = new CarProperties(4, 2, new CarRims("Nutek"));
        Vehicle vehicle = new Car("Josefs Car", vehicleModel, carProperties);

        var json = JsonSerializer.Serialize(vehicle);

        var result = JsonDocument.Parse(json);
        result.RootElement.GetProperty("Properties").TryGetProperty("Rims", out _).ShouldBeFalse();
    }

    [Fact]
    public void ShouldContainRimsPropertyWhenUsingCustomJsonConverter()
    {
        var vehicleModel = new VehicleModel(
            "Ferrari",
            "458 Spider",
            "Red",
            562);
        var carProperties = new CarProperties(4, 2, new CarRims("Nutek"));
        Vehicle vehicle = new Car("Josefs Car", vehicleModel, carProperties);

        var json = JsonSerializer.Serialize(vehicle, new JsonSerializerOptions
        {
            Converters = { new AbstractJsonConverterFactory() }
        });

        var result = JsonDocument.Parse(json);
        result.RootElement.GetProperty("Properties").TryGetProperty("Rims", out _).ShouldBeTrue();
    }

    [Fact]
    public void ShouldNotContainCheesePropertyWhenUsingDefaultBehaviour()
    {
        Hamburger hamburger = new Cheeseburger(Cheese.Gouda);

        var json = JsonSerializer.Serialize(hamburger);
        
        var result = JsonDocument.Parse(json);
        result.RootElement.GetProperty("Ingredients").TryGetProperty("Cheese", out _).ShouldBeFalse();
    }

    [Fact]
    public void ShouldContainCheesePropertyWhenUsingCustomJsonConverter()
    {
        Hamburger hamburger = new Cheeseburger(Cheese.Gouda);

        var json = JsonSerializer.Serialize(hamburger, new JsonSerializerOptions
        {
            Converters = { new AbstractJsonConverterFactory() }
        });

        var result = JsonDocument.Parse(json);
        result.RootElement.GetProperty("Ingredients").TryGetProperty("Cheese", out var cheese).ShouldBeTrue();
        ((Cheese)cheese.GetInt32()).ShouldBe(Cheese.Gouda);
    }
}
