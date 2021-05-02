using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class MenuItem
    {
        private static int Count = 1;
        public int Id { get; set; }
        public string Title { get; set; }
        [MaxLength(300)]
        public string Description { get; set; }
        public double Price { get; set; }
        
        private readonly List<OrderMenuItem> _orderMenuItemList = new List<OrderMenuItem>();
        
        public MenuItem(string title, string description, double price)
        {
            Id = Count++;
            Title = title;
            Description = description;
            Price = price;
        }
        
        public void AddOrder(OrderMenuItem orderMenuItem)
        {
            if (_orderMenuItemList.Contains(orderMenuItem))
            {
                return;
            }
            
            if (orderMenuItem.GetMenuItem() != this)
            {
                throw new Exception("Wrong data!");
            }
            
            _orderMenuItemList.Add(orderMenuItem);
        }
        
        public override string ToString()
        {
            return $"{Title} - {Price}";
        }
    }
}