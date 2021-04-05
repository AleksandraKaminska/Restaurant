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

        // • Ekstensja ✅
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
            * Trwała ekstensja
            */
            var phoneNumbers1 = new List<string> {"123456789"};
            var phoneNumbers2 = new List<string> {"987654321", "111222333"};
            Employee amickiewicz = new Employee(1, "Adam", "Mickiewicz", phoneNumbers1, new DateTime(2020, 6, 20), 35);
            Employee jslowacki = new Employee(2, "Juliusz", "Słowacki", phoneNumbers2, new DateTime(2020, 9, 11), 30.5);

            Employee.ShowExtent();

            Menu menu = new Menu(new List<Meal>());
            menu.PrintMenu();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
