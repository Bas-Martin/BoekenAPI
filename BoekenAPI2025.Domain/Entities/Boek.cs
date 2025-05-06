namespace BoekenAPI2025.Domain.Entities
{
    public class Boek
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public int Publicatiejaar { get; set; }
        public int AantalBladzijden { get; set; }
        public int SchrijverId { get; set; }
        public virtual Schrijver? Schrijver { get; set; }

    }
}
