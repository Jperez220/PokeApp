using System.Text.Json.Serialization;

namespace PokeApi.Models
{

    public class PokemonViewModel
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}