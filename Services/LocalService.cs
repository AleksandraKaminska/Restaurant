using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.DTOs;
using Restaurant.Models;

namespace Restaurant.Services
{
  public class LocalService : ILocalService
  {
    private readonly ApplicationDbContext _applicationDbContext;

    public LocalService(ApplicationDbContext applicationDbContext)
    {
      _applicationDbContext = applicationDbContext;
    }
    
    public async Task<IEnumerable<Local>> GetAll()
    {
      var result = await _applicationDbContext.Locals.ToListAsync();
      return result;
    }
    
    public async Task<Local> GetById(int id)
    {
      return await _applicationDbContext.Locals.FirstAsync(d => d.Id == id);
    }
    
    public async Task<IEnumerable<MenuItem>> GetMenu(int id)
    {
      var local = await _applicationDbContext.Locals
        .Include(s => s.Menu)
        .ThenInclude(t => t.MenuItems)
        .FirstAsync(d => d.Id == id);
      return local?.Menu?.MenuItems;
    }
    
    public async Task Create(LocalRequest localRequest)
    {
      var menu = new Menu();
      var local = new Local
      {
        Address = localRequest.Address, 
        NrOfTables = localRequest.NrOfTables,
        Menu = menu
      };
      await _applicationDbContext.Locals.AddAsync(local);
      await _applicationDbContext.Menu.AddAsync(menu);
      await _applicationDbContext.SaveChangesAsync();
    }
    
    public async Task Update(int id, Local local)
    {
      Local found = await _applicationDbContext.Locals.FirstAsync(d => d.Id == id);
      found.Address = local.Address;
      found.NrOfTables = local.NrOfTables;
      _applicationDbContext.Update(found);
      await _applicationDbContext.SaveChangesAsync();
    }
    
    public async Task Delete(int id)
    {
      var local = await _applicationDbContext.Locals.FirstAsync(d => d.Id == id);
      _applicationDbContext.Locals.Remove(local);
      await _applicationDbContext.SaveChangesAsync();
    }
  }
}