using System.ComponentModel.DataAnnotations;
using Restaurant.Models;

namespace Restaurant.DTOs
{
    public class BillRequest
    {
        [Required]
        public float Total { get; set; }
        [Required]
        public float Tax { get; set; }
        public float Tip { get; set; }
    }
}