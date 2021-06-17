using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
    public class OrderMenuItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        
        public virtual MenuItem MenuItem { get; set; }
        public virtual Order Order { get; set; } 
        
        public OrderMenuItem()
        {
        }
    }
}