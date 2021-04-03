using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Models
{
  [Serializable]
  public class Address
  {
    public string Street { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; }
    public string ApartmentNumber { get; set; }

    // apartmentNumber - atrybut opcjonalny
    public Address(string street, string city, string zipCode, string apartmentNumber = null)
    {
        Street = street;
        City = city;
        ZipCode = zipCode;
        ApartmentNumber = apartmentNumber;
    }

    // apartmentNumber - atrybut opcjonalny
    // UpdateAddress - przeciężenie metody
    public void UpdateAddress(string street, string city, string zipCode, string apartmentNumber = null)
    {
        Street = street;
        City = city;
        ZipCode = zipCode;
        ApartmentNumber = apartmentNumber;
    }

    // UpdateAddress - przeciężenie metody
    public void UpdateAddress(Address address)
    {
        Street = address.Street;
        City = address.City;
        ZipCode = address.ZipCode;
        ApartmentNumber = address.ApartmentNumber;
    }

    public override string ToString()
    {
      return $"City: {City}\nStreet: {Street}\nApartnemt number: {ApartmentNumber}";
    }
  }
}