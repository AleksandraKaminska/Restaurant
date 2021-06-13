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
  public class LocalsController : ControllerBase
  {
    private readonly ILocalService _localService;
    
    public LocalsController(ILocalService localService)
    {
      _localService = localService;
    }
    
    // GET api/locals
    [HttpGet]
    public async Task<IActionResult> Get()
    {
      return Ok(await _localService.GetAll());
    }
    
    // GET api/locals/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id) {
      var result = await _localService.GetById(id);
      if (result == null) {
        return NotFound("A local with given id does not exist");
      }
      return Ok(result);
    }
    
    // POST api/locals
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] LocalRequest local)
    {
        try
        {
            if (local == null)
                return BadRequest();

            await _localService.Create(local);
            return Created("Local created successfully", local);
        }
        catch (Exception err)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                err);
        }
    }
    
    // PUT api/locals/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Local local)
    {
      await _localService.Update(id, local);
      return NoContent();
    }
    
    // DELETE api/locals/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      await _localService.Delete(id);
      return NoContent();
    }
  }
}