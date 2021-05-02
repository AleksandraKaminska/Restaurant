namespace Restaurant.Models
{
  public class Ingridient
  {
    public static Address WarehouseAddress { get; set; }

    // atrybut prosty
    public string Name { get; }
    public int Price { get; }

    public Ingridient(string name, int price)
    {
      Name = name;
      Price = price;
    }

    public static string ShowWarehouseAddress()
    {
      return WarehouseAddress.ToString();
    }
  }
}