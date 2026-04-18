using System.Text.Json.Serialization;

namespace ConsumoServicios.Dtos.Movies
{
    public class MovieDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("original_title")]
        public string OriginalTitle { get; set; }

        [JsonPropertyName("overview")]
        public string Overview { get; set; }

        [JsonPropertyName("release_date")]
        public string ReleaseDate { get; set; }

        [JsonPropertyName("popularity")]
        public double Popularity { get; set; }

        [JsonPropertyName("vote_average")]
        public double VoteAverage { get; set; }

        [JsonPropertyName("poster_path")]
        public string PosterPath { get; set; }

    }

    public class MovieDatesDto
    {
        [JsonPropertyName("maximum")]
        public string Maximum { get; set; }

        [JsonPropertyName("minimum")]
        public string Minimum { get; set; }
    }
}