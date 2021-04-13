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
        public static void Main(string[] args)
        {
            var fileName = "extents.json";

            /*
             * - atrybut opcjonalny
             */
            var address1 = new Address("Street 1", "City 1", "12-122");
            var address2 = new Address("Street 2", "City 2", "13-133", "5a");

            new Local(99, address1, 30);
            new Local(100, address2, 40);

            /*
             * - ekstensja
             */
            Local.ShowExtent();

            /*
             * Trwała ekstensja
             */
            
            ObjectPlus.DeserializeDictionary(fileName);
            
            var phoneNumbers1 = new List<string> {"123456789"};
            var phoneNumbers2 = new List<string> {"987654321", "111222333"};
            new Employee(1, "Adam", "Mickiewicz", phoneNumbers1, new DateTime(2020, 6, 20), 35);
            new Employee(2, "Juliusz", "Słowacki", phoneNumbers2, new DateTime(2020, 9, 11), 30.5);

            ObjectPlus.ShowExtent(typeof(Employee));

            Employee.setMaxHourlyRate(50);
            
            // Menu menu = new Menu(new List<Meal>());
            // menu.PrintMenu();

            ObjectPlus.SerializeDictionary(fileName);

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
