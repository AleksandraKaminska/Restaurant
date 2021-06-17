using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class Bill
    {
        [Key]
        public int Id { get; }
        public double Total { get; set; }
        
        public double Tip { get; set; }
        
        public double Tax { get; set; }
        
        public virtual Order Order { get; }

        public Bill()
        {
        }
    }
}