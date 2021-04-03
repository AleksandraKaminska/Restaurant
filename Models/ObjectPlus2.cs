using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Restaurant.Models
{
  [Serializable]
  abstract class ObjectPlus2
  {
    private static Dictionary<Type, ICollection<ObjectPlus2>> _extent = new Dictionary<Type, ICollection<ObjectPlus2>>();

    public ObjectPlus2()
    {
      if (!_extent.ContainsKey(GetType()))
        _extent.Add(GetType(), new List<ObjectPlus2>());

      _extent[GetType()].Add(this);
    }

    public static Dictionary<Type, IEnumerable<ObjectPlus2>> Extent
    {
      get
      {
        var result = new Dictionary<Type, IEnumerable<ObjectPlus2>>();
        foreach (var k in _extent)
          result.Add(k.Key, k.Value.ToImmutableList());

        return result;
      }
    }

    public static void SerializeToFile(string fileName)
    {
      var dictForSerialization = _extent.ToDictionary(x => x.Key.FullName, x => x.Value);

      using Stream stream = File.Open(fileName, FileMode.Create);
      BinaryFormatter formatter = new BinaryFormatter();
      formatter.Serialize(stream, dictForSerialization);
    }

    public static void DeserializeFromFile(string fileName)
    {
      using Stream stream = File.Open(fileName, FileMode.Open);
      BinaryFormatter formatter = new BinaryFormatter();
      var deserializedDictionary = (Dictionary<string, ICollection<ObjectPlus2>>)formatter.Deserialize(stream);

      _extent = deserializedDictionary.ToDictionary(x => Type.GetType(x.Key), x => x.Value);
    }
  }
}