using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Restaurant.Models
{
  [Serializable]
  public class Person
  {
    public string firstName { get; }
    public string lastName { get; }

    public static IList<Person> extent = new List<Person>();

    public Person(string firstName, string lastName)
    {
      this.firstName = firstName;
      this.lastName = lastName;

      AddPerson(this);
    }

    public string GetIdentificationString()
    {
      return $"{firstName} {lastName}";
    }

    private static void AddPerson(Person person)
    {
      extent.Add(person);
    }

    private static void RemovePerson(Person person)
    {
      extent.Remove(person);
    }

    public static void ShowExtent()
    {
      Console.WriteLine("Extent of the class: " + typeof(Restaurant));

      foreach (Person person in extent)
      {
        Console.WriteLine(person.GetIdentificationString());
      }
    }

    public static void WriteExtent(Stream stream)
    {
      IFormatter formatter = new BinaryFormatter();
      formatter.Serialize(stream, extent);
    }

    public static void ReadExtent(Stream stream)
    {
      IFormatter formatter = new BinaryFormatter();
      List<Person> people = (List<Person>)formatter.Deserialize(stream);

      Person.extent = people;
    }
  }
}