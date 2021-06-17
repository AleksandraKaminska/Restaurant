using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
    public class Order
    {
        public int Id { get; set; }
        
        public virtual List<OrderMenuItem> OrderMenuItems { get; set; }
        public virtual Waiter Waiter { get; set; }
        
        public List<Bill> Bills = new List<Bill>();
        public Table Table { get; set; }
        
        public enum StatusType
        {
            Received,
            InPreparation,
            Done
        }
        
        public StatusType Status { get; set; }
        
        public Order()
        {
            Status = StatusType.Received;
        }
        
        public int GetId()
        {
            return Id;
        }

        // public void AddMenuItem(OrderMenuItem orderMenuItem)
        // {
        //     if (OrderMenuItemList.Contains(orderMenuItem))
        //     {
        //         return;
        //     }
        //     
        //     if (orderMenuItem.GetOrder() != this)
        //     {
        //         throw new Exception("Wrong data!");
        //     }
        //     
        //     OrderMenuItemList.Add(orderMenuItem);
        // }

        public void SetWaiter(Waiter waiter)
        {
            Waiter = waiter;
        }
        
        public Waiter GetWaiter()
        {
            return Waiter;
        }
        
        public void AddBill(Bill bill)
        {
            // if (AllSystemBills.Contains(bill))
            // {
            //     throw new Exception("Bill is assigned to another order");
            // }
            //
            // _orderBills.Add(bill);
            // AllSystemBills.Add(bill);
        }
    }
}