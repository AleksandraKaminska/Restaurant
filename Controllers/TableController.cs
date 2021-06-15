using System;
using System.Collections.Generic;
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
  public class TablesController : ControllerBase
  {
    private readonly ITableService _tableService;
    
    public TablesController(ITableService tableService)
    {
      _tableService = tableService;
    }
    
    // GET api/tables
    [HttpGet]
    public async Task<IActionResult> Get()
    {
      return Ok(await _tableService.GetAll());
    }
    
    // GET api/tables/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id) {
      var result = await _tableService.GetById(id);
      if (result == null) {
        return NotFound("An table with given id does not exist");
      }
      return Ok(result);
    }
    
    // POST api/tables
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] TableRequest table)
    {
      try
      {
        if (table == null)
          return BadRequest();

        Console.WriteLine(table.Status);
        await _tableService.Create(table);
        return Created("Menu item created successfully", table);
      }
      catch (Exception err)
      {
        return StatusCode(StatusCodes.Status500InternalServerError,
          err);
      }
    }
    
    // PUT api/tables/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] TableRequest table)
    {
      await _tableService.Update(id, table);
      return NoContent();
    }
  }
}