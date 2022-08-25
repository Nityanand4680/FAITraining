using System;
/*
 * Abstract classes: Abstract classes are classes that has one or more abstract methods. 
 * Abstract method is a method that contains the declaration of the function with no implementation in it. 
 * The derived classes will-must implement the abstract methods using override keyword. 
 * Abstract classes are incomplete classes. They cannot be instantiated. 
 * The Abstract classes are instantiated using the derived class objects using Substitution principle. 
 */
namespace SampleConApp
{
    abstract class Account
    {
        public int AccountNo { get; set; }
        public string HolderName { get; set; }
        public double Balance { get; private set; } = 10000;//New in C# 6 where we can set default value to props. 
        public void Credit(double amount) => Balance += amount;

        public void Debit(double amount)
        {
            if (Balance < amount)
            {
                throw new Exception("Insufficient funds!!!");
            }
            Balance -= amount;
        }

        public abstract void CalculateInterest();
        
    }

    class SBAccount : Account
    {
        //If a class inherits from an Abstract class, it must implement all the abstract methods. 
        public override void CalculateInterest()//override for implementing abstract methods...
        {
            double principle = Balance;
            double rate = 0.065;
            double term = 0.5;// Half yearly

            var interest = principle * rate * term;
            Credit(interest);
        }
    }
    class AbstractClassExample
    {
        static void Main(string[] args)
        {
            Account acc = new SBAccount();
            acc.AccountNo = 123;
            acc.HolderName = "Test Name";
            acc.CalculateInterest();
            Console.WriteLine("The Current balance: " + acc.Balance);
        }
    }
}