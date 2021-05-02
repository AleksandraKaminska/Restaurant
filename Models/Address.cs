using System;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
  [Serializable]
  public class Address
  {
    [Required]
    public string Street { get; set; }
    [Required]
    public string City { get; set; }
    [Required]
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
    public void UpdateAddress(string street, string city, string zipCode, string apartmentNumber = null)
    {
        Street = street;
        City = city;
        ZipCode = zipCode;
        ApartmentNumber = apartmentNumber;
    }

    public void UpdateAddress(Address address)
    {
        Street = address.Street;
        City = address.City;
        ZipCode = address.ZipCode;
        ApartmentNumber = address.ApartmentNumber;
    }

    public override string ToString()
    {
      return ApartmentNumber == null
        ? $"City: {City}\nStreet: {Street}"
        : $"City: {City}\nStreet: {Street}\nApartment number: {ApartmentNumber}";
    }
  }
}