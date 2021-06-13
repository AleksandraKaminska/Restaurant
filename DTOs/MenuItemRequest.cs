using System.ComponentModel.DataAnnotations;
using Restaurant.Models;

namespace Restaurant.DTOs
{
    public class MenuItemRequest
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public float Price { get; set; }
    }
}