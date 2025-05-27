using BoekenAPI2025.Shared.DTO.Boeken;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BoekenAPI2025.Blazor.Pages.Boeken.Overzicht;

public partial class BoekenOverzicht : ComponentBase
{
    [Inject]
    private HttpClient HttpClient { get; set; }

    [Inject]
    private NavigationManager NavigationManager { get; set; }

    private IEnumerable<BoekListItem> boeken = [];

    protected override async Task OnInitializedAsync()
    {
        boeken = await HttpClient.GetFromJsonAsync<IEnumerable<BoekListItem>>("api/boeken");
    }

    private void BoekAanmaken()
    {
        NavigationManager.NavigateTo("boeken/aanmaken");
    }

    private void BoekBewerken(int id)
    {
        NavigationManager.NavigateTo($"boeken/bewerken/{id}");
    }
}
