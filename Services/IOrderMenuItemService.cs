using System.Collections.Generic;
using System.Threading.Tasks;
using Restaurant.DTOs;
using Restaurant.Models;

namespace Restaurant.Services
{
    public interface IOrderMenuItemService
    {
        public Task<IEnumerable<OrderMenuItem>> GetAll();
        public Task<OrderMenuItem> GetById(int id);
        public Task<OrderMenuItem> Create(OrderMenuItemRequest orderMenuItem);
        public Task Update(int id, OrderMenuItem orderMenuItem);
        public Task Delete(int id);
    }
}