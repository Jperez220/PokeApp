
namespace PokeApi.Models
{
    public class PokemonFilterViewModel
    {
        public string NombreFiltro { get; set; }
        public string EspecieFiltro { get; set; }
        public List<string> Especies { get; set; } = new();
        public List<PokemonViewModel> Pokemones { get; set; } = new();
        public int PaginaActual { get; set; }
        public int TotalPaginas { get; set; }
    }
}
