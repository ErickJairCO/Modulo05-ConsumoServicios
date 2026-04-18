using System.Text.Json.Serialization;

namespace ConsumoServicios.Dtos.Movies
{
    public class PopularMoviesResponseDto
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("results")]
        public List<MovieDto> Results { get; set; }

        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }

        [JsonPropertyName("total_results")]
        public int TotalResults { get; set; }
    }

    public class UpcomingMoviesResponseDto : PopularMoviesResponseDto
    {
        [JsonPropertyName("dates")]
        public MovieDatesDto Dates { get; set; }
    }
}