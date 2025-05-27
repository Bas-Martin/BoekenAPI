using BoekenAPI2025.Shared.DTO.Boeken;
using BoekenAPI2025.Shared.DTO.Schrijvers;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BoekenAPI2025.Blazor.Pages.Schrijvers.Overzicht;

public partial class SchrijversOverzicht : ComponentBase
{
    [Inject]
    private HttpClient HttpClient { get; set; }

    [Inject]
    private NavigationManager NavigationManager { get; set; }

    private IEnumerable<SchrijverItem> schrijvers = [];

    protected override async Task OnInitializedAsync()
    {
        schrijvers = await HttpClient.GetFromJsonAsync<IEnumerable<SchrijverItem>>("api/schrijvers");
    }

    private void SchrijverAanmaken()
    {
        NavigationManager.NavigateTo("schrijvers/aanmaken");
    }

    private void SchrijverBewerken(int id)
    {
        NavigationManager.NavigateTo($"schrijvers/bewerken/{id}");
    }
}
