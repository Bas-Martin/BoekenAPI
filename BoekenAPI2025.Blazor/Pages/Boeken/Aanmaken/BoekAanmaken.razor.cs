using BoekenAPI2025.Shared.DTO.Boeken;
using BoekenAPI2025.Shared.DTO.Schrijvers;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BoekenAPI2025.Blazor.Pages.Boeken.Aanmaken;

public partial class BoekAanmaken : ComponentBase
{
    [Inject]
    private HttpClient HttpClient { get; set; }

    [Inject]
    private NavigationManager NavigationManager { get; set; }

    private CreateBoek boek = new CreateBoek();
    private IEnumerable<SchrijverItem> schrijvers = [];

    protected override async Task OnInitializedAsync()
    {
        schrijvers = await HttpClient.GetFromJsonAsync<IEnumerable<SchrijverItem>>("/api/schrijvers");
    }

    private async Task Submit()
    {
        var result = await HttpClient.PostAsJsonAsync<CreateBoek>("/api/boeken", boek);
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
}
