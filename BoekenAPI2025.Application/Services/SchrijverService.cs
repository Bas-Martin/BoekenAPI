using BoekenAPI2025.Application.Interfaces;
using BoekenAPI2025.Shared.DTO.Schrijvers;
using System.Threading.Tasks;

namespace BoekenAPI2025.Application.Services;

public class SchrijverService : ISchrijverService
{
    private readonly ISchrijverRepository schrijverRepository;
    public SchrijverService(ISchrijverRepository schrijverRepository)
    {
        this.schrijverRepository = schrijverRepository;
    }

    public async Task<IEnumerable<SchrijverItem>> GeefAlleSchrijversAsync()
    {
        return await schrijverRepository.GeefAlleSchrijversAsync();
    }

    public async Task<SchrijverDTO?> GeefSchrijverByIdAsync(int id)
    {
        return await schrijverRepository.GeefSchrijverByIdAsync(id);
    }

    public async Task<int> MaakSchrijverAsync(CreateSchrijver schrijver)
    {
        return await schrijverRepository.MaakSchrijverAsync(schrijver);
    }

    public async Task<IEnumerable<SchrijverItem>> ZoekSchrijversAsync(string naam)
    {
        return await schrijverRepository.ZoekSchrijversAsync(naam);
    }
}
