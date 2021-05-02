using System;
using System.Collections.Generic;

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
    private static List<Local> allLocals = new List<Local>();

    private readonly List<Employee> _employeesList = new List<Employee>(); // implementation of the association

    public Local(int id, Address address, int nrOfTables)
    {
      Id = id;
      Address = address;
      NrOfTables = nrOfTables;
      AddLocal(this);
    }

    private static void AddLocal(Local restaurant)
    {
      allLocals.Add(restaurant);
    }

    public static void RemoveLocal(Local restaurant)
    {
      allLocals.Remove(restaurant);
    }
    
    public void AddEmployee(Employee employee)
    {
      if (_employeesList.Contains(employee))
      {
        return;
      }

      var local = employee.GetLocal();
      if (local == null || local == this)
      {
        _employeesList.Add(employee);
                
        // add the reserve connection
        employee.SetLocal(this);
      } else
      {
        throw new Exception("The employee works in another local");
      }
    }
    
    public void RemoveEmployee(Employee employee)
    {
      if (_employeesList.Contains(employee))
      {
        _employeesList.Remove(employee);
        employee.RemoveLocal();
      } else
      {
        Console.WriteLine("Employee not found");
      }
    }

    public static void ShowExtent()
    {
      Console.WriteLine("Extent of the class: " + typeof(Local));

      foreach (Local local in allLocals)
      {
        Console.WriteLine(local.ToString());
      }
    }

    public override string ToString() {
      return $"Local {Id}: {Address},{Environment.NewLine}nr of tables: {NrOfTables},{Environment.NewLine}employess: {string.Join("", _employeesList)}";
    }
  }
}
