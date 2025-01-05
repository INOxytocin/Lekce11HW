using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;


namespace Lekce11HW
{
    internal class Product
    {
        public string Name {  get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        public Product(string name, int price, int quantity) 
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
        public override string ToString()
        {
            return "Product Name: " + Name + " | Price: " + Price + " | Quantity: " + Quantity;
        }
    }
}
