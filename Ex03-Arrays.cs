using System;

namespace SampleConApp
{
    class ArraysDemo
    {
        static void Main(string[] args)
        {
            //firstDemo();
            //newSyntaxExample();
            // multiDimensionalArrayExample();

            //jaggedArrayExample();

        }

        private static void jaggedArrayExample()
        {
            //Array of arrays is called Jagged Array.
            //Here U have n no of rows but different no of columns in each row. Here each row represents an array..

            int[][] school = new int[4][];//No of rows is 4
            school[0] = new int[] { 45,56,78 };
            school[1] = new int[] { 12,45,66,54,34 };
            school[2] = new int[] { 12,45,67,89,97,77,67 };
            school[3] = new int[] { 45 };
            Console.WriteLine("-------------Displaying Jagged Array in MATRIX Format-------");
            //Its an array of arrays, so using foreach to iterate thro rows and then another foreach to iterate thro each row.
            //foreach(var row in school)
            //{
            //    foreach(var col in row)
            //        Console.Write(col+ " ");
            //    Console.WriteLine();
            //}
            for (int i = 0; i < school.Length; i++)
            {
                for (int j = 0; j < school[i].Length; j++)
                {
                    Console.Write(school[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        //GetLength gets the length of the Specific Dimension in the array
        private static void multiDimensionalArrayExample()
        {
            //int[,] TwoDArray = new int[2, 3];
            //for (int i = 0; i < TwoDArray.GetLength(0); i++)
            //{
            //    for (int j = 0; j < TwoDArray.GetLength(1); j++)
            //    {
            //        Console.WriteLine($"Enter the value for {i},{j}th position");
            //        TwoDArray[i, j] = int.Parse(Console.ReadLine());
            //    }
            //}///Use this syntax for taking inputs from the user...

            int[,] TwoDArray = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };
            Console.WriteLine("The no of dimensions is " + TwoDArray.Rank);
            Console.WriteLine("-------------------All values are set-------------");
            for (int i = 0; i < TwoDArray.GetLength(0); i++)
            {
                for (int j = 0; j < TwoDArray.GetLength(1); j++)
                {
                    Console.Write(TwoDArray[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("-----------------------End of the Program--------------");
        }

        static void newSyntaxExample()
        {
            int[] numbers = { 12, 14, 15, 34, 23, 56 };//shorter syntax of arrays. 
            foreach (var number in numbers) Console.WriteLine(number);
        }

        static void firstDemo()
        {
            //datatype [] name = new datatype[size];
            Console.WriteLine("Enter the size");
            int size = int.Parse(Console.ReadLine());
            string[] myTeam = new string[size];
            Console.WriteLine("----------------Data Entry has begun!!!!---------------");
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("Enter the Name");
                myTeam[i] = Console.ReadLine();
            }
            Console.WriteLine("----------------All the data is entered!!!!---------------");

            Console.WriteLine("-----------------Displaying the values of the Array----------------------");
            foreach (var member in myTeam)
            {
                Console.WriteLine(member);
            }
        }
    }
} 

/*
 * Array is a fixed size collection.
 * Once U declare an array, its size cannot be modified, in that case, U must create a new array and set the values. 
 * Arrays does not allow to dynamically change its size. 
 * It is the most optimized way of working with collections. 
 * U can get the no of dimensions of an array using Rank property
 * U can get the total no of elements of an array using Length property. 
 * U can get the no of elements of each dimension using GetLength Function that takes an arg of the dimension index. 
 * CopyTo, Clone and Copy methods to copy the contents of one array into another. 
 * All arrays are objects of a .NET Class called System.Array
 * U can use the Array Class to create an Array dynamically.
 */