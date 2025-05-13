using BoekenAPI2025.Application.Interfaces;
using BoekenAPI2025.Domain.Data;
using BoekenAPI2025.Domain.Entities;
using BoekenAPI2025.Shared.DTO.Schrijvers;
using Microsoft.EntityFrameworkCore;

namespace BoekenAPI2025.Application.Repositories;

public class SchrijverRepository(Boeken2025Context boeken2025Context) : ISchrijverRepository
{
    private readonly Boeken2025Context boeken2025Context = boeken2025Context;

    public async Task<int> MaakSchrijverAsync(CreateSchrijver schrijver)
    {
        var schrijverEntity = new Schrijver()
        {
            Naam = schrijver.Naam
        };
        await boeken2025Context.Schrijvers.AddAsync(schrijverEntity);
        await boeken2025Context.SaveChangesAsync();
        return schrijverEntity.Id;
    }

    public async Task<IEnumerable<SchrijverItem>> GeefAlleSchrijversAsync()
    {
        return await boeken2025Context.Schrijvers.Select(
            n => new SchrijverItem()
            {
                Id = n.Id,
                Naam = n.Naam
            }).ToListAsync();
    }

    public async Task<IEnumerable<SchrijverItem>> ZoekSchrijversAsync(string naam)
    {
        return await boeken2025Context.Schrijvers.Where(
            n => n.Naam.Contains(naam, StringComparison.InvariantCultureIgnoreCase))
            .Select(n => new SchrijverItem()
            {
                Id = n.Id,
                Naam = n.Naam
            }).ToListAsync();
    }

    public async Task<SchrijverDTO?> GeefSchrijverByIdAsync(int id)
    {
        return MapSchrijver(await boeken2025Context.Schrijvers.Include(n => n.Boeken).SingleOrDefaultAsync(n => n.Id == id));
    }

    private SchrijverDTO? MapSchrijver(Schrijver? schrijver)
    {
        if (schrijver == null)
            return null;

        return new SchrijverDTO()
        {
            Id = schrijver.Id,
            Naam = schrijver.Naam,
            Boeken = schrijver.Boeken.Select(n => new SchrijverBoek()
            {
                Id = n.Id,
                Titel = n.Titel
            })
        };
    }
}
