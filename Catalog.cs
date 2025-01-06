using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Lekce11HW.Exceptions;

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
                Product product = ValidateJSON(jsonSerialized); //Vím, že je to nepraktické, ale rád bych věděl,
                if (product != null)                               //jestli je tohle dobré využítí "out".
                {
                    Products.Add(product);
                }
            }
            Console.WriteLine("\nDeserialized\n");

        }

        private Product ValidateJSON(string jsonSerialized)
        {   

            Product product = null;
            try
            {
                jsonSerialized.Trim();
                Product deserializedProduct = JsonSerializer.Deserialize<Product>(jsonSerialized);
                product = deserializedProduct;
            }
            catch (JsonException ex)
            {
                Console.WriteLine("JSON deserialization error " + ex.Message);
            }
            catch (InvalidProductException ex) //Chtěl jsem dodržel úkol přesně podle zadání, ale přijde mi, že je tu mnou nadefinovaná výjimka k ničemu
            {
                Console.WriteLine("Invalid Product " + ex.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("Unknown Error ");
            }
            return product;
            
        }
        public int Count()
        {
            return Products.Count;
        }
    }
}
