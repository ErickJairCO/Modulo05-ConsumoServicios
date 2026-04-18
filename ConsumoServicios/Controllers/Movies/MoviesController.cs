using ConsumoServicios.Services.Movies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsumoServicios.Controllers.Movies
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MoviesService _moviesService;

        // Inyección de dependencias del servicio
        public MoviesController(MoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        [HttpGet("Popular")]
        public async Task<IActionResult> GetPopularMovies()
        {
            try
            {
                var popularMovies = await _moviesService.ObtenerPeliculasPopulares();
                return Ok(popularMovies);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Ocurrió un error al obtener las películas", detalle = ex.Message });
            }
        }

        [HttpGet("TopRated")]
        public async Task<IActionResult> GetTopRated()
        {
            try
            {
                var movies = await _moviesService.ObtenerPeliculasMejorValoradas();
                return Ok(movies);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error al obtener mejor valoradas", detalle = ex.Message });
            }
        }

        [HttpGet("Upcoming")]
        public async Task<IActionResult> GetUpcoming()
        {
            try
            {
                var movies = await _moviesService.ObtenerProximosEstrenos();
                return Ok(movies);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error al obtener próximos estrenos", detalle = ex.Message });
            }
        }
    }
}