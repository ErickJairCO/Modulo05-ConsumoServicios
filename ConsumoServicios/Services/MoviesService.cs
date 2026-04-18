using System.Net.Http.Headers;
using System.Text.Json;
using ConsumoServicios.Dtos.Movies;

namespace ConsumoServicios.Services.Movies
{
    public class MoviesService
    {
        private readonly string _apiToken = "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiJkNjVkOTEzNmVhNjljMDhhNzdjMzc4MzFiMWMwNTRjMSIsIm5iZiI6MTc3NDA1MjMwMy43NDU5OTk4LCJzdWIiOiI2OWJkZTNjZmJhNmY5YzhjZTdhNWRlMmMiLCJzY29wZXMiOlsiYXBpX3JlYWQiXSwidmVyc2lvbiI6MX0.GB0B6JAmlaUodWsYJzs1qi5UrYF-RUFzaBQdP4s61eo";

        public async Task<PopularMoviesResponseDto> ObtenerPeliculasPopulares()
        {
            var client = new HttpClient();
            var url = "https://api.themoviedb.org/3/movie/popular";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("accept", "application/json");

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _apiToken);

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var resultado = JsonSerializer.Deserialize<PopularMoviesResponseDto>(content);
                return resultado;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al consumir TMDB: {errorContent}");
            }
        }
        public async Task<PopularMoviesResponseDto> ObtenerPeliculasMejorValoradas()
        {
            return await ConsumirTmdbApi<PopularMoviesResponseDto>("https://api.themoviedb.org/3/movie/top_rated");
        }

        public async Task<UpcomingMoviesResponseDto> ObtenerProximosEstrenos()
        {
            return await ConsumirTmdbApi<UpcomingMoviesResponseDto>("https://api.themoviedb.org/3/movie/upcoming");
        }

        private async Task<T> ConsumirTmdbApi<T>(string url)
        {
            using var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("accept", "application/json");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _apiToken);

            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(content);
            }

            throw new Exception($"Error al consumir TMDB ({url}): {response.ReasonPhrase}");
        }

    }
}