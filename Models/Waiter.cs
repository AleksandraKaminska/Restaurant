using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
    public class Waiter : Employee
    {
        // przeciążenie
        public double GetSalary(int hours, double tips = 0)
        {
            return hours * HourlyRate + tips;
        }
        
        // przesłonięcie
        public override int GetOvertime(int overtime)
        {
            return overtime;
        }
    }
}