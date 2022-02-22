using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JOS.SystemTextJsonPolymorphism;

public class AbstractJsonConverterFactory : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert.IsClass && typeToConvert.IsAbstract;
    }

    public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        var converterType = typeof(GenericJsonConverterSerializer<>).MakeGenericType(typeToConvert);
        return Activator.CreateInstance(converterType) as JsonConverter;
    }
}
