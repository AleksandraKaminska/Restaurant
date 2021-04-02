using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Models
{
  public class Restaurant
  {
    public int taxId { get; set; }
    public Address address { get; set; }
    public Register register { get; set; }

    // atrybut klasowy
    static List<Restaurant> allRestaurants = new List<Restaurant>();

    public Restaurant()
    {
      AddRestaurant(this);
    }

    // metoda klasowa
    public static void AddRestaurant(Restaurant restaurant)
    {
      allRestaurants.Add(restaurant);
    }

    // metoda klasowa
    public static void RemoveRestaurant(Restaurant restaurant)
    {
      allRestaurants.Remove(restaurant);
    }

    // metoda klasowa
    public static void PrintAllRestaurants()
    {
      Console.WriteLine("Extent of the class: " + typeof(Restaurant));
    }
  }
}
