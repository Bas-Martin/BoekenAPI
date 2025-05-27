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

    public async Task<int> CreateBoekAsync(CreateBoek boek)
    {
        return await boekenRepository.CreateBoekAsync(boek);
    }

    public async Task DeleteBoekAsync(int id)
    {
        await boekenRepository.DeleteBoekAsync(id);
    }

    public async Task<IEnumerable<BoekListItem>> GeefAlleBoekenAsync()
    {
        return await boekenRepository.GeefAlleBoekenAsync();
    }

    public async Task<FullBoek?> GeefBoekAsync(int id)
    {
        return await boekenRepository.GeefBoek(id);
    }

    public async Task UpdateBoekAsync(int id, UpdateBoek boek)
    {
        await boekenRepository.UpdateBoekAsync(id, boek);
    }

    public async Task<IEnumerable<BoekListItem>> ZoekBoekenAsync(string titel)
    {
        return await boekenRepository.ZoekBoekenAsync(titel);
    }
}
