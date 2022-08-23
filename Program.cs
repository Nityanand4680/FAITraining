using System;

namespace SampleConApp
{
    class FirstProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hello world");
            Console.WriteLine("My Name is Phaniraj");
            Console.WriteLine("I am from Bangalore");
            Console.WriteLine("I am available at phanirajbn@gmail.com");
            Console.WriteLine();
            Console.WriteLine("My Name is Phaniraj\nI am from Bangalore\nI am available at phanirajbn@gmail.com");
            //Using \n U can move the statement to the next line. 

            Console.WriteLine("Enter the Name");
            var name = Console.ReadLine();//ReadLine is a static method of the Console Class used to read the text entered by the User in the Console and returns a String representation of it. 

            Console.WriteLine("Enter the Address");
            var address = Console.ReadLine();

            Console.WriteLine("Enter the Email");
            var email = Console.ReadLine();

            Console.WriteLine($"The Name entered is { name} and he is from {address} and he can be contacted at {email}");//Placing string literals with variable data. 
        }
    }
}//To execute the program: Ctrl+F5