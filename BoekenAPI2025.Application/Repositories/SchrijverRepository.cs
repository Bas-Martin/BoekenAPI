using BoekenAPI2025.Application.Interfaces;
using BoekenAPI2025.Domain.Data;
using BoekenAPI2025.Domain.Entities;
using BoekenAPI2025.Shared.DTO.Schrijvers;
using Microsoft.EntityFrameworkCore;

namespace BoekenAPI2025.Application.Repositories;

public class SchrijverRepository(Boeken2025Context boeken2025Context) : ISchrijverRepository
{
    private readonly Boeken2025Context boeken2025Context = boeken2025Context;

    public int MaakSchrijver(CreateSchrijver schrijver)
    {
        var schrijverEntity = new Schrijver()
        {
            Naam = schrijver.Naam
        };
        boeken2025Context.Schrijvers.Add(schrijverEntity);
        boeken2025Context.SaveChanges();
        return schrijverEntity.Id;
    }

    public IEnumerable<SchrijverItem> GeefAlleSchrijvers()
    {
        return boeken2025Context.Schrijvers.Select(
            n => new SchrijverItem()
            {
                Id = n.Id,
                Naam = n.Naam
            });
    }

    public IEnumerable<SchrijverItem> ZoekSchrijvers(string naam)
    {
        return boeken2025Context.Schrijvers.Where(
            n => n.Naam.ToLower().Contains(naam.ToLower()))
            .Select(n => new SchrijverItem()
            {
                Id = n.Id,
                Naam = n.Naam
            });
    }

    public SchrijverDTO? GeefSchrijverById(int id)
    {
        return MapSchrijver(boeken2025Context.Schrijvers.Include(n => n.Boeken).SingleOrDefault(n => n.Id == id));
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
