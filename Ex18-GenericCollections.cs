using System;
using System.Collections.Generic;

/*
 * A Program to take input from the user to add a value and display the values in a menu driven app
 * A Program to store Products into a Cart App and display the items using HashSet. 
 */
namespace SampleConApp
{
    class GenericCollections
    {
        static void displayInForEachLoop(List<string> data)
        {
            Console.WriteLine("-----------------Names in ForEach Loop----------------");
            foreach (var name in data) Console.WriteLine(name);
            Console.WriteLine("---------------------End of Loop-------------------");

        }
        static void displayInForLoop(List<string> data)
        {
            Console.WriteLine("-----------------Names in For Loop----------------");
            for (int i = 0; i < data.Count; i++)
            {
                Console.WriteLine(data[i]);
            }
            Console.WriteLine("---------------------End of Loop-------------------");
        }

        static void Main(string[] args)
        {
            //listExample();
            //productListDemo();
            //setExample();
            dictionaryExample();
        }

        private static void dictionaryExample()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("Apples", "Costly");
            data.Add("Mangoes", "Very Rich");
            data["PineApples"] = "Very Thornly";
            if (data.ContainsKey("Apples"))
            {
                Console.WriteLine("This fruit is already added");
            }
            else
                data.Add("Apples", "Very Tasty");

            foreach(var pair in data)
            {
                Console.WriteLine($"Key: {pair.Key}\tValue:{pair.Value}");
            }
        }

        private static void setExample()
        {
            //set is similar to List but will store only unique values in it.
            HashSet<string> basket = new HashSet<string>();
            basket.Add("Apples");
            if (!basket.Add("Apples"))
            {
                Console.WriteLine("Apples already exists");
            }
            basket.Add("Mangoes");
            basket.Add("Oranges");
            basket.Add("PineApples");
            Console.WriteLine("The Basket Count: " + basket.Count);
        }

        //Using Products in List
        private static void productListDemo()
        {
            List<Product> allProducts = new List<Product>();
            allProducts.Add(new Product { Price = 5000, ProductName = "Cricket Bat", Quantity = 50 });
            allProducts.Add(new Product { Price = 100, ProductName = "Cricket Ball(Red)", Quantity = 150 });
            allProducts.Add(new Product { Price = 150, ProductName = "Cricket Ball(White)", Quantity = 50 });
            allProducts.Add(new Product { Price = 4500, ProductName = "Puma Shoes(FootBall)", Quantity = 100 });
            foreach (var p in allProducts) Console.WriteLine(p);
        }

        private static void listExample()
        {
            List<string> names = new List<string>
            {
                "Anjan", "Kumar", "Ramesh", "Vani", "Aravind", "Ananth", "Sushma"
            };
            names.Add("Anjan");
            names.Add("Vani");
            names.Add("Kumar");
            names.Add("David");
            names.Add("Sushma");
            names.Add("Ramesh");
            names.Add("Venki");
            names.Add("Samarth");
            names.Insert(5, "Mahesh");//Inserting in b/w. The index should be within the range of the current size. 
            Console.WriteLine("The total members in the list is " + names.Count);
            names.Remove("Venki");
            names.RemoveAt(3);//Removes the element in the specified index.
            Console.WriteLine("The total members in the list is " + names.Count);
            displayInForEachLoop(names);
            displayInForLoop(names);
        }
    }
}