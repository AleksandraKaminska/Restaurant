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
  [Route("api/order-menu-items")]
  [ApiController]
  // [EnableCors("ReactPolicy")]
  public class OrderMenuItemsController : ControllerBase
  {
    private readonly IOrderMenuItemService _orderMenuItemService;
    
    public OrderMenuItemsController(IOrderMenuItemService orderMenuItemService)
    {
      _orderMenuItemService = orderMenuItemService;
    }
    
    // GET api/order-menu-items
    [HttpGet]
    public async Task<IActionResult> Get()
    {
      return Ok(await _orderMenuItemService.GetAll());
    }
    
    // GET api/order-menu-items/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id) {
      var result = await _orderMenuItemService.GetById(id);
      if (result == null) {
        return NotFound("An order menu item with given id does not exist");
      }
      return Ok(result);
    }
    
    // POST api/order-menu-items
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] OrderMenuItemRequest orderMenuItem)
    {
        try
        {
            if (orderMenuItem == null)
                return BadRequest();

            var response = await _orderMenuItemService.Create(orderMenuItem);
            return Created("Order menu item created successfully", response);
        }
        catch (Exception err)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                err);
        }
    }
    
    // PUT api/order-menu-items/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] OrderMenuItem orderMenuItem)
    {
      await _orderMenuItemService.Update(id, orderMenuItem);
      return NoContent();
    }
    
    // DELETE api/order-menu-items/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      await _orderMenuItemService.Delete(id);
      return NoContent();
    }
  }
}