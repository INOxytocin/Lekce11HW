using System.Text.Json;

namespace Lekce11HW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Randomizace názvů a cen produktů
            List<string> ValuesJSON = new List<string>();
            int randomIndexName;
            int randomIndexPrice;
            var rand = new Random();

            //Hodnoty k randomizaci
            List<string> names = new List<string> { "Laptop", "Phone", "Washing Machine", "Dryer", "Television" };
            List<int> prices = new List<int> { 5000, 10000, 15000, 20000, 25000 };
            Catalog catalog = new Catalog();
            Catalog catalog2 = new Catalog();

            //Print produktu před vložením do katalogu
            for (int i = 0; i < 10; i++)
            {
                randomIndexName = rand.Next(names.Count);
                randomIndexPrice = rand.Next(prices.Count);
                Product product = new Product(names[randomIndexName], prices[randomIndexPrice], rand.Next(1, 10));
                Console.WriteLine(product);
                catalog.AddProduct(product);
            }

            
            ValuesJSON = catalog.SerializeProductToJSON();
            foreach (string jsonString in ValuesJSON)
            {
                Console.WriteLine(jsonString);
            }

            //Vlastní JSON na Deserializaci
            Console.WriteLine("\n/////////////////////////////////////////\n");

            List<string> jsonList = new List<string> { "{\"Name\":\"Some Random Item\",\"Price\":12345,\"Quantity\":5}" };


            catalog2.DeserializeJSONToProduct(jsonList);
            foreach (Product product in catalog2.Products)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine("Exception test");
            List<string> jsonList2 = new List<string> { "{\"Name\":\"Some Random Item\",\"Price\":12345,\"Quantity\":5" };
            List<string> jsonList3 = new List<string> { "{\"Name\":\"Some Random Item\",\"Price\":-12345,\"Quantity\":5}" };

            Console.WriteLine("First");
            catalog2.DeserializeJSONToProduct(jsonList2);
            Console.WriteLine("Second");
            catalog2.DeserializeJSONToProduct(jsonList3);
            foreach (Product product in catalog2.Products)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine(catalog2.Count());



        }
    }
}
