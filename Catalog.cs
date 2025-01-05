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

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }
        public int Count()
        {
            return Products.Count;
        }
    }
}
