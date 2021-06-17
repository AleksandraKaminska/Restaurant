using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.DTOs;
using Restaurant.Models;

namespace Restaurant.Services
{
  public class OrderMenuItemService : IOrderMenuItemService
  {
    private readonly ApplicationDbContext _applicationDbContext;

    public OrderMenuItemService(ApplicationDbContext applicationDbContext)
    {
      _applicationDbContext = applicationDbContext;
    }
    
    public async Task<IEnumerable<OrderMenuItem>> GetAll()
    { 
      return await _applicationDbContext.OrderMenuItems
        .Include(o => o.MenuItem)
        .Include(o => o.Order)
        .ToListAsync();
    }
    
    public async Task<OrderMenuItem> GetById(int id)
    {
      return await _applicationDbContext.OrderMenuItems
        .Include(o => o.MenuItem)
        .Include(o => o.Order)
        .FirstAsync(d => d.Id == id);
    }
    
    public async Task<OrderMenuItem> Create(OrderMenuItemRequest orderMenuItemRequest)
    {
      var order = await _applicationDbContext.Orders
        .FirstAsync(d => d.Id == orderMenuItemRequest.OrderId);
      
      var menuItem = await _applicationDbContext.MenuItems
        .FirstOrDefaultAsync(d => d.Id == orderMenuItemRequest.MenuItemId);
      
      var orderMenuItem = new OrderMenuItem
      {
        Quantity = orderMenuItemRequest.Quantity,
        Order = order,
        MenuItem = menuItem
      };
      
      await _applicationDbContext.OrderMenuItems.AddAsync(orderMenuItem);
      await _applicationDbContext.SaveChangesAsync();

      return orderMenuItem;
    }
    
    public async Task Update(int id, OrderMenuItem orderMenuItem)
    {
      var found = await _applicationDbContext.OrderMenuItems.FirstAsync(d => d.Id == id);
      found.Quantity = orderMenuItem.Quantity;
      _applicationDbContext.Update(found);
      await _applicationDbContext.SaveChangesAsync();
    }
    
    public async Task Delete(int id)
    {
      var orderMenuItem = await _applicationDbContext.OrderMenuItems.FirstAsync(d => d.Id == id);
      _applicationDbContext.OrderMenuItems.Remove(orderMenuItem);
      await _applicationDbContext.SaveChangesAsync();
    }
  }
}