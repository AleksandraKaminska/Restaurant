using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
    public class OrderMenuItem
    {
        private int Quantity { get; set; }
        private MenuItem MenuItem { get; set; }
        private Order Order { get; set; } 
        
        private List<OrderMenuItem> OrderMenuItemList = new List<OrderMenuItem>();
        
        public OrderMenuItem(MenuItem menuItem, Order order, int quantity)
        {
            if (menuItem == null)
            {
                throw new Exception("Menu item can't be null");
            }
            
            if (order == null)
            {
                throw new Exception("Order can't be null");
            }
            
            OrderMenuItemList.ForEach(omi =>
            {
                if(omi.GetMenuItem() == menuItem && omi.GetOrder() == order)
                {
                    OrderMenuItemList.Remove(omi);
                } 
            });
            
            MenuItem = menuItem;
            Order = order;
            Quantity = quantity;

            // menuItem.AddOrder(this);
            // order.AddMenuItem(this);
            
            OrderMenuItemList.Add(this);
        }
        
        public MenuItem GetMenuItem()
        {
            return MenuItem;
        }
        
        public Order GetOrder()
        {
            return Order;
        }
    }
}