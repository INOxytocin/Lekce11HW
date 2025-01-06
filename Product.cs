using System;
using System.Collections.Generic;
using System.Text.Json;
using Lekce11HW.Exceptions;

namespace Lekce11HW
{
    internal class Product
    {
        private int _price;
        public string Name {get; set; }

        public int Price
        {
            get => _price;
            set
            {
                try
                {
                    if (value < 0)
                    {
                        throw new InvalidProductException("The price of a product cannot be negative");
                    }
                    _price = value;
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
            Name = name;
            try
            {
                Price = price; 
                Quantity = quantity;
            }
            catch(InvalidProductException ex)
            {
                Console.WriteLine("Invalid constructor argument " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unknown Error " + ex.Message);
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
