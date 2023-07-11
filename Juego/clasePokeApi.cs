using System.Text.Json;
using System.Text.Json.Serialization;
namespace clasePokemon
{
    public class Move
    {
        [JsonPropertyName("move")]
        public MoveInfo MoveInfo { get; set; }
    }

    public class MoveInfo
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class MoveType
    {
        [JsonPropertyName("slot")]
        public int Slot { get; set; }

        [JsonPropertyName("type")]
        public TypeInfo TypeInfo { get; set; }
    }

    public class TypeInfo
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }


    public class PokemonApi
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("moves")]
        public List<Move> Moves { get; set; }

        [JsonPropertyName("types")]
        public List<MoveType> Types { get; set; }
    }

}