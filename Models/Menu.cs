using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Models
{
  public class Menu
  {
    public virtual List<MenuItem> MenuItems { get; set; }

    public virtual Local Local { get; set; }
    
    [Key]
    public int Id { get; }
    
    public Menu()
    {
    }
  }
}