using System;
/*
 * A Class is a User defined Type(UDT) that can contain data members as well as functions.
 * Classes allow U to create Composite types that can hold data of different data types representable as one Unit. They are used to represent real world objects. 
 * A Class will contain a Defn and an Instance will be created for that class. The instance of the class is called as OBJECT. In other words, an object is a variable of the class.  
 * A Class can have fields to represent data, methods to manipulate fields or data, properties as accessors to data. U can also have events(Actions that can be performed on the data). 
 * From C# 4, U can also have nested classes. 
 * With classes, comes a host of OOP features like Inheritance, Polymorphism, Encapsulation as well as Abstraction. 
 * There can be different kinds of classes based on how U want to use them.
 * Entity classes represent real world entities for the Application
 * Data Classes represent the data of the Application which includes persistance(SAVING). 
 * UI Classes that will interact with User and represent the User interface of the Application. 
 * Utility Classes that are used for logging, General Messaging that are used across the Application. 
 * Finally all classes are expected to represent an User defined type which are used using Objects. 
 */
namespace SampleConApp
{
    class Employee
    {
        public int Id;
        public string Name;
        public string Email;
        public string Address;
    }

    class ClassesAndObjects
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee();
            emp.Address = "Bangalore";
            emp.Name = "Phaniraj";
            emp.Email = "phanirajbn@gmail.com";
            emp.Id = 123;

            Console.WriteLine($"The name is {emp.Name} from {emp.Address} and has an email Address as {emp.Email}");
        }
    }
}