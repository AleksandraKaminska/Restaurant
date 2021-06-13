using System.Collections.Generic;
using System.Threading.Tasks;
using Restaurant.DTOs;
using Restaurant.Models;

namespace Restaurant.Services
{
    public interface ILocalService
    {
        public Task<IEnumerable<Local>> GetAll();
        public Task<Local> GetById(int id);
        public Task Create(LocalRequest local);
        public Task Update(int id, Local local);
        public Task Delete(int id);
    }
}