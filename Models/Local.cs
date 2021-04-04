using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Models
{
  public class Local
  {
    public int Id { get; set; }
    // atrybut złożony
    public Address Address { get; set; }
    public int NrOfTables { get; set; }

    // ekstensja
    static List<Local> allLocals = new List<Local>();

    public Local()
    {
      AddLocal(this);
    }

    public Local(int id, Address address, int nrOfTables)
    {
      Id = id;
      Address = address;
      NrOfTables = nrOfTables;
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

    public override string ToString() {
      return $"Local {Id}: {Address}, nr of tables: {NrOfTables}";
    }
  }
}
