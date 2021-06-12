using System.Collections.Generic;
using System.Linq;
using Restaurant.Models;

namespace Restaurant.Services
{
  public class OrderService
  {
    private static List<Order> orders = new List<Order>();
    
    static OrderService()
    {
    }
    
    public List<Order> GetAll()
    {
      return orders;
    }
    
    public Order GetById(int id)
    {
      return orders.Where(order => order.Id == id).FirstOrDefault();
    }
    
    public Order Create(Order order)
    {
      orders.Add(order);
      return order;
    }
    
    public void Update(int id, Order order)
    {
      Order found = orders.Where(n => n.Id == id).FirstOrDefault();
      found.Status = order.Status;
    }
    
    public void Delete(int id)
    {
      orders.RemoveAll(n => n.Id == id);
    }
  }
}