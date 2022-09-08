using SampleDll;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TestApp
{
    class MainClass
    {
        static void Main(string[] args)
        {
            try
            {
                TestDataComponent com = new TestDataComponent();
                var test = com.FindTest(2);
                Console.WriteLine(test.TestName); 
            }
            catch (MyTestException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
/*
 * Project Type: Class Library
 * Components should be public.
 * It will not execute. 
 * 
 * Consume the dll:
 * Add the reference of the DLL into UR Current Project
 * Use the namespace of the DLL classes.
 * Consume it as if its in ur Project itself 
 * Create a DLL that has a class called MathComponent
 * It should have a function called AddFunc
 * Consume it in a Console App. 
 */