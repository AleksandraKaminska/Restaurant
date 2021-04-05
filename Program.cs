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

        // • Ekstensja
        // • Ekst. - trwałość
        // • Atr.złożony ✅
        // • Atr.opcjonalny ✅
        // • Atr.powt ✅
        // • Atr.klasowy ✅
        // • Atr.pochodny ✅
        // • Met.klasowa
        // • Przesłonięcie ✅
        // • przeciążenie ✅

        public static void Main(string[] args)
        {

            /*
            * - atrybut opcjonalny
            */
            Address address1 = new Address("Street 1", "City 1", "12-122");
            Address address2 = new Address("Street 2", "City 2", "13-133");

            /*
            * - ekstensja
            */
            Local local = new Local(99, address1, 30);
            Local local1 = new Local(100, address2, 40);

            Local.ShowExtent();

            int recipientTaxId = 0;
            int recepeeTaxId = 1;
            List<Meal> orderedMeals = new List<Meal>();

            /*
            * - atrybut pochodny
            */
            Invoice invoice = new Invoice(recipientTaxId, recepeeTaxId, orderedMeals);


            /*
            * - atrybut powtarzalny
            */
            Register register = new Register();
            register.AddInvoice(generateRandomInvoice());
            register.AddInvoice(generateRandomInvoice());

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

            Menu menu = new Menu(new List<Meal>());
            menu.PrintMenu();

            CreateHostBuilder(args).Build().Run();
        }

        private static Invoice generateRandomInvoice()
        {
            int recipientTaxId = random.Next(1, 100);
            int recepeeTaxId = random.Next(1, 100);

            List<Meal> orderedMeals = new List<Meal>();

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
