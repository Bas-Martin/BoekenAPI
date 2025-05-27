using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BoekenAPI2025.Shared.DTO.Schrijvers
{
    public class SchrijverItem
    {
        [Required]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        [JsonPropertyName("naam")]
        public string Naam { get; set; }


    }
}
