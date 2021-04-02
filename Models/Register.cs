using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Models
{
  public class Register
  {
    // atrybut powtarzalny
    List<Invoice> allInvoices = new List<Invoice>();

    public void AddInvoice(Invoice invoice)
    {
      this.allInvoices.Add(invoice);
    }

    public void RemoveInvoice(Invoice invoice)
    {
      this.allInvoices.Remove(invoice);
    }

    public void printRegister()
    {
      Console.WriteLine("Register content:");

      foreach (Invoice invoice in allInvoices)
      {
        Console.WriteLine(invoice);
      }
    }
  }
}