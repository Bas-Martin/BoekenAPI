using BoekenAPI2025.Application.Interfaces;
using BoekenAPI2025.Shared.DTO.Boeken;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BoekenAPI2025.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BoekenController : ControllerBase
{
    private readonly IBoekenService boekenService;

    public BoekenController(IBoekenService boekenService)
    {
        this.boekenService = boekenService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<BoekListItem>> GeefBoeken()
    {
        return Ok(boekenService.GeefAlleBoeken());
    }

    [HttpGet("search/{titel}")]
    public ActionResult<IEnumerable<BoekListItem>> ZoekBoeken(string titel)
    {
        return Ok(boekenService.ZoekBoeken(titel));
    }
    [HttpGet("{id}")]
    public ActionResult<FullBoek> GeefBoek(int id)
    {
        FullBoek? retVal = boekenService.GeefBoek(id);
        return retVal != null ? Ok(retVal) : NotFound();
    }

    [HttpPost]
    public ActionResult<int> MaakBoek(CreateBoek boek)
    {
        try
        {
            var id = boekenService.CreateBoek(boek);

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
            boekenService.UpdateBoek(id, boek);
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
            boekenService.DeleteBoek(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
