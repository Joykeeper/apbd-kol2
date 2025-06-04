using Kol2Preparation.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kol2Preparation.Controllers;

// remember to create it as scaffolded item

[Route("api/[controller]")]
[ApiController]
public class PatientsController : ControllerBase
{
    private  readonly IDbService _dbService;

    public PatientsController(IDbService db)
    {
        _dbService = db;
    }
    
    //
    // [HttpGet("{id}")]
    // public async Task<IActionResult> GetPatientInfo([FromRoute] int id)
    // {
    //     try
    //     {
    //         var patient = await _dbService.GetPatientData(id);
    //         return Ok(patient);
    //     }
    //     catch (PatientNotFoundException e)
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
    //         return Ok();
    //     }
    //     catch (PatientNotFoundException exception)
    //     {
    //         return NotFound(exception.Message);
    //     }
    //     catch (DueDateBeforeDateException exception)
    //     {
    //         return BadRequest(exception.Message);
    //     }
    // }
}