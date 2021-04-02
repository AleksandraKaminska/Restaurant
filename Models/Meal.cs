using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Models
{
  public class Meal
  {
    // atrybut klasowy
    public static double tax = .2;
    public string Name { get; }
    List<Ingridient> ingridients;

    public Meal(List<Ingridient> ingridients, string name)
    {
      this.ingridients = ingridients;
      this.Name = name;
    }

    // atrybut pochodny
    public double price
    {
      get
      {
        var ingridientsPriceSum = 0;

        foreach (Ingridient ingridient in ingridients)
        {
          ingridientsPriceSum += ingridient.Price;
        }

        return (1 + tax) * ingridientsPriceSum;
      }
    }
  }
}