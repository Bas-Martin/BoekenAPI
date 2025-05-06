using BoekenAPI2025.Application.DTO.Boeken;
using BoekenAPI2025.Application.DTO.Schrijvers;
using System.Net.Http.Json;

namespace BoekenAPI2025.Client
{
    internal class Program
    {
        static string baseUrl = "https://localhost:7190/api";
        static async Task Main(string[] args)
        {
            await PrintBoeken();
            int schrijverId = await MaakSchrijver();
            await MaakBoek(schrijverId);
            //await PrintBoeken();

            Console.WriteLine("*****Done*****");
            Console.ReadLine();

        }

        private static async Task MaakBoek(int schrijverId)
        {
            var newBoek = new CreateBoek
            {
                Titel = "Hoe schrijf ik een API in c#",
                SchrijverId = schrijverId,
                Publicatiejaar = DateTime.Now.Year
            };

            var boekId = await CreateBoekAsync(newBoek);
            Console.WriteLine("------Boek-----");
            Console.WriteLine($"Created Boek with ID: {boekId}");
        }

        private static async Task<int> MaakSchrijver()
        {
            var newSchrijver = new CreateSchrijver
            {
                Naam = "Appi de Schrijver"
            };

            var schrijverId = await CreateSchrijverAsync(newSchrijver);
            Console.WriteLine("------Schrijver-----");
            Console.WriteLine($"Created Schrijver with ID: {schrijverId}");
            return schrijverId;
        }

        private static async Task PrintBoeken()
        {
            var boeken = await GetBoekenAsync();
            Console.WriteLine("------Alle Boeken-----");
            foreach (var boek in boeken)
            {
                Console.WriteLine($"Id: {boek.ID}, Title: {boek.Titel}, Author: {boek.Schrijver}");
            }


        }

        private static async Task<int> CreateSchrijverAsync(CreateSchrijver newSchrijver)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri($"{baseUrl}/Schrijvers"); // Adjust the base address as needed

            var response = await client.PostAsJsonAsync("", newSchrijver);
            response.EnsureSuccessStatusCode();

            var createdSchrijverId = await response.Content.ReadFromJsonAsync<int>();
            return createdSchrijverId;
        }

        private static async Task<int> CreateBoekAsync(CreateBoek newBoek)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri($"{baseUrl}/Boeken"); // Adjust the base address as needed

            var response = await client.PostAsJsonAsync("", newBoek);
            response.EnsureSuccessStatusCode();

            var createdBoekId = await response.Content.ReadFromJsonAsync<int>();
            return createdBoekId;
        }
        private static async Task<IEnumerable<BoekListItem>> GetBoekenAsync()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri($"{baseUrl}/Boeken");

            //Voer de werkelijke Get uit
            var response = await client.GetAsync("");
            if (!response.IsSuccessStatusCode)
                //geef een lege lijst terug(er is iets fout gegaan
                return Enumerable.Empty<BoekListItem>();

            //zet de json om in een lijst van BoekListItem
            var boeken = await response.Content.ReadFromJsonAsync<IEnumerable<BoekListItem>>();
            //geef de boeken terug als die er zijn, anders geef je een lege lijst
            return boeken ?? Enumerable.Empty<BoekListItem>();
        }
    }
}
