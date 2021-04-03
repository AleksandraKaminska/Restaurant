using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Restaurant.Models
{
  public class ObjectPlus
  {
    static string JsonFileName { get { return Path.Combine(Path.GetTempPath(), "dictionary.json"); } }
    static JsonSerializerSettings JsonSettings { get { return new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, Formatting = Formatting.Indented }; } }
    private static Dictionary<Type, List<Object>> _extents = new Dictionary<Type, List<Object>>();
    public static void SerializeDictionary()
    {
      var path = JsonFileName;
      using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Read))
      using (var writer = new StreamWriter(stream))
      {
        var serializer = JsonSerializer.CreateDefault(JsonSettings);
        serializer.Serialize(writer, _extents);
      }
    }
    public static void DeserializeDictionary()
    {
      var path = JsonFileName;
      try
      {
        using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
        using (var reader = new StreamReader(stream))
        using (var jsonReader = new JsonTextReader(reader))
        {
          var serializer = JsonSerializer.CreateDefault(JsonSettings);
          _extents = serializer.Deserialize<Dictionary<Type, List<Object>>>(jsonReader);
        }
      }
      catch (FileNotFoundException)
      {
        // File was not created yet, dictionary should be empty.
        _extents.Clear();
      }
    }
    public static List<Object> GetExtent(Type className)
    {
      List<Object> list = _extents[className];
      return list;
    }
    public static void AddEkstensja<T>(T obj)
    {
      List<Object> list;
      if (!_extents.TryGetValue(obj.GetType(), out list))
        list = _extents[obj.GetType()] = new List<object>();
      list.Add(obj);
    }
    internal static string ShowJsonContents()
    {
      if (!File.Exists(JsonFileName))
        return string.Empty;
      return File.ReadAllText(JsonFileName);
    }
  }
}