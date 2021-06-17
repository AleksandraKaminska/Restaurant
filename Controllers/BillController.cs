using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.DTOs;
using Restaurant.Models;
using Restaurant.Services;

namespace Restaurant.Controllers
{
  [Produces("application/json")]
  [Route("api/[controller]")]
  [ApiController]
  // [EnableCors("ReactPolicy")]
  public class BillsController : ControllerBase
  {
    private readonly IBillService _billService;
    
    public BillsController(IBillService billService)
    {
      _billService = billService;
    }
    
    // GET api/bills
    [HttpGet]
    public async Task<IActionResult> Get()
    {
      return Ok(await _billService.GetAll());
    }
    
    // GET api/bills/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id) {
      var result = await _billService.GetById(id);
      if (result == null) {
        return NotFound("A bill with given id does not exist");
      }
      return Ok(result);
    }
    
    // POST api/bills
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] BillRequest bill)
    {
        try
        {
            if (bill == null)
                return BadRequest();

            await _billService.Create(bill);
            return Created("Bill created successfully", bill);
        }
        catch (Exception err)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                err);
        }
    }
  }
}