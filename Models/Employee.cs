using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
    public abstract class Employee : ObjectPlus
    {
        private static int Count = 1;
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // atrybut powtarzalny
        public List<string> PhoneNumbers { get; set; }
        public DateTime EmploymentDate { get; set; }
        public double HourlyRate { get; set; }

        // atrybut klasowy
        private static double maxHourlyRate = 45.00;
        
        private Local _local;

        public Employee(string firstName, string lastName, List<string> phoneNumbers, DateTime employmentDate, double hourlyRate)
        {
            Id = Count++;
            FirstName = firstName;
            LastName = lastName;
            EmploymentDate = employmentDate;
            HourlyRate = hourlyRate;
            PhoneNumbers = phoneNumbers;

            if (phoneNumbers.Count > 3)
            {
                throw new ArgumentException("Too many phone numbers. You can add max 3.", nameof(phoneNumbers));
            }

            if (hourlyRate > maxHourlyRate)
            {
                throw new ArgumentException("The hourly rate value must be lower than the maximum hourly rate", nameof(hourlyRate));
            }
        }

        // atrybut pochodny
        public double GetSalary(int hours)
        {
            return hours * HourlyRate;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Id}";
        }

        // metoda klasowa
        public static void setMaxHourlyRate(double value)
        {
            if (value <= 0)
                throw new ArgumentException("Hourly rate cannot be equal or less than 0");

            maxHourlyRate = value;
        }
        
        public void SetLocal(Local local)
        {
            _local = local;
        }
        
        public Local GetLocal()
        {
            return _local;
        }
        
        public void RemoveLocal()
        {
            _local = null;
        }

        public virtual int GetOvertime(int overtime)
        {
            return 0;
        }
    }
}