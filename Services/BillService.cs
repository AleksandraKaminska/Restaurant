using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.DTOs;
using Restaurant.Models;

namespace Restaurant.Services
{
  public class BillService : IBillService
  {
    private readonly ApplicationDbContext _applicationDbContext;

    public BillService(ApplicationDbContext applicationDbContext)
    {
      _applicationDbContext = applicationDbContext;
    }
    
    public async Task<IEnumerable<Bill>> GetAll()
    {
      return await _applicationDbContext.Bills.ToListAsync();
    }
    
    public async Task<Bill> GetById(int id)
    {
      return await _applicationDbContext.Bills.FirstAsync(d => d.Id == id);
    }
    
    public async Task Create(BillRequest billRequest)
    {
      // var local = await _applicationDbContext.Locals
      //   .Include(s => s.Menu)
      //   .FirstAsync(d => d.Id == menuItemRequest.LocalId);
      //
      var bill = new Bill
      {
      };
      
      await _applicationDbContext.Bills.AddAsync(bill);
      await _applicationDbContext.SaveChangesAsync();
    }
  }
}