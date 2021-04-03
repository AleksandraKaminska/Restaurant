using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.Services;

namespace Restaurant.Controllers
{
  [Produces("application/json")]
  [Route("api/[controller]")]
  [ApiController]
  [EnableCors("ReactPolicy")]
  public class LocalController : ControllerBase
  {
    private readonly LocalService localService;
    public LocalController(LocalService localService)
    {
      this.localService = localService;
    }

    // GET api/locals
    [HttpGet]
    public IEnumerable<Local> Get()
    {
      return localService.GetAll();
    }

    // GET api/locals/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
      return Ok(localService.GetById(id));
    }

    // POST api/locals
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Local local)
    {
      return CreatedAtAction("Get", new { id = local.Id }, localService.Create(local));
    }

    // PUT api/locals/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Local local)
    {
      localService.Update(id, local);
      return NoContent();
    }

    // DELETE api/locals/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      localService.Delete(id);
      return NoContent();
    }

    public override NoContentResult NoContent()
    {
      return base.NoContent();
    }
  }
}