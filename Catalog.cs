using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Lekce11HW
{
    internal class Catalog
    {
        public List<Product> Products { get; set; }

        public Catalog()
        {
            Products = new List<Product>();
        }    

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }
        public List<string> SerializeProductToJSON()
        {
            List<string> result = new List<string>();
            foreach (Product product in this.Products)
            {
                string jsonSerialized = JsonSerializer.Serialize(product);
                result.Add(jsonSerialized);

            }
            Console.WriteLine("\nSerialized\n");
            return result;
        }
        public void DeserializeJSONToProduct(List<string> jsonList)
        {
            foreach (string jsonSerialized in jsonList)
            {
                Product deserializedProduct = JsonSerializer.Deserialize<Product>(jsonSerialized);
                Products.Add(deserializedProduct);

            }
        }










        public int Count()
        {
            return Products.Count;
        }
    }
}
