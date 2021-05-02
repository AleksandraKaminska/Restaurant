using System;

namespace Restaurant.Models
{
    public class Bill
    {
        private static int _count = 1;
        private int Id { get; }
        private double Total { get; set; }
        
        private double Tip { get; set; }
        
        private double Tax { get; set; }
        
        private Order Order { get; }

        private Bill(Order order, double total, double tip, double tax)
        {
            Id = _count++;
            Order = order;
            Total = total;
            Tip = tip;
            Tax = tax;
        }
        
        public static Bill CreateBill(Order order, double total, double tip, double tax)
        {
            if (order == null)
            {
                throw new Exception("Order does not exist");
            }

            var bill = new Bill(order, total, tip, tax);
            order.AddBill(bill);
            return bill;
        }

        public override string ToString()
        {
            return $"{Environment.NewLine}Bill {Id}: total - {Total}, tip - {Tip}, tax - {Tax}";
        }
    }
}