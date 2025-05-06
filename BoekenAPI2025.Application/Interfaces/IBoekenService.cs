using BoekenAPI2025.Shared.DTO.Boeken;

namespace BoekenAPI2025.Application.Interfaces;

public interface IBoekenService
{
    IEnumerable<BoekListItem> GeefAlleBoeken();
    IEnumerable<BoekListItem> ZoekBoeken(string titel);
    FullBoek? GeefBoek(int id);
    int CreateBoek(CreateBoek boek);
    void UpdateBoek(int id, UpdateBoek boek);
    void DeleteBoek(int id);
}
