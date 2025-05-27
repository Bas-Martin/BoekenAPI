using BoekenAPI2025.Shared.DTO.Boeken;

namespace BoekenAPI2025.Application.Interfaces;

public interface IBoekenRepository
{
    Task<IEnumerable<BoekListItem>> GeefAlleBoekenAsync();
    Task<IEnumerable<BoekListItem>> ZoekBoekenAsync(string titel);
    Task<FullBoek?> GeefBoek(int id);
    Task<int> CreateBoekAsync(CreateBoek boek);
    Task UpdateBoekAsync(int id, UpdateBoek boek);
    Task DeleteBoekAsync(int id);
}
