using BoekenAPI2025.Application.DTO.Boeken;
using BoekenAPI2025.Domain.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BoekenAPI2025.API.Repositories
{
    public class BoekenRepository
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
                .Select(n => new BoekListItem()
                {
                    ID = n.Id,
                    Titel = n.Titel,
                    Schrijver = n.Schrijver.Naam
                }).ToList();




        }
        public IEnumerable<BoekListItem> ZoekBoeken(string titel)
        {
            return boeken2025Context
                .Boeken
                .Where(n => n.Titel.ToLower().Contains(titel.ToLower()))
                .Select(n => new BoekListItem()
                {
                    ID = n.Id,
                    Titel = n.Titel,
                    Schrijver = n.Schrijver.Naam
                }).ToList();
        }
        public FullBoek? GeefBoek(int id)
        {
            Domain.Entities.Boek? boek = boeken2025Context.Boeken.Include(n => n.Schrijver).SingleOrDefault(n => n.Id == id);
            return MapBoek(boek);
        }

        /// <summary>
        /// Maakt van de DTO boek een nieuw boek aan in de database
        /// </summary>
        /// <param name="boek"></param>
        /// <returns>Geeft de nieuw gemaakte id terug</returns>
        /// <exception cref="Exception">Geeft een exceptie wanneer schrijver niet reeds bestaat</exception>
        public int CreateBoek(CreateBoek boek)
        {
            if (!boeken2025Context.Schrijvers.Any(n => n.Id == boek.SchrijverId))//check of de schrijver bestaat in de database
                throw new Exception("Not a correct SchrijverId");

            //Maak van de ontvangen gegevens een databaseobject
            Domain.Entities.Boek boekEnt = new Domain.Entities.Boek()
            {
                Titel = boek.Titel,
                AantalBladzijden = boek.AantalBladzijden,
                Publicatiejaar = boek.Publicatiejaar,
                SchrijverId = boek.SchrijverId
            };

            //voeg aan database toe
            boeken2025Context.Boeken.Add(boekEnt);

            boeken2025Context.SaveChanges();
            return boekEnt.Id;
        }

        /// <summary>
        /// Update alle gegevens van een boek in de database mbv de DTO UpdateBoek
        /// </summary>
        /// <param name="id">Id van het te updaten boek</param>
        /// <param name="boek"></param>
        /// <exception cref="ValidationException">Word gegenereert wanneer de Id's niet overeenkomen</exception>
        /// <exception cref="Exception">Word gegenereert wanneer het boek niet in de database is gevonden of wanneer de schrijver niet is gevonden</exception>
        public void UpdateBoek(int id, UpdateBoek boek)
        {
            if (id != boek.Id)
                throw new ValidationException("Ids are not corresponding");

            if (!boeken2025Context.Schrijvers.Any(n => n.Id == boek.SchrijverId)) //check of de schrijver bestaat in de database
                throw new Exception("Not a correct SchrijverId");

            //haal boek op
            Domain.Entities.Boek? boekEnt = boeken2025Context.Boeken.SingleOrDefault(n => n.Id == id);

            if (boekEnt == null)
                throw new Exception("No Boek found");
            //update het boek uit de database met de niuwe gegevens
            MapBoek(boekEnt, boek);

            boeken2025Context.SaveChanges();
        }

        /// <summary>
        /// Verwijderd het boek uit de database met de gegevens ID
        /// </summary>
        /// <param name="id">Id van het te verwijderen boek</param>
        /// <exception cref="Exception">Word gegenereert wanneer het boke niet in de database is gevonden</exception>
        public void DeleteBoek(int id)
        {
            var boek = boeken2025Context.Boeken.Find(id);
            if (boek == null)
                throw new Exception("No Boek found");
            boeken2025Context.Boeken.Remove(boek);
            boeken2025Context.SaveChanges();
        }

        private void MapBoek(Domain.Entities.Boek boekEnt, UpdateBoek boek)
        {
            boekEnt.Publicatiejaar = boek.Publicatiejaar;
            boekEnt.SchrijverId = boek.SchrijverId;
            boekEnt.AantalBladzijden = boek.AantalBladzijden;
            boekEnt.Titel = boek.Titel;
        }

        private FullBoek? MapBoek(Domain.Entities.Boek? boek)
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
}
