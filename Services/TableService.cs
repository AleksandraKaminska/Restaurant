using System;
using System.Linq;
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
      return await _applicationDbContext.Tables
        .Include(s => s.Local)
        .ToListAsync();
    }
    
    public async Task<Table> GetById(int id)
    {
      return await _applicationDbContext.Tables
        .Include(s => s.Local)
        .FirstAsync(d => d.Id == id);
    }
    
    public async Task Create(TableRequest tableRequest)
    {
      var local = await _applicationDbContext.Locals.FirstOrDefaultAsync(d => d.Id == tableRequest.LocalId);

      var table = new Table
      {
        Status = tableRequest.Status,
        NrOfSeats = tableRequest.NrOfSeats,
        Local = local
      };
      
      await _applicationDbContext.Tables.AddAsync(table);
      await _applicationDbContext.SaveChangesAsync();
    }
    
    public async Task Update(int id, TableRequest table)
    {
      var found = await _applicationDbContext.Tables.FirstAsync(d => d.Id == id);
      found.Status = table.Status;
      found.NrOfSeats = table.NrOfSeats;
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