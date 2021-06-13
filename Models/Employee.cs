using System;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public abstract class Employee
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string[] PhoneNumbers { get; set; }
        public DateTime EmploymentDate { get; set; }
        public double HourlyRate { get; set; }

        private static double maxHourlyRate = 45.00;
        
        public Local Local { get; set; }

        public Employee()
        {
            
        }

        public Employee(string firstName, string lastName, string[] phoneNumbers, DateTime employmentDate, double hourlyRate)
        {
            FirstName = firstName;
            LastName = lastName;
            EmploymentDate = employmentDate;
            HourlyRate = hourlyRate;
            PhoneNumbers = phoneNumbers;

            if (phoneNumbers.Length > 3)
            {
                throw new ArgumentException("Too many phone numbers. You can add max 3.", nameof(phoneNumbers));
            }

            if (hourlyRate > maxHourlyRate)
            {
                throw new ArgumentException("The hourly rate value must be lower than the maximum hourly rate", nameof(hourlyRate));
            }
        }

        public double GetSalary(int hours)
        {
            return hours * HourlyRate;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Id}";
        }

        public static void SetMaxHourlyRate(double value)
        {
            if (value <= 0)
                throw new ArgumentException("Hourly rate cannot be equal or less than 0");

            maxHourlyRate = value;
        }
        
        public void SetLocal(Local local)
        {
            Local = local;
        }
        
        public Local GetLocal()
        {
            return Local;
        }
        
        public void RemoveLocal()
        {
            Local = null;
        }

        public virtual int GetOvertime(int overtime)
        {
            return 0;
        }
    }
}