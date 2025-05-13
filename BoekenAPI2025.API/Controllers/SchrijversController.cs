using BoekenAPI2025.Application.Interfaces;
using BoekenAPI2025.Shared.DTO.Schrijvers;
using Microsoft.AspNetCore.Mvc;

namespace BoekenAPI2025.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchrijversController : ControllerBase
    {
        private readonly ISchrijverService schrijverService;

        public SchrijversController(ISchrijverService schrijverService)
        {
            this.schrijverService = schrijverService;
        }

        [HttpGet]
        public async Task<IActionResult> GeefSchrijvers()
        {
            return Ok(await schrijverService.GeefAlleSchrijversAsync());
        }
        [HttpGet("search/{naam}")]
        public async Task<IActionResult> ZoekSchrijvers(string naam)
        {
            return Ok(await schrijverService.ZoekSchrijversAsync(naam));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GeefSchrijver(int id)
        {
            var retVal = await schrijverService.GeefSchrijverByIdAsync(id);
            return retVal != null ? Ok(retVal) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> MaakSchrijver(CreateSchrijver schrijver)
        {
            return Ok(await schrijverService.MaakSchrijverAsync(schrijver));
        }
    }
}
