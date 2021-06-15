using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
    public class Table
    {
        public int Id { get; set; }
        public int NrOfSeats { get; set; }
        public StatusType Status { get; set; }

        public List<Order> Orders = new List<Order>();
        
        public enum StatusType
        {
            Free,
            Occupied,
            Reserved
        }
        
        public Table()
        {
            Status = StatusType.Free;
        }
    }
}