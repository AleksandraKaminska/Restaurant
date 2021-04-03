using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Models
{
  public class Local
  {
    // public int taxId { get; set; }

    // atrybut złożony
    public Address address { get; set; }
    public int nrOfTables { get; set; }
    // public Register register { get; set; }

    // atrybut klasowy
    // ekstensja
    static List<Local> allLocals = new List<Local>();

    public Local(Address address, int nrOfTables)
    {
      this.address = address;
      this.nrOfTables = nrOfTables;
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
    public static void ShowExtent()
    {
      Console.WriteLine("Extent of the class: " + typeof(Local));

      foreach (Local local in allLocals)
      {
        Console.WriteLine(local.ToString());
      }
    }
  }
}
