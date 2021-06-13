using System.Collections.Generic;
using System.Threading.Tasks;
using Restaurant.DTOs;
using Restaurant.Models;

namespace Restaurant.Services
{
    public interface IMenuItemService
    {
        public Task<IEnumerable<MenuItem>> GetAll();
        public Task<MenuItem> GetById(int id);
        public Task Create(MenuItemRequest menuItem);
        public Task Update(int id, MenuItem menuItem);
        public Task Delete(int id);
    }
}