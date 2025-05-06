namespace BoekenAPI2025.Domain.Entities
{
    public class Schrijver
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public virtual ICollection<Boek>? Boeken { get; set; }
    }
}
