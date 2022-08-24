using System;
namespace SampleConApp
{
    /*
     * If a class is inherited into another, the Super class methods can be modified by the Sub classes using the concept of 
     */

    class Account
    {
        public int AccountNo { get; set; }
        public string HolderName { get; set; }
        public double Balance { get; private set; } = 10000;//New in C# 6 where we can set default value to props. 
        public void Credit(double amount) => Balance += amount;

        public void Debit(double amount)
        {
            if(Balance < amount)
            {
                throw new Exception("Insufficient funds!!!");
            }
            Balance -= amount;
        }

        public virtual void CalculateInterest()
        {
            double principle = Balance;
            double rate = 0.065;
            double term = 0.5;// Half yearly

            var interest = principle * rate * term;
            Credit(interest);
        }
    }

    class FDAccount : Account
    {
        //For a method to be overriden, the methods should have a modifier as virtual, abstract, override....
        public override void CalculateInterest()
        {
            base.CalculateInterest();
            Credit(234);//TO find the formula for calculating Compound interest for the same and crediting it. 
        }
    }

    static class AccountFactory
    {
        public static Account CreateAccount(string accType)
        {
            if (accType.ToLower() == "normal")
                return new Account();
            else
                return new FDAccount();
        }
    }
    class OverridingExample
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the type of account as normal or fd");
            Account acc = AccountFactory.CreateAccount(Console.ReadLine());
            acc.AccountNo = 123;
            acc.HolderName = "Vinod Kumar";
            acc.CalculateInterest();
            Console.WriteLine("The Current Balance : " + acc.Balance);

            ////Runtime polymorphism
            //acc = new FDAccount { AccountNo = 333, HolderName = "Rajesh Kumar" };
            //acc.CalculateInterest();
            //Console.WriteLine("The Current Balance : " + acc.Balance);

        }
    }
}