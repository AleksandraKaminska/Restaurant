using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Models
{
  [Serializable]
  public class Address
  {
    string street;
    string city;
    string zipCode;
    string apartmentNumber;

    // apartmentNumber - atrybut opcjonalny
    public Address(string street, string city, string zipCode, string apartmentNumber = null)
    {
      this.street = street;
      this.city = city;
      this.zipCode = zipCode;
      this.apartmentNumber = apartmentNumber;
    }

    // apartmentNumber - atrybut opcjonalny
    // UpdateAddress - przeciężenie metody
    public void UpdateAddress(string street, string city, string zipCode, string apartmentNumber = null)
    {
      this.street = street;
      this.city = city;
      this.zipCode = zipCode;
      this.apartmentNumber = apartmentNumber;
    }

    // UpdateAddress - przeciężenie metody
    public void UpdateAddress(Address address)
    {
      this.street = address.street;
      this.city = address.city;
      this.zipCode = address.zipCode;
      this.apartmentNumber = address.apartmentNumber;
    }

    public override string ToString()
    {
      return $"City: {city}\nStreet: {street}\nApartnemt number: {apartmentNumber}";
    }
  }
}