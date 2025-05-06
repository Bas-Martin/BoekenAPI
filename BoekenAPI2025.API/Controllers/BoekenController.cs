using BoekenAPI2025.API.Repositories;
using BoekenAPI2025.Application.DTO.Boeken;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BoekenAPI2025.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoekenController : ControllerBase
    {
        private readonly BoekenRepository boekenRepository;

        public BoekenController(BoekenRepository boekenRepository)
        {
            this.boekenRepository = boekenRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BoekListItem>> GeefBoeken()
        {
            return Ok(boekenRepository.GeefAlleBoeken());
        }
        [HttpGet("search/{titel}")]
        public ActionResult<IEnumerable<BoekListItem>> ZoekBoeken(string titel)
        {
            return Ok(boekenRepository.ZoekBoeken(titel));
        }
        [HttpGet("{id}")]
        public ActionResult<FullBoek> GeefBoek(int id)
        {
            FullBoek? retVal = boekenRepository.GeefBoek(id);
            return retVal != null ? Ok(retVal) : NotFound();
        }

        [HttpPost]
        public ActionResult<int> MaakBoek(CreateBoek boek)
        {
            try
            {
                var id = boekenRepository.CreateBoek(boek);

                return id;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public ActionResult UpdateBoek(int id, UpdateBoek boek)
        {
            try
            {
                boekenRepository.UpdateBoek(id, boek);
                return Ok();
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("id")]
        public ActionResult DeleteBoek(int id)
        {
            try
            {
                boekenRepository.DeleteBoek(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
