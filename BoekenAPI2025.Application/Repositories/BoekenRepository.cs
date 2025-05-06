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

    public IEnumerable<BoekListItem> GeefAlleBoeken()
    {
        return boeken2025Context
            .Boeken
            .Select(static b => new BoekListItem
            {
                ID = b.Id,
                Titel = b.Titel,
                Schrijver = b.Schrijver.Naam
            }).ToList();
    }

    public IEnumerable<BoekListItem> ZoekBoeken(string titel)
    {
        return boeken2025Context
            .Boeken
            .Where(b => b.Titel.ToLower().Contains(titel.ToLower()))
            .Select(b => new BoekListItem()
            {
                ID = b.Id,
                Titel = b.Titel,
                Schrijver = b.Schrijver.Naam
            }).ToList();
    }

    public FullBoek? GeefBoek(int id)
    {
        Boek? boek = boeken2025Context.Boeken.Include(b => b.Schrijver).SingleOrDefault(n => n.Id == id);
        return MapBoek(boek);
    }

    public int CreateBoek(CreateBoek boek)
    {
        if (!boeken2025Context.Schrijvers.Any(b => b.Id == boek.SchrijverId))
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

        boeken2025Context.Boeken.Add(boekEnt);

        boeken2025Context.SaveChanges();
        return boekEnt.Id;
    }

    public void UpdateBoek(int id, UpdateBoek boek)
    {
        if (id != boek.Id)
        {
            throw new ValidationException("Ids are not corresponding");
        }

        if (!boeken2025Context.Schrijvers.Any(n => n.Id == boek.SchrijverId))
        {
            throw new Exception("Not a correct SchrijverId");
        }

        Boek? boekEnt = boeken2025Context.Boeken.SingleOrDefault(n => n.Id == id);

        if (boekEnt == null)
        {
            throw new Exception("No Boek found");
        }
        MapBoek(boekEnt, boek);

        boeken2025Context.SaveChanges();
    }

    public void DeleteBoek(int id)
    {
        var boek = boeken2025Context.Boeken.Find(id);
        if (boek == null)
            throw new Exception("No Boek found");
        boeken2025Context.Boeken.Remove(boek);
        boeken2025Context.SaveChanges();
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
