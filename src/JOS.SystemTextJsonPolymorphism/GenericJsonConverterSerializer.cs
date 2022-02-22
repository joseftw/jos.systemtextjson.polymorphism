using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JOS.SystemTextJsonPolymorphism;

public class GenericJsonConverterSerializer<T> : JsonConverter<T>
{
    public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        writer.WriteRawValue(JsonSerializer.Serialize(value as object, options));
    }
}
