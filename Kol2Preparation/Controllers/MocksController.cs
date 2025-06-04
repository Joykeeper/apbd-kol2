using Kol2Preparation.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kol2Preparation.Controllers;

// remember to create it as scaffolded item

[Route("api/[controller]")]
[ApiController]
public class MocksController : ControllerBase
{
    private  readonly IDbService _dbService;

    public MocksController(IDbService db)
    {
        _dbService = db;
    }
    
    
    // [HttpGet("{id}")]
    // public async Task<IActionResult> GetPatientInfo([FromRoute] int id)
    // {
    //     try
    //     {
    //         var patient = await _dbService.GetPatientData(id);
    //         return Ok(patient);
    //     }
    //     catch (NotFoundException e)
    //     {
    //         return NotFound(e.Message);
    //     }
    // }
    // [HttpPost]
    // public async Task<IActionResult> AddPrescription([FromBody] PrescriptionDto prescription)
    // {
    //     try
    //     {
    //         await _dbService.AddPrescription(prescription);
    //         return Created();
    //     }
    //     catch (NotFoundException e)
    //     {
    //      return NotFound(e.Message);
    //     }
    //     catch (ConflictException e)
    //     {
    //      return Conflict(e.Message);
    //     }
    //     catch (BadRequestException e)
    //     {
    //      return BadRequest(e.Message);
    //     }
    // }
}