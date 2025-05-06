using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BoekenAPI2025.Application.DTO.Boeken
{
    public class FullBoek
    {
        [Required]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        [JsonPropertyName("titel")]
        public string Titel { get; set; }

        [JsonPropertyName("publicatiejaar")]
        public int Publicatiejaar { get; set; }

        [JsonPropertyName("aantalbladzijden")]
        public int AantalBladzijden { get; set; }

        [JsonPropertyName("schrijverid")]
        public int SchrijverId { get; set; }
        [JsonPropertyName("schrijvernaam")]
        public string SchrijverNaam { get; set; }


    }
}
