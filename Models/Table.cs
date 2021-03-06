using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
    public class Table
    {
        public int Id { get; set; }
        public int NrOfSeats { get; set; }
        public StatusType Status { get; set; }
        public int LocalId { get; set; }

        public virtual List<Order> Orders { get; set; }
        public virtual Local Local { get; set; }
        
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