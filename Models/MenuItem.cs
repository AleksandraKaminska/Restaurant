using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(300)]
        public string Description { get; set; }
        public float Price { get; set; }
        public string Category { get; set; }

        public virtual Menu Menu { get; set; }
        public virtual List<OrderMenuItem> OrderMenuItems { get; set; }
        
        public MenuItem()
        {
        }
    }
}