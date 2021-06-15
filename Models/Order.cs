using System;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Models
{
    public class Order
    {
        public int Id { get; set; }
        
        private readonly List<OrderMenuItem> _orderMenuItemList = new List<OrderMenuItem>();
        private Waiter _waiter;
        private readonly List<Bill> _orderBills = new List<Bill>();
        private static readonly List<Bill> AllSystemBills = new List<Bill>();
        
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
        
        public void SetStatus(StatusType status)
        {
            Status = status;
        }
        
        public int GetId()
        {
            return Id;
        }

        public void AddMenuItem(OrderMenuItem orderMenuItem)
        {
            if (_orderMenuItemList.Contains(orderMenuItem))
            {
                return;
            }
            
            if (orderMenuItem.GetOrder() != this)
            {
                throw new Exception("Wrong data!");
            }
            
            _orderMenuItemList.Add(orderMenuItem);
        }

        public void SetWaiter(Waiter waiter)
        {
            _waiter = waiter;
        }
        
        public Waiter GetWaiter()
        {
            return _waiter;
        }
        
        public void AddBill(Bill bill)
        {
            if (AllSystemBills.Contains(bill))
            {
                throw new Exception("Bill is assigned to another order");
            }
            
            _orderBills.Add(bill);
            AllSystemBills.Add(bill);
        }

        public void Remove()
        {
            AllSystemBills.Except(_orderBills);
            _orderBills.Clear();
        }

        public void ShowBills()
        {
            if (_orderBills.Count == 0)
            {
                Console.WriteLine($"The order {Id} does not have any bill" + "\n");
            }
            else
            {
                Console.WriteLine($"Bills assigned to the order {Id}:");
                _orderBills.ForEach(Console.WriteLine);
            }
        }

        public override string ToString()
        {
            return $"Order {Id}: {Status},{Environment.NewLine} waiter: {_waiter}";
        }
    }
}