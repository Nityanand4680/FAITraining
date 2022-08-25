using System;
using System.Data;
/*
 * Interfaces are similar to abstract classes but will have only abstract methods. 
 * Interfaces are more like planning where U dont implement anything here. The class that implements the interface will provide the implementations for all the methods and props declared by the interface. 
 * The class that implements the interface must have public implementation.
 * In C#, interface names are prefixed with I. 
 * U can implement multiple interfaces at the same level. 
 * U can explicitly implement interface methods if there is a conflict in the name of the method coming from different interfaces. 
 */
namespace SampleConApp
{
    interface IEmployee
    {
        void Create();
    }

    interface ICustomer
    {
        void Create();
    }

    class EmployeeCustomer : IEmployee, ICustomer
    {
        #region Explicit Implementation
        void ICustomer.Create()//Should not use any access specifier. 
        {
            Console.WriteLine("Customer is created");
        }

        void IEmployee.Create()
        {
            Console.WriteLine("Employee is created");
        }

        #endregion
        public void Create()
        {
            Console.WriteLine("Customer and Employee are created");
        }
    }
    interface ISimpleInterface
    {
        void SimpleFunction();
    }

    interface IExampleInterface
    {
        void ExampleFunction();
    }

    class SimpleExampleClass : ISimpleInterface, IExampleInterface
    {
        public void ExampleFunction() => Console.WriteLine("Example Function implemented as an Example");

        public void SimpleFunction() => Console.WriteLine("Simple Function implemented in a simple manner");
    }
    class Ex15_InterfacesDemo
    {
        static void Main(string[] args)
        {
            ISimpleInterface simple = new SimpleExampleClass();
            simple.SimpleFunction();

            IExampleInterface example = new SimpleExampleClass();
            example.ExampleFunction();

            SimpleExampleClass simEx = new SimpleExampleClass();
            simEx.SimpleFunction();
            simEx.ExampleFunction();

            IEmployee emp = new EmployeeCustomer();
            emp.Create();

            ICustomer cst = new EmployeeCustomer();
            cst.Create();

            EmployeeCustomer empCst = new EmployeeCustomer();
            empCst.Create();
        }
    }
}
