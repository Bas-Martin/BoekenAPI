using BoekenAPI2025.Shared.DTO.Schrijvers;

namespace BoekenAPI2025.Application.Interfaces;

public interface ISchrijverService
{
    Task<int> MaakSchrijverAsync(CreateSchrijver schrijver);
    Task<IEnumerable<SchrijverItem>> GeefAlleSchrijversAsync();
    Task<IEnumerable<SchrijverItem>> ZoekSchrijversAsync(string naam);
    Task<SchrijverDTO?> GeefSchrijverByIdAsync(int id);
}
