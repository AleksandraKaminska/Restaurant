using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public float Total { get; set; }
        
        public virtual Bill Bill { get; set; }
        
        public enum MethodType
        {
            Cash,
            CreditCard,
        }
        
        public MethodType Method { get; set; }
        
        public Payment()
        {
        }
    }
}