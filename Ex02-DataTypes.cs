using System;
/*
 * Data Types in C# are based on Common Type System(CTS) provided by .NET. The CTS contains the data types that all programming languages of .NET that it supports. 
 * There are 2 classifications: Value Types(Primitive Types) and Reference Types(Classes)
 * Primitive types or Value Types are those data types that are common in most of the languages as they store the value in their variables. 
 * Integral Types: byte, short, int, long
 * Floating Types: float, double, decimal(128)
 * Other Types: char, bool
 * User Defined Types: struct, enums
 * The C# keywords for these data types have a matching Struct in .NET CTS. U can use either of them, but recommended to use the Keyword.
 * Every Value type has a method called Parse that is used to convert a String to its type. 
 */
namespace SampleConApp
{
    class DataTypesDemo
    {
        static void processFunc(double value1, double value2, string operation)
        {
            switch (operation)
            {
                case "+":
                    Console.WriteLine($"The added value is {value1 + value2}");
                    break;
                case "-":
                    Console.WriteLine($"The Subtracted value is {value1 - value2}");
                    break;
                case "X":
                    Console.WriteLine($"The Multiplied value is {value1 * value2}");
                    break;
                case "/":
                    Console.WriteLine($"The Divided value is {value1 / value2}");
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
        static double inputDouble(string question)
        {
            Console.WriteLine(question);
            return double.Parse(Console.ReadLine());
        }
        static string inputString(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

       
        static void Main(string[] args)
        {
            var value1 = inputDouble("Enter the first value");      
            var value2 = inputDouble("Enter the second value");
            var choice = inputString("Enter the choice as +, - X or /");
            processFunc(value1, value2, choice);    
        }
    }  
}
/*
 * If UR Project has more than one Entry points in multiple classes, then U can set the Class to start by selecting Project Menu->Properties->StartUp Object->Choose the Class that U want to start. This setting will only set the Entry point for UR Application. 
 */