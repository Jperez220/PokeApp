
using PokeApi.Models;

namespace PokeApp.Services
{
    public interface IPokemonService
    {
        Task<List<PokemonViewModel>> GetPokemonListAsync();
        Task<List<string>> GetSpeciesAsync();

    }

    public class PokemonService : IPokemonService
    {
        private readonly HttpClient _httpClient;

        public PokemonService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<PokemonViewModel>> GetPokemonListAsync()
        {
            var list = new List<PokemonViewModel>();
            var response = await _httpClient.GetAsync("https://pokeapi.co/api/v2/pokemon?limit=20");

            if (!response.IsSuccessStatusCode) return list;

            var data = await response.Content.ReadFromJsonAsync<PokeApiListResponse>();

            foreach (var item in data.Results)
            {
                var detailResponse = await _httpClient.GetAsync(item.Url);
                if (!detailResponse.IsSuccessStatusCode) continue;

                var detail = await detailResponse.Content.ReadFromJsonAsync<PokeApiPokemonDetail>();

                list.Add(new PokemonViewModel
                {
                    Name = item.Name,
                    ImageUrl = detail.Sprites.FrontDefault
                });
            }

            return list;
        }

        public async Task<List<string>> GetSpeciesAsync()
        {
            var especies = new List<string>();
            var response = await _httpClient.GetAsync("https://pokeapi.co/api/v2/pokemon-species?limit=100");

            if (!response.IsSuccessStatusCode) return especies;

            var data = await response.Content.ReadFromJsonAsync<PokeApiListResponse>();

            especies = data.Results.Select(e => e.Name).Distinct().OrderBy(n => n).ToList();
            return especies;
        }

    }
}
