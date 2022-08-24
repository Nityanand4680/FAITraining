using System;
using System.Text; //Used to refer the StringBuilder class in UR Program...
/*
* Parameters are input values that U provide for the function to execute in an expected manner. 
* Parmeters are the dependency injectors for the methods. 
* Parameters in C# are always pass by value unless we use ref or out parameters. 
* We can pass the parameters by reference using ref or out keywords. 
* In pass by ref and pass by out, the reference of the variable will be passed as parameter and any change that is made to the parameter in the function will be reflected on the variable itself. 
* Pass by out vs Pass by Ref: Both have similar functionality. The caller will initialize the values and pass it to the function when ref is used. The Function will/must set the values for the out parameters before the function exits. The caller may or may not initialize the values in Pass By Out. 
* If U have variable no of args to be passed to a function, U can set the variable arg list as params. It will always be an array with params keyword. 
*/
namespace SampleConApp
{
    class Fruit
    {
        public string FruitName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
     class Ex11_Parameters
    {
        static void mathFunc(double v1, double v2, out double addedValue, out double subValue, out double mulVal, out double divVal, out double sqr, out double sqrt)
        {
            //When U have an out parameter, the function must set a value to it. 
            addedValue = v1 + v2;
            subValue = v1 - v2;
            mulVal = v1 * v2;
            divVal = v1 / v2;
            sqr = v1 * v1;//v2 is ignored.
            sqrt = Math.Sqrt(v1);//v2 is ignored.
        }
        static void SimpleFunc(ref int x)
        {
            if (x == 0)
                x = 123;
            Console.WriteLine(x);
        }
        static double addFunc(double v1, double v2)
        {
            var result = v1 + v2;
            return result;
        }
        static void UsingFruit(Fruit fruit)
        {
            if(fruit == null)
            {
                Console.WriteLine("Fruit Details are not set");
                return;
            }
            fruit.FruitName = "Changed Fruit";
            fruit.Quantity = 10;
            fruit.Price = 65;
            Console.WriteLine("Fruit Name: {0}", fruit.FruitName);//Another way of displaying content.
        }
        
        static void Main(string[] args)
        {
            //passByValueFunc();
            //passByRefFunc();
            //passObjectFunc();
            //passByOutFunc();
            AddFunc(12, 13, 14, 67, 56);
            AddFunc(12, 13, 14);
            AddFunc(12, 13, 14, 67, 56, 67, 55, 89);
            DisplayFullName("Bommathanahalli", "Nagendra", "Phaniraj");
        }

        private static void DisplayFullName(params string[] nameParts)
        {
            StringBuilder builder = new StringBuilder("");
            foreach (var name in nameParts)
                builder.Append($"{name} ");
            Console.WriteLine(builder);
        }
        private static void AddFunc(params int [] args)
        {
            var res = 0;
            foreach (var arg in args) res += arg;
            Console.WriteLine("The Total: " + res);
        }

        private static void passByOutFunc()
        {
            double addedValue, subValue, mulVal, divVal = 0, sqr, sqrt;
            mathFunc(123, 23, out addedValue, out subValue, out mulVal, out divVal, out sqr, out sqrt);
            Console.WriteLine("The Added value {0}\nThe subtracted value {1}\n The multiplied value {2}\n Divided Value {3}\nThe Square of {4} is {5}\nThe SquareRoot of {4} is {6}", addedValue, subValue, mulVal, divVal, 123, sqr, sqrt);
        }

        private static void passObjectFunc()
        {
            Fruit fruit = null;
            UsingFruit(fruit);
            if (fruit != null)
                Console.WriteLine("Fruit Name: {0}", fruit.FruitName);//Another way of displaying content.
        }

        private static void passByRefFunc()
        {
            int value = 35;
            SimpleFunc(ref value);
            Console.WriteLine(value);
        }

        private static void passByValueFunc()
        {
            Console.WriteLine("Enter the First value");
            double value1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Second value");
            double value2 = double.Parse(Console.ReadLine());

            var result = addFunc(value1, value2);
            Console.WriteLine("The Result of Addition is " + result);
        }
    }
}
