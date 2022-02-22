using System.Text.Json;
using JOS.SystemTextJsonPolymorphism.Generic;
using Shouldly;
using Xunit;

namespace JOS.SystemTextJsonPolymorphism.Tests;

public class GenericSerializationTests
{
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
