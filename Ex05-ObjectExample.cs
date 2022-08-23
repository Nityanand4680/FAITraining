using System;
/*
 * System.Object or simply object is the super base class of all types in .NET. It is the part of the CTS. object is a reference type. 
 * object is used when U R not sure about the data type at compile time as it can be used to store any kind of data. 
 * all data types can be implicitly converted to object with out any typecasting.
 * This implicit conversion is called as BOXING. Here the actual data type will be boxed(Hidden) from the compiler. 
 * When U want to perform any data type specific operations on the boxed value, U should UNBOX it using typecasting. 
 * The boxed type can be UNBOXED to the same type from which it was BOXED. Else it will throw InvalidCastException. 
 * The process of converting a VALUE TYPE to the Object Type(Reference type) is called BOXING. This is an Implicit Operation.  
 * Value Types are always stored in the Stack Memory and Reference types are stored in the heap memory. 
 * The object type must be unboxed before U try to do any specific operations of the type. This is called UNBOXING which is a explicit operation that is done thru typecasting. 
 * 
 */
namespace SampleConApp
{
    class ObjectDemo
    {
        static void Main(string[] args)
        {
            object value = 123; //int is boxed here.
            //value++; error
            //double tempValue = (double)value;//THIS IS UNBOXING. Will throw an error if U unbox to a different data type other than from what it was boxed
            int tempValue = (int)value;
            ++tempValue;
            value = tempValue;
            Console.WriteLine("The value: " + value);
            value = "Sample Text";
            Console.WriteLine("The value: " + value);
            value = true;
            Console.WriteLine("The value: " + value);
            value = 234.45;
            Console.WriteLine("The value: " + value);
            value = 234.67f;
            Console.WriteLine("The value: " + value);
        }
    }
}