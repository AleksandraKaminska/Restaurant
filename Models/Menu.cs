using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
  public class Menu
  {
    public List<Meal> meals { get; }
    public static double fee { get; set; } = .2;

    public Menu(List<Meal> meals)
    {
      this.meals = meals;
    }

    public void PrintMenu()
    {
      foreach (Meal meal in meals)
      {
        Console.WriteLine(meal.Name + " " + meal.price);
      }
    }

    // Przeciążenie
    public void PrintMenu(double tip)
    {
      foreach (Meal meal in meals)
      {
        Console.WriteLine(meal.Name + " " + meal.price * fee);
      }
    }
  }
}