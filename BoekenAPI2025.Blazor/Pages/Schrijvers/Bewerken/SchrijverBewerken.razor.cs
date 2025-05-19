using BoekenAPI2025.Shared.DTO.Schrijvers;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BoekenAPI2025.Blazor.Pages.Schrijvers.Bewerken;

public partial class SchrijverBewerken : ComponentBase
{
    [Parameter]
    public int Id { get; set; }

    [Inject]
    private NavigationManager NavigationManager { get; set; }

    [Inject]
    private HttpClient HttpClient { get; set; }

    private SchrijverDTO schrijver;

    protected override async Task OnInitializedAsync()
    {
        schrijver = await HttpClient.GetFromJsonAsync<SchrijverDTO>($"/api/schrijvers/{Id}");
    }

    private void Cancel()
    {
        NavigationManager.NavigateTo("/schrijvers");
    }

    private void GaNaarBoek(int boekId)
    {
        NavigationManager.NavigateTo($"/boeken/bewerken/{boekId}");
    }
}
