using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.DTOs;
using Restaurant.Models;

namespace Restaurant.Services
{
  public class MenuItemService : IMenuItemService
  {
    private readonly ApplicationDbContext _applicationDbContext;

    public MenuItemService(ApplicationDbContext applicationDbContext)
    {
      _applicationDbContext = applicationDbContext;
    }
    
    public async Task<IEnumerable<MenuItem>> GetAll()
    {
      var result = await _applicationDbContext.MenuItems.ToListAsync();
      return result;
    }
    
    public async Task<MenuItem> GetById(int id)
    {
      return await _applicationDbContext.MenuItems.FirstAsync(d => d.Id == id);
    }
    
    public async Task Create(MenuItemRequest menuItemRequest)
    {
      var local = await _applicationDbContext.Locals
        .Include(s => s.Menu)
        .FirstAsync(d => d.Id == menuItemRequest.LocalId);
      
      var menuItem = new MenuItem
      {
        Title = menuItemRequest.Title, 
        Description = menuItemRequest.Description,
        Price = menuItemRequest.Price,
        Category = menuItemRequest.Category,
        Menu = local.Menu
      };
      
      await _applicationDbContext.MenuItems.AddAsync(menuItem);
      await _applicationDbContext.SaveChangesAsync();
    }
    
    public async Task Update(int id, MenuItem menuItem)
    {
      MenuItem found = await _applicationDbContext.MenuItems.FirstAsync(d => d.Id == id);
      found.Title = menuItem.Title;
      found.Description = menuItem.Description;
      found.Price = menuItem.Price;
      _applicationDbContext.Update(found);
      await _applicationDbContext.SaveChangesAsync();
    }
    
    public async Task Delete(int id)
    {
      var menuItem = await _applicationDbContext.MenuItems.FirstAsync(d => d.Id == id);
      _applicationDbContext.MenuItems.Remove(menuItem);
      await _applicationDbContext.SaveChangesAsync();
    }
  }
}