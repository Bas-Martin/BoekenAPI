using BoekenAPI2025.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BoekenAPI2025.Domain.Data
{
    public class Boeken2025Context : DbContext
    {
        public Boeken2025Context(DbContextOptions<Boeken2025Context> options) : base(options) { }

        public DbSet<Schrijver> Schrijvers { get; set; }
        public DbSet<Boek> Boeken { get; set; }

        public DbSet<Bibliotheek> Bibliotheken { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Schrijver>().HasData(new Schrijver { Id = 1, Naam = "Mark J. Prijs" });
            modelBuilder.Entity<Schrijver>().HasData(new Schrijver { Id = 2, Naam = "Joseph Albahari" });
            modelBuilder.Entity<Boek>().HasData(new Boek
            {
                Id = 1,
                SchrijverId = 1,
                Titel = "C# 8.0 and .NET Core 3.0",
                Publicatiejaar = 2023,
                AantalBladzijden = 200
            });
            modelBuilder.Entity<Boek>().HasData(new Boek
            {
                Id = 2,
                SchrijverId = 2,
                Titel = "C# 8.0 Pocket-referentie",
                Publicatiejaar = 2023,
                AantalBladzijden = 100
            });
        }
    }
}