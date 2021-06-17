using System.Collections.Generic;
using System.Threading.Tasks;
using Restaurant.DTOs;
using Restaurant.Models;

namespace Restaurant.Services
{
    public interface IBillService
    {
        public Task<IEnumerable<Bill>> GetAll();
        public Task<Bill> GetById(int id);
        public Task Create(BillRequest bill);
    }
}