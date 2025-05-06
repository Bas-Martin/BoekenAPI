using BoekenAPI2025.Shared.DTO.Schrijvers;

namespace BoekenAPI2025.Application.Interfaces;

public interface ISchrijverService
{
    int MaakSchrijver(CreateSchrijver schrijver);
    IEnumerable<SchrijverItem> GeefAlleSchrijvers();
    IEnumerable<SchrijverItem> ZoekSchrijvers(string naam);
    SchrijverDTO? GeefSchrijverById(int id);
}
