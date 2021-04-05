using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Models
{
  public class Local
  {
    // [Required]
    public int Id { get; set; }
    // atrybut złożony
    // [Required]
    public Address Address { get; set; }
    // [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
    public int NrOfTables { get; set; }

    // ekstensja klasy
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

    public static void AddLocal(Local restaurant)
    {
      allLocals.Add(restaurant);
    }

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
