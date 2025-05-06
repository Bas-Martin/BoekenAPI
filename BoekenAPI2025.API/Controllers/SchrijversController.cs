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
        public ActionResult<IEnumerable<SchrijverItem>> GeefSchrijvers()
        {
            return Ok(schrijverService.GeefAlleSchrijvers());
        }
        [HttpGet("search/{naam}")]
        public ActionResult<IEnumerable<SchrijverItem>> ZoekSchrijvers(string naam)
        {
            return Ok(schrijverService.ZoekSchrijvers(naam));
        }
        [HttpGet("{id}")]
        public ActionResult<SchrijverDTO> GeefSchrijver(int id)
        {
            var retVal = schrijverService.GeefSchrijverById(id);
            return retVal != null ? Ok(retVal) : NotFound();
        }

        [HttpPost]
        public ActionResult<int> MaakSchrijver(CreateSchrijver schrijver)
        {
            return schrijverService.MaakSchrijver(schrijver);
        }
    }
}
