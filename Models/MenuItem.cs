using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Models
{
  public class MenuItem
  {
    // atrybut klasowy
    public static double tax = .2;
    public string Name { get; }

    public MenuItem(string name)
    {
      Name = name;
    }
  }
}