using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(300)]
        public string Description { get; set; }
        public float Price { get; set; }

        public virtual Menu Menu { get; }
        
        private List<OrderMenuItem> OrderMenuItemList { get; set; }
        
        public MenuItem()
        {
        }
        
        public MenuItem(string title, string description, float price)
        {
            Title = title;
            Description = description;
            Price = price;
        }
        
        public void AddOrder(OrderMenuItem orderMenuItem)
        {
            if (OrderMenuItemList.Contains(orderMenuItem))
            {
                return;
            }
            
            if (orderMenuItem.GetMenuItem() != this)
            {
                throw new Exception("Wrong data!");
            }
            
            OrderMenuItemList.Add(orderMenuItem);
        }
    }
}