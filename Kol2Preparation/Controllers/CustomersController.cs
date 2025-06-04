using Kol2Preparation.DTOs;
using Kol2Preparation.Exceptions;
using Kol2Preparation.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Kol2Preparation.Controllers;


[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private  readonly IDbService _dbService;

    public CustomersController(IDbService db)
    {
        _dbService = db;
    }
    
    
    [HttpGet("{id}/purchases")]
    public async Task<IActionResult> GetCustomerAndPurchases([FromRoute] int id)
    {
        try
        {
            var patient = await _dbService.GetCustomerData(id);
            return Ok(patient);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    [HttpPost]
    public async Task<IActionResult> AddCustomer([FromBody] DataDto customer)
    {
        try
        {
            await _dbService.AddCustomerData(customer);
            return Created();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (ConflictException e)
        {
            return Conflict(e.Message);
        }
        catch (BadRequestException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest("Data not valid");
        }
    }
}