using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
  public class Employee : ObjectPlus
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    // atrybut powtarzalny
    public List<string> PhoneNumbers { get; set; }
    public DateTime EmploymentDate  { get; set; }
    public double HourlyRate { get; set; }

    private static double? _maxHourlyRate;
    // atrybut klasowy
    private static double MaxHourlyRate
    {
        get => _maxHourlyRate ?? 45.00;
        set
        {
            if (value <= 0)
                throw new ArgumentException("Tax rate cannot be equal or less than 0");

            _maxHourlyRate = value;
        }
    }

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
        throw new ArgumentException("The hourly rate value must be lower than the maximum hourly rate", nameof(hourlyRate));
      }
    }

    public double GetSalary(int hours, double tips = 0) {
      return hours * HourlyRate + tips;
    }

    public override string ToString()
    {
      return $"{FirstName} {LastName}: {Id}";
    }
  }
}