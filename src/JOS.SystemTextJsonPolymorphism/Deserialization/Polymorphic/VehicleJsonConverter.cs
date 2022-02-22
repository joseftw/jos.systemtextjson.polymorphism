using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using JOS.SystemTextJsonPolymorphism.Models.Polymorphic;
using JOS.SystemTextJsonPolymorphism.Models.Polymorphic.Car;
using JOS.SystemTextJsonPolymorphism.Models.Polymorphic.Truck;

namespace JOS.SystemTextJsonPolymorphism.Deserialization.Polymorphic
{
    public class VehicleJsonConverter : JsonConverter<Vehicle>
    {
        public override bool CanConvert(Type type)
        {
            return type.IsAssignableFrom(typeof(Vehicle));
        }

        public override Vehicle Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (JsonDocument.TryParseValue(ref reader, out var doc))
            {
                if (doc.RootElement.TryGetProperty("type", out var type))
                {
                    var typeValue = type.GetString();
                    var rootElement = doc.RootElement.GetRawText();

                    return typeValue switch
                    {
                        "car" => JsonSerializer.Deserialize<Car>(rootElement, options)!,
                        "truck" => JsonSerializer.Deserialize<Truck>(rootElement, options)!,
                        _ => throw new JsonException($"{typeValue} has not been mapped to a custom type yet!")
                    };
                }

                throw new JsonException("Failed to extract type property, it might be missing?");
            }

            throw new JsonException("Failed to parse JsonDocument");
        }

        public override void Write(Utf8JsonWriter writer, Vehicle value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
