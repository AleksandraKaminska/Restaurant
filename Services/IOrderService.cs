using System.Collections.Generic;
using System.Threading.Tasks;
using Restaurant.DTOs;
using Restaurant.Models;

namespace Restaurant.Services
{
    public interface IOrderService
    {
        public Task<IEnumerable<Order>> GetAll();
        public Task<Order> GetById(int id);
        public Task Create(OrderRequest order);
        public Task Update(int id, OrderRequest order);
    }
}