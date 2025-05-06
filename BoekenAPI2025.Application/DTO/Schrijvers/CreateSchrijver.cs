using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BoekenAPI2025.Application.DTO.Schrijvers
{
    public class CreateSchrijver
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        [JsonPropertyName("naam")]
        public string Naam { get; set; }
    }
}
