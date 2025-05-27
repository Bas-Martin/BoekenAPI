using BoekenAPI2025.Application.Interfaces;
using BoekenAPI2025.Blazor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

/* De apiUrl kan je vinden in je API project, de Properties map en dan in de launchSettings.json
 * Op regel 27 staat de 'applicationUrl'. Hiervan wil je de https url hieronder plaatsen als 'apiUrl'. */
var apiUrl = "https://localhost:7190/";
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiUrl) });

await builder.Build().RunAsync();
