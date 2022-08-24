using System;
/*
 * Methods are functions within a class that are used to execute a block of statements that are repeated used in the application. 
 * There are 2 types of methods in .NET: Static and Non Static. Also called as Static and Instance methods. 
 * Static methods are methods that dont need a class instance to call it. 
 * Instance methods need an object instance of the class to call it. 
 * We use instance methods for manipulating the data of the class, static methods are more like global functions as we use them with the name of the class which is same across the Application. 
 * U cannot call instance methods in static methods, if required, then U must create the instance of the class and thru' it, U can call the instance methods
 * Static methods can be called in the instance methods and without the name of the class if it is in the same class. 
 * If a function is frequently called across the application, it is optimized to make it static and call it using its classname. 
 * If a class is created with only static members in it, U can make that class as static. This will ensure that no instance can be created for that class. 
 * An instance method is used mainly to alter the instance data of the class. Instance data is unique to the instance of the class and will not affect other instances and their data. 
 * Static method maintain singleton scope, they will have only one reference across the application. 
 */
namespace SampleConApp
{
    class TestClass
    {
        public static void TestFunc()
        {
            Console.WriteLine("Test static function");
            TestClass cls = new TestClass();//Non static methods need an instance to call them in a static method.
            cls.InstanceTestFunc();
        }
        public void InstanceTestFunc() => Console.WriteLine("Instance Test function");

    }
    class Ex10_Methods
    {
        static void Main(string[] args)
        {
            TestClass.TestFunc();
            
            TestClass instance = new TestClass();
            instance.InstanceTestFunc();
        }
    }
}
/*
 * Copy the Util class from the previous Example and make it static class.
 * Try to create a non-static method in it. 
 * Try to create the instance of the Util class. Note down the observations. 
 */