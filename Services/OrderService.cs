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
      return await _applicationDbContext.Orders
        .Include(s => s.Table)
        .ThenInclude(t => t.Local)
        .ToListAsync();
    }
    
    public async Task<Order> GetById(int id)
    {
      return await _applicationDbContext.Orders
        .Include(s => s.Table)
        .ThenInclude(t => t.Local)
        .FirstAsync(d => d.Id == id);
    }
    
    public async Task<Order> Create(OrderRequest orderRequest)
    {
      var table = await _applicationDbContext.Tables.FirstOrDefaultAsync(d => d.Id == orderRequest.TableId);
      table.Status = Table.StatusType.Occupied;

      var order = new Order
      {
        Status = orderRequest.Status, 
        Table = table
      };
      
      await _applicationDbContext.Orders.AddAsync(order);
      await _applicationDbContext.SaveChangesAsync();
      return order;
    }
    
    public async Task Update(int id, OrderRequest order)
    {
      var table = await _applicationDbContext.Tables.FirstOrDefaultAsync(d => d.Id == order.TableId);

      var found = await _applicationDbContext.Orders.FirstAsync(d => d.Id == id);
      found.Status = order.Status;
      found.Table = table;
      _applicationDbContext.Update(found);
      await _applicationDbContext.SaveChangesAsync();
    }
  }
}