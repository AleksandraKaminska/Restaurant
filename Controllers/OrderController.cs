using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
    private readonly OrderService orderService;
    public OrdersController(OrderService orderService)
    {
      this.orderService = orderService;
    }
    // GET api/orders
    [HttpGet]
    public IEnumerable<Order> Get()
    {
      return orderService.GetAll();
    }
    // GET api/orders/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
      return Ok(orderService.GetById(id));
    }
    // POST api/orders
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Order order)
    {
      return CreatedAtAction("Get", new { id = order.Id }, orderService.Create(order));
    }
    // PUT api/orders/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Order order)
    {
      orderService.Update(id, order);
      return NoContent();
    }
    // DELETE api/orders/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      orderService.Delete(id);
      return NoContent();
    }
    public override NoContentResult NoContent()
    {
      return base.NoContent();
    }
  }
}