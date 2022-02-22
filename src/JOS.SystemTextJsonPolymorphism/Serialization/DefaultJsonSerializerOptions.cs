using System.Text.Json;

namespace JOS.SystemTextJsonPolymorphism.Serialization
{
    public static class DefaultJsonSerializerOptions
    {
        static DefaultJsonSerializerOptions()
        {
            Instance = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public static JsonSerializerOptions Instance { get; }
    }
}
