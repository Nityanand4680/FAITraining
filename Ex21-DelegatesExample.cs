/*
 * Delegates are functional References that can be used to pass function as an argument to a function. 
 * Realtime, we use them to create Callback functions, Event Handlers, Search Criteria Functions, Multi Threading Apps and many more. 
 * Normally functions will create parameters in the form of variables of a data type. In some scenarios, U would pass a variable(Reference) of a FUNCTION. The declaration of a Function signature is what is called as Delegate
 * All Delegates are reference types.
 * The Function that is passed as arg for the delegate instance must have the same signature of a the delegate. 
 * .NET Gives 2 Generic Delegates called Func<T> and Action<T> where Func is used for Non-void functions and Action is used for void Functions. 
 * Some of the popular .NET Provided Delegtes: Action, Func(Generic Delegates), Predicate(Finding in Collections), ThreadStart(Thread based), EventHandler(Windows and Web Event Handling)
 * U can create delegate instances that can point to multiple functions at a time using Multicast Delegate. 
*/

using System;

namespace SampleConApp
{
    delegate void FuncReference();

    class Demo
    {
        public static void CallFunc(FuncReference func)
        {
            //Some work
            Console.WriteLine("This function is called by the User of the Function");
            func();         
        }

        //Use the built in delegate of .NET called Action. This method will be a void method.
        public static void CallFuncWithAction(Action method)
        {
            Console.WriteLine("Action method is called");
            if (method != null) method();
        }
        public static void CallActionFuncWithArgs(Action<string, int> func)
        {
            Console.WriteLine("Action method with args of string and int is called");
            string firstParameter = Util.GetString("Enter the string for first Param");
            int secondParameter = Util.GetNumber("Enter the int for second Param");
            func(firstParameter, secondParameter);
        }

        public static void CallFuncWithArgs(Func<double, double, double> func)
        {
            var fValue = Util.GetDoubleNumber("Enter the first value");
            var sValue = Util.GetDoubleNumber("Enter the second value");
            var res = func(fValue, sValue);
            Console.WriteLine("The result: " + res);
        }
    }
    
    class DelegateExample
    {
        static double addFunc(double v1, double v2)
        {
            return v1 + v2;
        }
        static void TestFunc() => System.Console.WriteLine("Test Func");

        static void AnotherFunc(int arg) => System.Console.WriteLine("Anothe Func with arg " + arg);

        static void ActionFunc(string arg1, int arg2)
        {
            for (int i = 0; i < arg2; i++)
            {
                Console.WriteLine(arg1);
            }
        }
        static void Main(string[] args)
        {
            //////////////Trying various kinds of Delegates: Custom, Action, Action<T> and Func<T1, T2, T3>
            //Demo.CallFunc(TestFunc);
            //Demo.CallFuncWithAction(TestFunc);

            //Action<string, int> funcName = new Action<string, int>(ActionFunc);
            //Demo.CallActionFuncWithArgs(funcName);//Old syntax

            //Demo.CallActionFuncWithArgs(ActionFunc);//New syntax

            //Demo.CallFuncWithArgs(addFunc);//For Action<double, double, double>

            ///////////////////Using Anonymous method syntax in place of creating Explicit Fns/////////////
            //Demo.CallFuncWithArgs(delegate (double v1, double v2)
            //{
            //    return v1 - v2 + (v1 * v2) / v2;
            //});

            /////////////////////Using Lambda Expressions in place of Anonymous methods/////////////
            //Demo.CallFunc(() => Console.WriteLine("CallFunc is calling my Func"));
            //Demo.CallFuncWithAction(() => Console.WriteLine("Action Method"));
            //Demo.CallActionFuncWithArgs((str, i)=> Console.WriteLine("str: " + str ));

            //Demo.CallFuncWithArgs( ( v1,  v2)  => v1 * v2);
            //////////////////////////MultiCast Delegate///////////////////////////////////////////
            Action delInstance = () => Console.WriteLine("Test Code 1st Func");
            delInstance += () => Console.WriteLine("Another Code 2nd Func");
            delInstance += () => Console.WriteLine("Another Code 3rd Func");
            delInstance += () => Console.WriteLine("Another Code 4th Func");
            
            delInstance();

            Func<int> func = () => 123;
            func += () => 456;
            func += () => 654;
            func += () => 321;
            int result = func();
            Console.WriteLine(result + " is the value which will contain the result of the last method of the list");
            //To get the result of each function in the multicast delegate:
            var methods = func.GetInvocationList();//GetInvocationList will work for Multicast Delagates only. 
            foreach(var instance in methods)
            {
                int res = (int)instance.DynamicInvoke();
                Console.WriteLine(res + " from " + instance.Method.Name);
            }

        }
    }
}