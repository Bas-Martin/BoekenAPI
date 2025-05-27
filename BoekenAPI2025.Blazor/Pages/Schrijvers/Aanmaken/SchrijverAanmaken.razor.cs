using BoekenAPI2025.Shared.DTO.Schrijvers;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BoekenAPI2025.Blazor.Pages.Schrijvers.Aanmaken;

public partial class SchrijverAanmaken : ComponentBase
{
    [Inject]
    private HttpClient HttpClient { get; set; }

    [Inject]
    private NavigationManager NavigationManager { get; set; }

    private CreateSchrijver schrijver = new CreateSchrijver();

    private async Task Submit()
    {
        var result = await HttpClient.PostAsJsonAsync<CreateSchrijver>("/api/schrijvers", schrijver);
        if (result.IsSuccessStatusCode)
        {
            NavigationManager.NavigateTo("/schrijvers");
            // Succesmelding tonen
        }
        else
        {
            // Foutmelding tonen
        }
    }
}
