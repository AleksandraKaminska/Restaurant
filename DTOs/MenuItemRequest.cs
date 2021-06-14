using System.ComponentModel.DataAnnotations;
using Restaurant.Models;

namespace Restaurant.DTOs
{
    public class MenuItemRequest
    {
        [Required]
        public int LocalId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public string Category { get; set; }
    }
}