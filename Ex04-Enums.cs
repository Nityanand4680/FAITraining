using System;
/*
 * Enums are user defined data types that work like named consts. 
 * They hold integral values but can be refered by names.
 * They start with 0 and increment by 1, hense the name Enum. However, U can change the start value to any integral value. 
 * THere is a class called Enum that can be used to get info about UR Custom Enums.
 * GetValues method is used to get the possible values of an Enum type.
 * Parse method is used to convert the string value to the Enum Type. U should convert to the Enum type using typecasting. 
 */
namespace SampleConApp
{
    enum Months
    {
        Jan = 1, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep,Oct, Nov, Dec
    }
    class EnumsExample
    {
        static void Main(string[] args)
        {
            firstExample();

            displayAllMonths();
            //string enteredValue = Console.ReadLine();//Not Required to store into variable
            Months month = (Months)Enum.Parse(typeof(Months),Console.ReadLine() , true);
            //Enum.Parse will return the converted value as object, the super base class of all types in .NET. So, U should typecast to the Months type using C Style Casting. 
            Console.WriteLine("The selected month is " + month);
        }

        private static void displayAllMonths()
        {
            Months month = (Months)1;
            Console.WriteLine($"Please enter the {month.GetType().Name} from the list below");
            Array months = Enum.GetValues(typeof(Months));
            foreach (var m in months) Console.WriteLine(m);
        }

        private static void firstExample()
        {
            Months month = Months.Feb;
            Console.WriteLine("The month value is " + month);
            Console.WriteLine($"The internal value is {(int)month}");//U converted the month to a number using C style casting. 
        }
    }
}