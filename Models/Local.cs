using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
  public class Local
  {
    [Key]
    public int Id { get; }
    public Address Address { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
    public int NrOfTables { get; set; }
    public List<Employee> Employees { get; set; }
    public virtual Menu Menu { get; set; }
    
    public Local()
    {
      
    }
    
    // public void AddEmployee(Employee employee)
    // {
    //   if (Employees.Contains(employee))
    //   {
    //     return;
    //   }
    //
    //   var local = employee.GetLocal();
    //   if (local == null || local == this)
    //   {
    //     Employees.Add(employee);
    //             
    //     // add the reserve connection
    //     employee.SetLocal(this);
    //   } else
    //   {
    //     throw new Exception("The employee works in another local");
    //   }
    // }
    //
    // public void RemoveEmployee(Employee employee)
    // {
    //   if (Employees.Contains(employee))
    //   {
    //     Employees.Remove(employee);
    //     employee.RemoveLocal();
    //   } else
    //   {
    //     Console.WriteLine("Employee not found");
    //   }
    // }
  }
}
