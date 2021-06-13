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
  [Route("api/menu-items")]
  [ApiController]
  // [EnableCors("ReactPolicy")]
  public class MenuItemsController : ControllerBase
  {
    private readonly IMenuItemService _menuItemService;
    
    public MenuItemsController(IMenuItemService menuItemService)
    {
      _menuItemService = menuItemService;
    }
    
    // GET api/menu-items
    [HttpGet]
    public async Task<IActionResult> Get()
    {
      return Ok(await _menuItemService.GetAll());
    }
    
    // GET api/menu-items/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id) {
      var result = await _menuItemService.GetById(id);
      if (result == null) {
        return NotFound("A menu item with given id does not exist");
      }
      return Ok(result);
    }
    
    // POST api/menu-items
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] MenuItemRequest menuItem)
    {
        try
        {
            if (menuItem == null)
                return BadRequest();

            await _menuItemService.Create(menuItem);
            return Created("Menu item created successfully", menuItem);
        }
        catch (Exception err)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                err);
        }
    }
    
    // PUT api/menu-items/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] MenuItem menuItem)
    {
      await _menuItemService.Update(id, menuItem);
      return NoContent();
    }
    
    // DELETE api/menu-items/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      await _menuItemService.Delete(id);
      return NoContent();
    }
  }
}