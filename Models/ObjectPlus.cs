using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

namespace Restaurant.Models
{
    [Serializable]
    public abstract class ObjectPlus
    {
        private static Dictionary<Type, ICollection<ObjectPlus>> _extent = new Dictionary<Type, ICollection<ObjectPlus>>();
        //private static Dictionary<Type, List<Object>> _ekstensje = new Dictionary<Type, List<Object>>();
        static JsonSerializerSettings JsonSettings { get { return new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, Formatting = Formatting.Indented }; } }

        public ObjectPlus()
        {
            if (!_extent.ContainsKey(GetType()))
                _extent.Add(GetType(), new List<ObjectPlus>());

            _extent[GetType()].Add(this);
        }

        public static Dictionary<Type, IEnumerable<ObjectPlus>> Extent
        {
            get
            {
                var result = new Dictionary<Type, IEnumerable<ObjectPlus>>();
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
            var deserializedDictionary = (Dictionary<string, ICollection<ObjectPlus>>)formatter.Deserialize(stream);

            _extent = deserializedDictionary.ToDictionary(x => Type.GetType(x.Key), x => x.Value);
        }

        public static void SerializeDictionary(string fileName)
        {
            using var stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.Read);
            using var writer = new StreamWriter(stream);
            var serializer = JsonSerializer.CreateDefault(JsonSettings);
            serializer.Serialize(writer, _extent);
        }

        public static void DeserializeDictionary(string fileName)
        {
            try
            {
                using var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                using var reader = new StreamReader(stream);
                using var jsonReader = new JsonTextReader(reader);
                var serializer = JsonSerializer.CreateDefault(JsonSettings);
                _extent = serializer.Deserialize<Dictionary<Type, ICollection<ObjectPlus>>>(jsonReader);
            }
            catch (FileNotFoundException)
            {
                _extent.Clear();
            }
        }

        //public static List<Object> GetEkstensja(Type className)
        //{
        //    List<Object> list = _extent[className];
        //    return list;
        //}

        public void ShowExtent()
        {
          Console.WriteLine($"Extenet of the class: {nameof(Employee)}");
          int count = 0;

          foreach (ObjectPlus obj in Extent[this.GetType()])
          {
            Console.WriteLine($"----- {nameof(Employee)}: {++count} ------");
            Console.WriteLine(obj.ToString());
          }
        }
    }
}