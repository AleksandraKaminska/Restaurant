using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.DTOs;
using Restaurant.Models;

namespace Restaurant.Services
{
  public class TableService : ITableService
  {
    private readonly ApplicationDbContext _applicationDbContext;

    public TableService(ApplicationDbContext applicationDbContext)
    {
      _applicationDbContext = applicationDbContext;
    }
    
    public async Task<IEnumerable<Table>> GetAll()
    {
      var result = await _applicationDbContext.Tables.ToListAsync();
      return result;
    }
    
    public async Task<Table> GetById(int id)
    {
      return await _applicationDbContext.Tables.FirstAsync(d => d.Id == id);
    }
    
    public async Task Create(TableRequest tableRequest)
    {
      var table = new Table
      {
        Status = tableRequest.Status 
      };
      
      await _applicationDbContext.Tables.AddAsync(table);
      await _applicationDbContext.SaveChangesAsync();
    }
    
    public async Task Update(int id, TableRequest table)
    {
      var found = await _applicationDbContext.Tables.FirstAsync(d => d.Id == id);
      found.Status = table.Status;
      _applicationDbContext.Update(found);
      await _applicationDbContext.SaveChangesAsync();
    }
    
    public async Task Delete(int id)
    {
      var table = await _applicationDbContext.Tables.FirstAsync(d => d.Id == id);
      _applicationDbContext.Tables.Remove(table);
      await _applicationDbContext.SaveChangesAsync();
    }
  }
}