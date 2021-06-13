using System.ComponentModel.DataAnnotations;
using Restaurant.Models;

namespace Restaurant.DTOs
{
    public class LocalRequest
    {
        [Required]
        public Address Address { get; set; }
        [Required]
        public int NrOfTables { get; set; }
    }
}