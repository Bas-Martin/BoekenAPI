using BoekenAPI2025.Application.Interfaces;
using BoekenAPI2025.Shared.DTO.Schrijvers;

namespace BoekenAPI2025.Application.Services;

public class SchrijverService : ISchrijverService
{
    private readonly ISchrijverRepository schrijverRepository;
    public SchrijverService(ISchrijverRepository schrijverRepository)
    {
        this.schrijverRepository = schrijverRepository;
    }

    public IEnumerable<SchrijverItem> GeefAlleSchrijvers()
    {
        return schrijverRepository.GeefAlleSchrijvers();
    }

    public SchrijverDTO? GeefSchrijverById(int id)
    {
        return schrijverRepository.GeefSchrijverById(id);
    }

    public int MaakSchrijver(CreateSchrijver schrijver)
    {
        return schrijverRepository.MaakSchrijver(schrijver);
    }

    public IEnumerable<SchrijverItem> ZoekSchrijvers(string naam)
    {
        return schrijverRepository.ZoekSchrijvers(naam);
    }
}
