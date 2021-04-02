using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Models
{
  public class Invoice
  {
    int recipientTaxId;
    int recepeeTaxId;
    List<Meal> subject;

    public Invoice(int recipientTaxId, int recepeeTaxId, List<Meal> subject)
    {
      this.recipientTaxId = recipientTaxId;
      this.recepeeTaxId = recepeeTaxId;
      this.subject = subject;
    }

    // atrybut pochodny
    public double price
    {
      get
      {
        double totalPrice = 0;

        foreach (Meal meal in subject)
        {
          totalPrice += meal.price;
        }

        return totalPrice;
      }
    }

    // przesłonięcie
    public override string ToString()
    {
      return $"Recipient: {recipientTaxId}, recepee: {recepeeTaxId}, price: {price}";
    }
  }
}
