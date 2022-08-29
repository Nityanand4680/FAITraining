/*
 * .NET has its own automatic memory management handled by CLR. 
 * All Code written in .NET Framework will be handled by the CLR. The Developer has no control on object deletion. 
 * Developers create objects using new operator but do not have any API to explicitly delete it. 
 * Desctructor will be called implicitly by the CLR when the object is destroyed. U cannot explicitly destroy an object or call destructor in UR Code. It is more like a clean up operation. Internally Destructor is converted to a Finalizer function by the CLR which means that this code is the final execution of the object. 
 * U can ask the GC to collect the unused objects by calling an API GC.Collect. Anyways, U cannot specify the object name to be destroyed in it. 
 * GC cleans up the unused objects by creating creating a seperate thread and does that parallely. 
 * When U call the APIs of Unmanaged code(C++ DLLs,COM DLLs) in .NET U may have to destroy the Unmanaged objects explicitly. For that, UR Class can implement an interface called IDisposable and implement Dispose method where U can explicitly destroy the Unmanaged resources. 
 * Caller of the objects created from the classes implementing IDisposable must call the Dispose method once the work with the unmanaged objects are completed. 
 */


using System;
using System.Threading;

namespace SampleConApp
{
    class Radio
    {
        private string _name;
        public Radio(string name)
        {
            _name = name;
        }
        public void PlayMusic()
        {
            Console.WriteLine("Music is playing in " + _name);
        }
    }
    class Car
    {
        public Radio myEntertainment { get; set; }
        public Car()
        {
            myEntertainment = new Radio("SONY");
        }

        public Car(string radioName)
        {
            myEntertainment = new Radio(radioName);
        }
        public void Play()
        {
            Console.WriteLine("The Car now starts the Entertainment Device");
            myEntertainment.PlayMusic();
        }
    }
    class Data : IDisposable
    {
        private int arg = 132;
        //Its a function used to construct an object.  U can use this function to inject the dependencies for UR Class.
        public Data(int arg)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            this.arg = arg;//this operator is used to resolve the local variable and field of the class. 
            Console.WriteLine($"The object with Id {arg} is created");
            Console.ForegroundColor = ConsoleColor.Black;
        }

        ~Data()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"The object with Id {arg} is destroyed");
            Console.ForegroundColor = ConsoleColor.Black;
        }

        public void Dispose()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"The object with Id {arg} is destroyed");
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
    class GarbageCollectionDemo
    {
        static void createAndDestroyObjects()
        {
            for (int i = 1; i <= 5; i++)
            {
                using(Data data  = new Data(i))//By using the using block, the Runtime will call the object's Dispose method internally if it exists. 
                {
                    Thread.Sleep(1000);
                    GC.SuppressFinalize(data);
                }
                //Data data = new Data(i);
                //data.Dispose();
                //GC.SuppressFinalize(data);//Ensures that the Destructor of the object will not be called when it is deleted. 
                //GC.Collect();//Forces the GC to clean up the memory asynchronously. 
                //GC.WaitForPendingFinalizers();
            }
            Console.WriteLine("All object creations are completed");
        }
        static void Main(string[] args)
        {
            //Console.WriteLine("Which radio U want?");
            //string type = Console.ReadLine();
            //Car car = new Car(type);//Constructor Injection
            ////car.myEntertainment = new Radio("JBL"); //Property injection
            //car.Play();
            createAndDestroyObjects();
            Console.WriteLine("[MAIN] has ENDED!!!!!Time to terminate the App");
        }
    }
}