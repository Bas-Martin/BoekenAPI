using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BoekenAPI2025.Shared.DTO.Schrijvers
{
    public class SchrijverDTO
    {
        [Required]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        [JsonPropertyName("naam")]
        public string Naam { get; set; }

        [JsonPropertyName("boeken")]
        public IEnumerable<SchrijverBoek>? Boeken { get; set; }
    }
    public class SchrijverBoek
    {
        [Required]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        [JsonPropertyName("titel")]
        public string Titel { get; set; }
    }
}
