using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Restaurant.Models
{
    [Serializable]
    public abstract class ObjectPlus
    {
        private static Dictionary<Type, ICollection<ObjectPlus>> _extent = new Dictionary<Type, ICollection<ObjectPlus>>();
        private static JsonSerializerSettings JsonSettings { get { return new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, Formatting = Formatting.Indented }; } } 
        private static JsonSerializer _serializer = JsonSerializer.CreateDefault(JsonSettings);

        public ObjectPlus()
        {
            FillEmptyTypeExtent(GetType());
            _extent[GetType()].Add(this);
        }

        public static void SerializeDictionary(string fileName)
        {
            using var stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.Read);
            using var writer = new StreamWriter(stream);
            _serializer.Serialize(writer, _extent);
        }

        public static void DeserializeDictionary(string fileName)
        {
            try
            {
                using var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                using var reader = new StreamReader(stream);
                using var jsonReader = new JsonTextReader(reader);
                _extent = _serializer.Deserialize<Dictionary<Type, ICollection<ObjectPlus>>>(jsonReader);
            }
            catch (FileNotFoundException)
            {
                _extent.Clear();
            }
        }
        
        public static ICollection<ObjectPlus> GetExtent(Type className)
        {
            FillEmptyTypeExtent(className);
            return _extent[className];
        }

        public static void ShowExtent(Type className)
        {
            Console.WriteLine($"====== Show extent: {className} ======");

            foreach (ObjectPlus obj in GetExtent(className))
            {
                Console.WriteLine(obj.ToString());
            }
        }

        private static void FillEmptyTypeExtent(Type className)
        {
            if (!_extent.ContainsKey(className))
            {
                _extent.Add(className, new List<ObjectPlus>());
            }
        }
    }
}