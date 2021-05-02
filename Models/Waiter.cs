using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
    public class Waiter : Employee
    {
        private Dictionary<int, Order> _orderQualif = new Dictionary<int, Order>();
        
        public Waiter(string firstName, string lastName, List<string> phoneNumbers, DateTime employmentDate, double hourlyRate) 
            : base(firstName, lastName,  phoneNumbers, employmentDate,  hourlyRate)
        {
        }
        
        // przeciążenie
        public double GetSalary(int hours, double tips = 0)
        {
            return hours * HourlyRate + tips;
        }
        
        // przesłonięcie
        public override int GetOvertime(int overtime)
        {
            return overtime;
        }
        
        public void AddOrderQualif(Order order)
        {
            if (_orderQualif.ContainsKey(order.GetId()))
            {
                throw new Exception("Order has already been assigned to the waiter.");
            }

            if (order.GetWaiter() != null)
            {
                throw new Exception("Order has already been assigned to another waiter.");
            }
            
            _orderQualif.Add(order.GetId(), order);
            order.SetWaiter(this);
        }
        public Order FindOrderQualif(int id)
        {
            if (!_orderQualif.ContainsKey(id))
            {
                throw new Exception("Unable to find an order with id " + id);
            }
            return _orderQualif.GetValueOrDefault(id);
        }
        public Dictionary<int, Order> GetDictionary()
        {
            return _orderQualif;
        }

        public override string ToString()
        {
            return $"Waiter {Id}: {FirstName} {LastName}{Environment.NewLine}";
        }
    }
}