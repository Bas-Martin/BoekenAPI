using BoekenAPI2025.Shared.DTO.Boeken;
using System.ComponentModel;
using System.Net.Http.Json;

namespace WinFormsApp;

public partial class BoekenOverzicht : Form
{
    public BoekenOverzicht()
    {
        InitializeComponent();
        LaadBoeken();
    }

    private async Task LaadBoeken()
    {
        var apiUrl = "https://localhost:7190/";
        var httpClient = new HttpClient { BaseAddress = new Uri(apiUrl) };
        var boeken = await httpClient.GetFromJsonAsync<List<BoekListItem>>("api/boeken");
        boekenTabel.DataSource = new BindingList<BoekListItem>(boeken ?? []);
    }

    private void ExportToolStripMenuItem_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Exporteren van boeken is momenteel nog niet mogelijk.");
    }
}
