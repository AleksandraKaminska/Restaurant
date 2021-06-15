using System.Collections.Generic;
using System.Threading.Tasks;
using Restaurant.DTOs;
using Restaurant.Models;

namespace Restaurant.Services
{
    public interface ITableService
    {
        public Task<IEnumerable<Table>> GetAll();
        public Task<Table> GetById(int id);
        public Task Create(TableRequest table);
        public Task Update(int id, TableRequest table);
        public Task Delete(int id);
    }
}