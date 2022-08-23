using System;
/*
 * string is a reference type in C#. It is an object of a class called System.String. 
 * strings are immutable in nature. If U assign a value to a string variable, it creates a new string object and assigns the value to the variable.
 * string is internally an array of charecters. So like Array, U have methods like Length to get the no of charecters of the string. U can access each charecter using [index] operator.
 * string comes with functions to split, to check if a string sequence exists, convert to different cases and many more. 
 */
namespace SampleConApp
{
    class StringsExample
    {
        static void displaySelectedNames()
        {
            string[] names = { "Phaniraj", "Vinod", "Banu Prakash", "Ramanath", "Vidya", "Aruna", "Zaheer", "Sumana", "Ravi", "David", "Syed", "Pavan Kumar", "Puyush", "Rahul", "Sourav" };
            Console.WriteLine("Enter the Name to search");
            string search = Console.ReadLine();
            foreach (string name in names)
            {
                if(name.StartsWith(search))
                    Console.WriteLine(name);
            }
        }
        static void displayInUppercase()
        {
            //create an Array of strings
            string[] names = { "Phaniraj", "Vinod", "Banu Prakash", "Ramanath", "Vidya", "Aruna", "Zaheer", "Sumana", "Ravi", "David", "Syed", "Pavan Kumar" };
            Console.WriteLine("-------------------DISPLAY ALL NAMES-----------------");

            //Display each string in Upper case
            foreach (string name in names)
                Console.WriteLine(name.ToUpper());
            Console.WriteLine("-------------------END OF NAMES-----------------");
        }

        static void basicStringExample()
        {
            string fruitName = "Apple";//creates a new string and assigns the value to the fruitName
            fruitName = "Mango";//Mango is a new string assigned to the fruitName. 

            string allFruits = fruitName + " Apple " + " Orange " + " Banana ";

            Console.WriteLine("-------------------DISPLAY ALL CHARECTERS-----------------");
            foreach (char val in allFruits)
                Console.WriteLine(val);
            Console.WriteLine("-------------------END OF DISPLAY ALL CHARECTERS-----------------");

        }
        static void Main(string[] args)
        {
            //basicStringExample();
            //displayInUppercase();
            displaySelectedNames();
        }
    }
}