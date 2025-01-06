using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Lekce11HW.Exceptions;


namespace Lekce11HW
{
    internal class Product
    {
        int _price;
        public string Name {  get; set; }
        protected int Price
        {
            get => _price;
            set
            {
                try
                {
                    if (_price < 0)
                    {
                        throw new InvalidProductException("The price of a product cannot be invalid");
                    }
                    else
                    {
                        _price = value;
                    }
                }
                catch(InvalidProductException ex)
                {
                    Console.WriteLine("InvalidProductException " + ex.Message);
                    throw;

                }
                catch (Exception ex)
                {

                    Console.WriteLine("Unknown Error " + ex.Message);
                    throw;
                }
                
            }
        }
        public int Quantity { get; set; }

        public Product(string name, int price, int quantity) 
        {
            Quantity = quantity;
            Name = name;
            try
            {
                if (price >= 0)
                {
                    Price = price;
                }
                else { throw new InvalidProductException("The price of a product cannot be negative"); }
                
            }
            catch(InvalidProductException ex) 
            {
                Console.WriteLine("Invalid constructor argument " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {

                Console.WriteLine("Unknown Error " + ex.Message);
                throw;
            }
            
        }
        public Product()
        {

        }
        public override string ToString()
        {
            return "Product Name: " + Name + " | Price: " + Price + " | Quantity: " + Quantity;
        }
    }
}
