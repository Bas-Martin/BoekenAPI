using BoekenAPI2025.Application.Interfaces;
using BoekenAPI2025.Domain.Data;
using BoekenAPI2025.Domain.Entities;
using BoekenAPI2025.Shared.DTO.Boeken;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BoekenAPI2025.Application.Repositories;

public class BoekenRepository : IBoekenRepository
{
    private readonly Boeken2025Context boeken2025Context;

    public BoekenRepository(Boeken2025Context boeken2025Context)
    {
        this.boeken2025Context = boeken2025Context;
    }

    public async Task<IEnumerable<BoekListItem>> GeefAlleBoekenAsync()
    {
        return await boeken2025Context
            .Boeken
            .Select(static b => new BoekListItem
            {
                ID = b.Id,
                Titel = b.Titel,
                Schrijver = b.Schrijver.Naam
            }).ToListAsync();
    }

    public async Task<IEnumerable<BoekListItem>> ZoekBoekenAsync(string titel)
    {
        return await boeken2025Context
            .Boeken
            .Where(b => b.Titel.Contains(titel, StringComparison.CurrentCultureIgnoreCase))
            .Select(b => new BoekListItem()
            {
                ID = b.Id,
                Titel = b.Titel,
                Schrijver = b.Schrijver.Naam
            }).ToListAsync();
    }

    public async Task<FullBoek?> GeefBoek(int id)
    {
        Boek? boek = await boeken2025Context.Boeken.Include(b => b.Schrijver).SingleOrDefaultAsync(n => n.Id == id);
        return MapBoek(boek);
    }

    public async Task<int> CreateBoekAsync(CreateBoek boek)
    {
        if (!await boeken2025Context.Schrijvers.AnyAsync(b => b.Id == boek.SchrijverId))
        {
            throw new Exception("Not a correct SchrijverId");
        }

        var boekEnt = new Boek
        {
            Titel = boek.Titel,
            AantalBladzijden = boek.AantalBladzijden,
            Publicatiejaar = boek.Publicatiejaar,
            SchrijverId = boek.SchrijverId
        };

        await boeken2025Context.Boeken.AddAsync(boekEnt);

        await boeken2025Context.SaveChangesAsync();
        return boekEnt.Id;
    }

    public async Task UpdateBoekAsync(int id, UpdateBoek boek)
    {
        if (id != boek.Id)
        {
            throw new ValidationException("Ids are not corresponding");
        }

        if (!await boeken2025Context.Schrijvers.AnyAsync(n => n.Id == boek.SchrijverId))
        {
            throw new Exception("Not a correct SchrijverId");
        }

        Boek? boekEnt = await boeken2025Context.Boeken.SingleOrDefaultAsync(n => n.Id == id);

        if (boekEnt == null)
        {
            throw new Exception("No Boek found");
        }
        MapBoek(boekEnt, boek);

        await boeken2025Context.SaveChangesAsync();
    }

    public async Task DeleteBoekAsync(int id)
    {
        var boek = await boeken2025Context.Boeken.FindAsync(id);
        if (boek == null)
            throw new Exception("No Boek found");
        boeken2025Context.Boeken.Remove(boek);
        await boeken2025Context.SaveChangesAsync();
    }

    private static void MapBoek(Boek boekEnt, UpdateBoek boek)
    {
        boekEnt.Publicatiejaar = boek.Publicatiejaar;
        boekEnt.SchrijverId = boek.SchrijverId;
        boekEnt.AantalBladzijden = boek.AantalBladzijden;
        boekEnt.Titel = boek.Titel;
    }

    private static FullBoek? MapBoek(Boek? boek)
    {
        if (boek == null) return null;
        return new FullBoek()
        {
            Id = boek.Id,
            Titel = boek.Titel,
            AantalBladzijden = boek.AantalBladzijden,
            Publicatiejaar = boek.Publicatiejaar,
            SchrijverId = boek.SchrijverId,
            SchrijverNaam = boek.Schrijver.Naam
        };
    }
}
