using System.Text.Json;
using System.Text.Json.Serialization;
namespace claseMoves
{
    public class Language
    {
        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("url")]
        public string url { get; set; }
    }


 
    public class Name
    {
        [JsonPropertyName("language")]
        public Language language { get; set; }

        [JsonPropertyName("name")]
        public string name { get; set; }
    }

    public class MoveApi
    {

        [JsonPropertyName("id")]
        public int id { get; set; }

        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("names")]
        public List<Name> names { get; set; }

        [JsonPropertyName("power")]
        public int power { get; set; }

        [JsonPropertyName("pp")]
        public int pp { get; set; }

        [JsonPropertyName("type")]
        public Type type { get; set; }
    }

    
    public class Type
    {
        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("url")]
        public string url { get; set; }
    }

}