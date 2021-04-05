using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Restaurant.Models
{
  public class Employee
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    // atrybut powtarzalny
    public List<string> PhoneNumbers { get; set; }
    public DateTime EmploymentDate  { get; set; }
    public double HourlyRate { get; set; }
    // atrybut klasowy
    public static double MaxHourlyRate = 45.00;
    public static IList<Employee> Extent = new List<Employee>();

    public Employee(int id, string firstName, string lastName, List<string> phoneNumbers, DateTime employmentDate, double hourlyRate)
    {
      Id = id;
      FirstName = firstName;
      LastName = lastName;
      EmploymentDate = employmentDate;
      HourlyRate = hourlyRate;
      PhoneNumbers = phoneNumbers;

      if (phoneNumbers.Count > 3)
      {
        throw new ArgumentException("Too many phone numbers. You can add max 3.", nameof(phoneNumbers));
      }

      if (hourlyRate > MaxHourlyRate)
      {
        throw new ArgumentException("The hourly rate value must be lower than the maximum hourly rate");
      }

      AddEmployee(this);
    }

    public double getSalary(int hours, double tips = 0) {
      return hours * HourlyRate + tips;
    }

    // przesłonięcie
    // public new string GetIdentificationString()
    // {
    //   return $"{base.GetIdentificationString()}: {employeeId}";
    // }

    private static void AddEmployee(Employee employee)
    {
      Extent.Add(employee);
    }

    private static void RemoveEmployee(Employee employee)
    {
      Extent.Remove(employee);
    }

    // metoda klasowa
    public static void ShowExtent()
    {
      Console.WriteLine("Extent of the class: " + typeof(Employee));

      foreach (Employee employee in Extent)
      {
        Console.WriteLine(employee.ToString());
      }
    }

    public static void WriteExtent(Stream stream)
    {
      IFormatter formatter = new BinaryFormatter();
      formatter.Serialize(stream, Extent);
    }

    public static void ReadExtent(Stream stream)
    {
      IFormatter formatter = new BinaryFormatter();
      List<Employee> people = (List<Employee>)formatter.Deserialize(stream);

      Employee.Extent = people;
    }

    public override string ToString()
    {
      return $"{FirstName} {LastName}: {Id}";
    }

  }
}