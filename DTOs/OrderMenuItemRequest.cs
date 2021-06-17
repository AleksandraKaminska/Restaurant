using System.ComponentModel.DataAnnotations;
using Restaurant.Models;

namespace Restaurant.DTOs
{
    public class OrderMenuItemRequest
    {
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int MenuItemId { get; set; }
    }
}