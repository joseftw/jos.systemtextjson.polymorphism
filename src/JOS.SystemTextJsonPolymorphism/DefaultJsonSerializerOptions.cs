using System.Text.Json;

namespace JOS.SystemTextJsonPolymorphism
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
