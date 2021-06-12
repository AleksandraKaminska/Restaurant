using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
  public class Menu
  {
    public List<MenuItem> MenuItems { get; }

    public Local Local { get; set; }
    
    public int Id { get; set; }
    
    public Menu()
    {
    }
    
    public Menu(int id)
    {
      Id = id;
    }

    public void PrintMenu()
    {
      foreach (MenuItem menuItem in MenuItems)
      {
        Console.WriteLine(menuItem.Title + " " + menuItem.Price);
      }
    }
  }
}