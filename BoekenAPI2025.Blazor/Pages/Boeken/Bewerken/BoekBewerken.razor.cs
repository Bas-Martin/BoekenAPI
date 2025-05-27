using BoekenAPI2025.Shared.DTO.Boeken;
using BoekenAPI2025.Shared.DTO.Schrijvers;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BoekenAPI2025.Blazor.Pages.Boeken.Bewerken;
public partial class BoekBewerken : ComponentBase
{
    [Parameter]
    public int Id { get; set; }

    [Inject]
    private NavigationManager NavigationManager { get; set; }

    [Inject]
    private HttpClient HttpClient { get; set; }

    private UpdateBoek boek;
    private IEnumerable<SchrijverItem> schrijvers = [];

    protected override async Task OnInitializedAsync()
    {
        schrijvers = await HttpClient.GetFromJsonAsync<IEnumerable<SchrijverItem>>("/api/schrijvers");
        var result = await HttpClient.GetFromJsonAsync<FullBoek>($"api/boeken/{Id}");
        boek = new UpdateBoek
        {
            Id = result.Id,
            Titel = result.Titel,
            Publicatiejaar = result.Publicatiejaar,
            AantalBladzijden = result.AantalBladzijden,
            SchrijverId = result.SchrijverId
        };
    }

    private async Task Save()
    {
        var result = await HttpClient.PutAsJsonAsync<UpdateBoek>($"api/boeken/{Id}", boek);
        if (result.IsSuccessStatusCode)
        {
            NavigationManager.NavigateTo("/boeken");
            // Succesmelding tonen
        }
        else
        {
            // Foutmelding tonen
        }
    }

    private async Task Delete()
    {
        var result = await HttpClient.DeleteAsync($"api/boeken/{Id}");
        if (result.IsSuccessStatusCode)
        {
            NavigationManager.NavigateTo("/boeken");
            // Succesmelding tonen
        }
        else
        {
            // Foutmelding tonen
        }
    }

    private void Cancel()
    {
        NavigationManager.NavigateTo("/boeken");
    }
}