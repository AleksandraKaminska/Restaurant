using System.ComponentModel.DataAnnotations;
using Restaurant.Models;

namespace Restaurant.DTOs
{
    public class OrderRequest
    {
        [Required]
        public Order.StatusType Status { get; set; }
    }
}