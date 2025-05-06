using BoekenAPI2025.API.Repositories;
using BoekenAPI2025.Application.DTO.Schrijvers;
using Microsoft.AspNetCore.Mvc;

namespace BoekenAPI2025.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchrijversController : ControllerBase
    {
        private readonly SchrijverRepository schrijverRepository;

        public SchrijversController(SchrijverRepository schrijverRepository)
        {
            this.schrijverRepository = schrijverRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SchrijverItem>> GeefSchrijvers()
        {
            return Ok(schrijverRepository.GeefAlleSchrijvers());
        }
        [HttpGet("search/{naam}")]
        public ActionResult<IEnumerable<SchrijverItem>> ZoekSchrijvers(string naam)
        {
            return Ok(schrijverRepository.ZoekSchrijvers(naam));
        }
        [HttpGet("{id}")]
        public ActionResult<Schrijver> GeefSchrijver(int id)
        {
            var retVal = schrijverRepository.GeefSchrijverById(id);
            return retVal != null ? Ok(retVal) : NotFound();
        }

        [HttpPost]
        public ActionResult<int> MaakSchrijver(CreateSchrijver schrijver)
        {
            return schrijverRepository.MaakSchrijver(schrijver);
        }
    }
}
