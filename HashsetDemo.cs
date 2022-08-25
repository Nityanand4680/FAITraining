using SampleConApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecapConApp
{

    class HashsetDemo
    {
        static HashSet<Product> cart = new HashSet<Product>();
        const string menu = "----------------------FLIPKART APP------------------------\nTO ADD TO CART------->PRESS 1\nTO DISPLAY ALL ITEMS------------->PRESS 2\nPRESS ANY OTHER KEY TO EXIT.....................";
        static void Main(string[] args)
        {
            bool looping = true;
            do
            {
                int choice = Util.GetNumber(menu);
                looping = processMenu(choice);
                Console.Clear();
            } while (looping);
        }

        private static bool processMenu(int choice)
        {
            if (choice == 1)
            {
                addingFeature();
            }
            else if (choice == 2)
            {
                displayingFeature();
            }
            else
                return false;
            return true;
        }

        private static void displayingFeature()
        {
            foreach (var item in cart)
            {
                Console.WriteLine(item);
                Console.WriteLine("The HashCode: " + item.GetHashCode());
            }
            Console.ReadKey();
        }

        private static void addingFeature()
        {
            //Get the Name from the user, price from the user, quantity from the user,
            var name = Util.GetString("Enter the Name of the Product to add");
            var price = Util.GetNumber("Enter the price of the product");
            var quantity = Util.GetNumber("Enter the Quantity of the Product U want to purchase");
            //Create the Product object
            var product = new Product { Price = price, ProductName = name, Quantity = quantity };
            //Add the Product object to the Set.
            cart.Add(product);
            //Display the Happy message
            Console.WriteLine("Product added succesfully to the cart");
        }
    }
}
