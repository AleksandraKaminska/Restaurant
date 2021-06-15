using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.DTOs;
using Restaurant.Models;

namespace Restaurant.Services
{
  public class OrderService : IOrderService
  {
    private readonly ApplicationDbContext _applicationDbContext;

    public OrderService(ApplicationDbContext applicationDbContext)
    {
      _applicationDbContext = applicationDbContext;
    }
    
    public async Task<IEnumerable<Order>> GetAll()
    {
      var result = await _applicationDbContext.Orders.ToListAsync();
      return result;
    }
    
    public async Task<Order> GetById(int id)
    {
      return await _applicationDbContext.Orders.FirstAsync(d => d.Id == id);
    }
    
    public async Task Create(OrderRequest orderRequest)
    {
      var order = new Order
      {
        Status = orderRequest.Status 
      };
      
      await _applicationDbContext.Orders.AddAsync(order);
      await _applicationDbContext.SaveChangesAsync();
    }
    
    public async Task Update(int id, OrderRequest order)
    {
      var found = await _applicationDbContext.Orders.FirstAsync(d => d.Id == id);
      found.Status = order.Status;
      _applicationDbContext.Update(found);
      await _applicationDbContext.SaveChangesAsync();
    }
    
    public async Task Delete(int id)
    {
      var order = await _applicationDbContext.Orders.FirstAsync(d => d.Id == id);
      _applicationDbContext.Orders.Remove(order);
      await _applicationDbContext.SaveChangesAsync();
    }
  }
}