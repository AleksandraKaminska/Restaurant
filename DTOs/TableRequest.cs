using System.ComponentModel.DataAnnotations;
using Restaurant.Models;

namespace Restaurant.DTOs
{
    public class TableRequest
    {
        [Required]
        public int LocalId { get; set; }
        [Required]
        public Table.StatusType Status { get; set; }
        [Required]
        public int NrOfSeats { get; set; }
    }
}