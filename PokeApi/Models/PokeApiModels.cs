
using System.Text.Json.Serialization;

namespace PokeApi.Models
{

    public class PokeApiListResponse
    {
        public List<PokeApiResult> Results { get; set; }
    }

    public class PokeApiResult
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class PokeApiPokemonDetail
    {
        public PokeApiSprites Sprites { get; set; }
    }

    public class PokeApiSprites
    {
        [JsonPropertyName("front_default")]
        public string FrontDefault { get; set; }
    }
}
