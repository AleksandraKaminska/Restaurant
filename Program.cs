using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Restaurant.Models;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Restaurant
{
    public class Program
    {
        private static Random random = new Random();
        public static void Main(string[] args)
        {

            /*
            * - ekstensja
            */
            Local restaurant = new Local();
            Local restaurant1 = new Local();

            Local.PrintAllLocals();

            int recipientTaxId = 0;
            int recepeeTaxId = 1;
            List<Meal> orderedMeals = new List<Meal>();

            /*
            * - atrybut pochodny
            */
            Invoice invoice = new Invoice(recipientTaxId, recepeeTaxId, orderedMeals);

            /*
            * - atrybut opcjonalny
            */
            Address address = new Address("Street 1", "City 1", "12-122");
            restaurant.address = address;

            /*
            * - atrybut powtarzalny
            */
            Register register = new Register();
            register.AddInvoice(generateRandomInvoice());
            register.AddInvoice(generateRandomInvoice());

            /*
            * - przesłonięcie metodaGetIdentificationString
            */
            Employee employee = new Employee("John", "Doe");

            // atrybut złożony
            Client client = new Client("Jan", "Kowalski");
            client.taxId = 123456;

            /*
            * Trwała ekstensja
            */
            Person amickiewicz = new Person("Adam", "Mickiewicz");
            Person jslowacki = new Person("Juliusz", "Słowacki");

            Person.ShowExtent();

            // // przykład serializacji
            // Stream writeStream = new FileStream("Person.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            // Person.WriteExtent(writeStream);
            // writeStream.Close();

            // // przykład deserializacji
            // Stream readStream = new FileStream("Person.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            // Person.ReadExtent(readStream);
            // readStream.Close();

            // przeciążenie
            Menu menu = new Menu(new List<Meal>());
            menu.PrintMenu();

            CreateHostBuilder(args).Build().Run();
        }

        private static Invoice generateRandomInvoice()
        {
            int recipientTaxId = random.Next(1, 100);
            int recepeeTaxId = random.Next(1, 100);

            List<Meal> orderedMeals = new List<Meal>();

            // metoda klasowa
            Ingridient.WarehouseAddress = new Address("Random Street", "Random City", "12-122");
            Console.WriteLine("Warehouse Address");
            Console.WriteLine(Ingridient.ShowWarehouseAddress());
            var ingridient = new Ingridient("Potatoe", 12);
            var ingridients = new List<Ingridient>();
            ingridients.Add(ingridient);

            // atrybut klasowy
            var meal = new Meal(ingridients, "Potatoe soup");

            orderedMeals.Add(meal);

            return new Invoice(recipientTaxId, recepeeTaxId, orderedMeals);
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
