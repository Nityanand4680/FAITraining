using System;
/*
 * An Exception is a scenario where the Application will not go futher because of some abnormal condition for which the App does not want to execute further. 
 * In .NET, Exceptions are objects of a class derived from System.Exception, the base class for all kinds of exceptions in .NET Runtime. There are 2 types: System Exceptions and Application Exceptions. Application Exceptions are the one that are created for Applications by the developers. 
 * Exceptions throw by the System are expected to be caught by the Developer and resolve it.Abnormal terminations is not a good feature of any Application. Any Exception must be caught and handled. THis is called EXCEPTION HANDLING.
 * there are 3 keywords for handling Exceptions: try, catch and finally. 
 * try block contains the code that might raise an Exception. 
 * If an Exception is throw by the Code, U catch using catch block. U can optionally pass the type of exception as arguement to the catch block. U can have multiple catch blocks for a given try. 
 * U can also have an optional finally block which is a section of code that is executed on all conditions. 
 * A try can have either a catch or a finally or both. 
 * 
 */
namespace SampleConApp
{
    class Ex16_ExceptionHandling
    {
        static void basicTryCatch()
        {
        RETRY:
            Console.WriteLine("Enter a Number");
            int no = 0;
            try
            {
                no = int.Parse(Console.ReadLine());
            }
            catch (FormatException fEx)
            {
                Console.WriteLine($"Error Message by the System: {fEx.Message}");
                Console.WriteLine($"Source of the Error: {fEx.Source}");
                Console.WriteLine($"Stack Trace: {fEx.StackTrace}");
                //Console.WriteLine("Input should be a whole number");
                goto RETRY;
            }
            catch (OverflowException)
            {
                Console.WriteLine($"The value of a number should be within {int.MinValue} and {int.MaxValue}");
                goto RETRY;
            }
            Console.WriteLine("The input value is " + no);
        }
        static void Main(string[] args)
        {
            basicTryCatch();
            //usingTryParse();
        }

        private static void usingTryParse()
        {
            int value;
            var processing = true;
            do
            {
                Console.WriteLine("Enter the number");
                processing = int.TryParse(Console.ReadLine(), out value);
            } while (processing == false);
            Console.WriteLine("The value is " + value);
        }
    }
}
