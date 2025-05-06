using BoekenAPI2025.Application.DTO.Schrijvers;
using BoekenAPI2025.Domain.Data;
using Microsoft.EntityFrameworkCore;

namespace BoekenAPI2025.API.Repositories
{
    public class SchrijverRepository
    {
        private readonly Boeken2025Context boeken2025Context;

        public SchrijverRepository(Boeken2025Context boeken2025Context)
        {
            this.boeken2025Context = boeken2025Context;
        }

        /// <summary>
        /// Maakt een schrijver aan en geeft de aangemaakte Id terug
        /// </summary>
        /// <param name="schrijver"></param>
        /// <returns>SchrijverID</returns>
        public int MaakSchrijver(CreateSchrijver schrijver)
        {
            Domain.Entities.Schrijver schrijverEntity = new Domain.Entities.Schrijver()
            {
                Naam = schrijver.Naam
            };
            boeken2025Context.Schrijvers.Add(schrijverEntity);
            boeken2025Context.SaveChanges();
            return schrijverEntity.Id;
        }

        /// <summary>
        /// Geeft alle schrijvernamen uit de database met daarbij de id
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SchrijverItem> GeefAlleSchrijvers()
        {
            return boeken2025Context.Schrijvers.Select(
                n => new SchrijverItem()
                {
                    Id = n.Id,
                    Naam = n.Naam
                }
                );
        }

        /// <summary>
        /// Zoekt in een gedeelte van de naam, hoofdletter onafhankelijk
        /// </summary>
        /// <param name="naam"></param>
        /// <returns>Lijst van Schijvers met daarbij behorende Ids</returns>
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

        /// <summary>
        /// Geeft een schrijver inclusief de boeken van deze schrijver
        /// </summary>
        /// <param name="id">SchrijverId</param>
        /// <returns></returns>
        public Schrijver? GeefSchrijverById(int id)
        {
            return MapSchrijver(boeken2025Context.Schrijvers.Include(n => n.Boeken).SingleOrDefault(n => n.Id == id));
        }


        private Schrijver? MapSchrijver(Domain.Entities.Schrijver? schrijver)
        {
            if (schrijver == null)
                return null;

            return new Schrijver()
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
}
