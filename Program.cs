using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Restaurant.Models;

namespace Restaurant
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const string fileName = "extents.json";

            /*
             * - atrybut opcjonalny
             */
            var address1 = new Address("Street 1", "City 1", "12-122");
            var address2 = new Address("Street 2", "City 2", "13-133", "5a");

            var local1 = new Local(99, address1, 30);
            var local2 = new Local(100, address2, 40);

            /*
             * - ekstensja
             */
            // Local.ShowExtent();

            /*
             * Trwała ekstensja
             */
            
            ObjectPlus.DeserializeDictionary(fileName);
            
            var phoneNumbers1 = new List<string> {"123456789"};
            var phoneNumbers2 = new List<string> {"987654321", "111222333"};
            var phoneNumbers3 = new List<string> {"436576325675"};
            var phoneNumbers4 = new List<string> {"3762436", "376432743"};
            var waiter1 = new Waiter("Adam", "Mickiewicz", phoneNumbers1, new DateTime(2020, 6, 20), 35);
            var waiter2 = new Waiter("Juliusz", "Słowacki", phoneNumbers2, new DateTime(2020, 9, 11), 30.5);
            var waiter3 = new Waiter("Zygmunt", "Krasiński", phoneNumbers3, new DateTime(2020, 7, 20), 31);
            var waiter4 = new Waiter("Cyprian Kamil", "Norwid", phoneNumbers4, new DateTime(2018, 12, 1), 40);

            // ObjectPlus.ShowExtent(typeof(Waiter));

            Employee.setMaxHourlyRate(50);
            
            // Menu menu = new Menu(new List<Meal>());
            // menu.PrintMenu();
            
            // Asocjacja, Pracownik - Lokal
            // Console.WriteLine("Asocjacja \n");
            try
            {
                local1.AddEmployee(waiter1);
                local1.AddEmployee(waiter2);
               
                local2.AddEmployee(waiter3);
                local2.AddEmployee(waiter4);
            
                local2.RemoveEmployee(waiter3);
            } catch(Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }

            // Asocjacja z atrybutem, Zamówienie - Pozycja w menu
            // Console.WriteLine("Asocjacja z atrybutem \n");
            var spaghetti = new MenuItem(
                "Spaghetti", 
                "Cheesecake oat cake lollipop tiramisu lollipop halvah chocolate cake dessert chupa chups. Brownie muffin candy. Tootsie roll carrot cake lemon drops cheesecake marshmallow. Dragée pastry cheesecake marshmallow oat cake macaroon wafer I love. Wafer pudding lemon drops I love brownie wafer. Gingerbread marzipan wafer wafer I love carrot cake jelly. Apple pie cookie sugar plum wafer pie wafer I love sweet roll. Cupcake gingerbread apple pie I love jelly-o gingerbread. Lemon drops jelly beans I love chocolate cake. Cupcake soufflé sesame snaps dragée candy lollipop. Tootsie roll tiramisu apple pie chupa chups cotton candy jelly beans sugar plum apple pie. Macaroon wafer chocolate tootsie roll. Cupcake chocolate danish. Chocolate bar cotton candy pastry sweet chocolate bar dragée bear claw jujubes brownie. Gummies sweet jelly-o tart gummies. Fruitcake jelly dessert lemon drops sugar plum sweet oat cake cookie gummi bears. Halvah jelly beans sesame snaps cake.", 
                28.00);
            var wine = new MenuItem("Glass of a red wine", "Cupcake tart tart wafer bonbon. Macaroon chocolate candy cookie jujubes gummi bears I love halvah. Cookie dragée cotton candy. Donut gummies sugar plum marzipan cake.", 13.00);
            var broccoliSoup = new MenuItem("Broccoli soup", "Marzipan powder marshmallow. Bonbon I love gummi bears liquorice cotton candy marzipan icing cake gummies. I love icing bear claw. Candy canes pie marzipan candy cake pie.", 25.00);
            
            var order1 = new Order();
            var order2 = new Order();
            var order3 = new Order();
            
            try
            {
                var orderMenuItem1 = new OrderMenuItem(spaghetti, order1, 1);
                var orderMenuItem2 = new OrderMenuItem(wine, order2, 3);
                var orderMenuItem3 = new OrderMenuItem(broccoliSoup, order3, 2);
                
                // test czy dana para już istnieje
                // new OrderMenuItem(spaghetti, order1, 2);
                
                var orderMenuItem4 = new OrderMenuItem(spaghetti, order2, 5);
                var orderMenuItem5 = new OrderMenuItem(wine, order1, 2);
                var orderMenuItem6 = new OrderMenuItem(broccoliSoup, order1, 3);

                // Console.WriteLine(orderMenuItem1);
                // Console.WriteLine(orderMenuItem2);
                // Console.WriteLine(orderMenuItem3);
                // Console.WriteLine(orderMenuItem4);
                // Console.WriteLine(orderMenuItem5);
                // Console.WriteLine(orderMenuItem6);
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
            
            // Asocjaca kwalifikowana, Kelner - Zamówienie
            // Console.WriteLine("\n Asocjacja Kwalifikowana\n");
            try
            {
                waiter1.AddOrderQualif(order1);
                // waiter1.AddOrderQualif(order1);
                waiter1.AddOrderQualif(order2);
                // waiter2.AddOrderQualif(order2);

                var o1 = waiter1.FindOrderQualif(order1.GetId());
                var o2 = waiter1.FindOrderQualif(order2.GetId());
                // var o3= waiter1.FindOrderQualif(order3.GetId());
                // Console.WriteLine(o1.ToString());
                // Console.WriteLine(o2.ToString());
            } 
            catch(Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
            
            // Kompozycja, Zamówienie - Rachunek, realizwone przez klasę wewnetrzną
            // Console.WriteLine("Kompozycja\n");
            // Bill.CreateBill(null, 234, 4, 23);
            Bill.CreateBill(order1, 120, 10, 30);
            Bill.CreateBill(order1, 90, 5, 20);
            Bill.CreateBill(order1, 90, 5, 20);
            Bill.CreateBill(order2, 120, 10, 30);
            Bill.CreateBill(order2, 90, 5, 20);
            
            // order1.ShowBills();
            // order2.ShowBills();
            // order1.Remove();
            // order1.ShowBills();
            // order2.ShowBills();
            
            
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
