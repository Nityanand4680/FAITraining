using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Inheritance is based on the Open-Closed Principle of SOLID Principles. 
 * C# supports single inheritance, a class can be derived from a single base class at any level. 
 * C# supports Multi-level Inheritance, not multiple inheritance. 
 * There is no access specifier for inheritance, C# supports general inheritance => All members of the base class retain their access modifiers in the derived class. 
 */
namespace SampleConApp
{
    class BaseClass
    {
        public void BaseFunc() => Console.WriteLine("Base Func");
    }

    class DerivedClass : BaseClass
    {
        public void DerivedFunc() => Console.WriteLine("Derived Func");

    }
    class Ex12_InheritanceDemo
    {
        static void Main(string[] args)
        {
            //DerivedClass cls = new DerivedClass();
            //cls.BaseFunc();
            //cls.DerivedFunc();

            BaseClass cls = new BaseClass();
            cls.BaseFunc();


            cls = new DerivedClass();
            cls.BaseFunc();
            //to call the derived functions U should do type casting...

            if(cls is DerivedClass)
            {
                DerivedClass clsCopy = cls as DerivedClass;
                clsCopy.DerivedFunc();
            }
        }
    }
}
