using Microsoft.AspNetCore.Mvc;
using PokeApi.Models;
using PokeApp.Services;
using ClosedXML.Excel;
using System.IO;
using System.Linq;

namespace PokeApp.Controllers
{
    public class PokemonController : Controller
    {
        private readonly IPokemonService _pokemonService;
        private const int PageSize = 9;

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        public async Task<IActionResult> Index(string nombreFiltro = "", string especieFiltro = "", int page = 1)
        {
            var especies = await _pokemonService.GetSpeciesAsync();
            var pokemones = await _pokemonService.GetPokemonListAsync();

            if (!string.IsNullOrWhiteSpace(nombreFiltro))
            {
                pokemones = pokemones
                    .Where(p => p.Name.Contains(nombreFiltro, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            var totalItems = pokemones.Count;
            var totalPages = (int)Math.Ceiling((double)totalItems / PageSize);

            var pagedPokemons = pokemones
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            var model = new PokemonFilterViewModel
            {
                NombreFiltro = nombreFiltro,
                EspecieFiltro = especieFiltro,
                Especies = especies,
                Pokemones = pagedPokemons,
                PaginaActual = page,
                TotalPaginas = totalPages
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ExportarExcel(string nombreFiltro = "", string especieFiltro = "")
        {
            var pokemones = await _pokemonService.GetPokemonListAsync();

            if (!string.IsNullOrWhiteSpace(nombreFiltro))
            {
                pokemones = pokemones
                    .Where(p => p.Name.Contains(nombreFiltro, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

          
            // if (!string.IsNullOrWhiteSpace(especieFiltro))
            // {
            //     pokemones = pokemones
            //         .Where(p => p.SpeciesName == especieFiltro)
            //         .ToList();
            // }

            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Pokemons");

            worksheet.Cell(1, 1).Value = "Nombre";
            worksheet.Cell(1, 2).Value = "Imagen URL";

            for (int i = 0; i < pokemones.Count; i++)
            {
                worksheet.Cell(i + 2, 1).Value = pokemones[i].Name;
                worksheet.Cell(i + 2, 2).Value = pokemones[i].ImageUrl;
            }

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            stream.Position = 0;

            return File(stream.ToArray(),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "Pokemons.xlsx");
        }
    }
}
