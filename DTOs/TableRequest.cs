using System.ComponentModel.DataAnnotations;
using Restaurant.Models;

namespace Restaurant.DTOs
{
    public class TableRequest
    {
        [Required]
        public Table.StatusType Status { get; set; }
        public int NrOfSeats { get; set; }
        [Required]
        public int LocalId { get; set; }
    }
}