using BoekenAPI2025.Application.Interfaces;
using BoekenAPI2025.Shared.DTO.Boeken;

namespace BoekenAPI2025.Application.Services;

public class BoekenService : IBoekenService
{
    private readonly IBoekenRepository boekenRepository;

    public BoekenService(IBoekenRepository boekenRepository)
    {
        this.boekenRepository = boekenRepository;
    }

    public int CreateBoek(CreateBoek boek)
    {
        return boekenRepository.CreateBoek(boek);
    }

    public void DeleteBoek(int id)
    {
        boekenRepository.DeleteBoek(id);
    }

    public IEnumerable<BoekListItem> GeefAlleBoeken()
    {
        return boekenRepository.GeefAlleBoeken();
    }

    public FullBoek? GeefBoek(int id)
    {
        return boekenRepository.GeefBoek(id);
    }

    public void UpdateBoek(int id, UpdateBoek boek)
    {
        boekenRepository.UpdateBoek(id, boek);
    }

    public IEnumerable<BoekListItem> ZoekBoeken(string titel)
    {
        return boekenRepository.ZoekBoeken(titel);
    }
}
