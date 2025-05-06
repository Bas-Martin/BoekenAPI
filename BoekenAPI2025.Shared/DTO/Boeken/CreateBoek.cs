using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BoekenAPI2025.Shared.DTO.Boeken
{
    public class CreateBoek
    {
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
    }
}
