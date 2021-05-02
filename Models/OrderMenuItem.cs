using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
    public class OrderMenuItem
    {
        private readonly int _quantity;
        private readonly MenuItem _menuItem;
        private readonly Order _order;
        
        private static readonly List<OrderMenuItem> OrderMenuItemList = new List<OrderMenuItem>();
        
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
            
            _menuItem = menuItem;
            _order = order;
            _quantity = quantity;

            menuItem.AddOrder(this);
            order.AddMenuItem(this);
            
            OrderMenuItemList.Add(this);
        }
        
        public MenuItem GetMenuItem()
        {
            return _menuItem;
        }
        
        public Order GetOrder()
        {
            return _order;
        }
        
        public override string ToString()
        {
            return  $"Order {_order.Id}: {_menuItem} zł x {_quantity}";
        }
    }
}