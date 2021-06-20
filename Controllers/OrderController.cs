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
  public class OrdersController : ControllerBase
  {
    private readonly IOrderService _orderService;
    
    public OrdersController(IOrderService orderService)
    {
      _orderService = orderService;
    }
    
    // GET api/orders
    [HttpGet]
    public async Task<IActionResult> Get()
    {
      return Ok(await _orderService.GetAll());
    }
    
    // GET api/orders/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id) {
      var result = await _orderService.GetById(id);
      if (result == null) {
        return NotFound("An order with given id does not exist");
      }
      return Ok(result);
    }
    
    // POST api/orders
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] OrderRequest order)
    {
      try
      {
        if (order == null)
          return BadRequest();

        var response = await _orderService.Create(order);
        return Created("Menu item created successfully", response);
      }
      catch (Exception err)
      {
        return StatusCode(StatusCodes.Status500InternalServerError,
          err);
      }
    }
    
    // PUT api/orders/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] OrderRequest order)
    {
      await _orderService.Update(id, order);
      return NoContent();
    }
  }
}