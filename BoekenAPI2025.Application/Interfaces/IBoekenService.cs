using BoekenAPI2025.Shared.DTO.Boeken;

namespace BoekenAPI2025.Application.Interfaces;

public interface IBoekenService
{
    Task<IEnumerable<BoekListItem>> GeefAlleBoekenAsync();
    Task<IEnumerable<BoekListItem>> ZoekBoekenAsync(string titel);
    Task<FullBoek?> GeefBoekAsync(int id);
    Task<int> CreateBoekAsync(CreateBoek boek);
    Task UpdateBoekAsync(int id, UpdateBoek boek);
    Task DeleteBoekAsync(int id);
}
