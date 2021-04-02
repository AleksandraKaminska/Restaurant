using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Models
{
  public class Local
  {
    public int taxId { get; set; }
    public Address address { get; set; }
    public Register register { get; set; }

    // atrybut klasowy
    static List<Local> allLocals = new List<Local>();

    public Local()
    {
      AddLocal(this);
    }

    // metoda klasowa
    public static void AddLocal(Local restaurant)
    {
      allLocals.Add(restaurant);
    }

    // metoda klasowa
    public static void RemoveLocal(Local restaurant)
    {
      allLocals.Remove(restaurant);
    }

    // metoda klasowa
    public static void PrintAllLocals()
    {
      Console.WriteLine("Extent of the class: " + typeof(Local));
    }
  }
}
