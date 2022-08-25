using System;
//Custom Exception class is created by deriving with a class called ApplicationException. 
namespace SampleConApp
{
    class InvalidPriceException : ApplicationException
    {
        public InvalidPriceException()
        {
            //default constructor
        }
        public InvalidPriceException(string msg) : base(msg)
        {

        }
    }
    class Product
    {
        static int count = 1000;
        public Product()
        {
            ProductId = ++count;
        }
        public int ProductId { get; private set; }
        public string ProductName { get; set; }
        private int _price;
        /// <summary>
        /// Gets or Sets the Price of the Product
        /// </summary>
        /// <exception cref="SampleConApp.InvalidPriceException"/>
        public int Price
        {
            get { return _price; }
            set
            {
                if (value < 100)
                {
                    throw new InvalidPriceException("Price should be more than 100");
                }
                _price = value;
            }
        }
        public int Quantity { get; set; }
        public override string ToString()
        {
            return $"{ProductName}, {Price}, {Quantity}";
        }
    }
    class Ex17_CustomExceptionDemo
    {
        static void Main(string[] args)
        {
            Product p = new Product();
            p.ProductName = "Tennis Racquet";
            p.Quantity = 100;
            RETRY:
            try
            {
                Console.WriteLine("Enter the Price");
                p.Price = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Price should be number");
                goto RETRY;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Number is not in the range of a Integer");
                goto RETRY;
            }
            catch (InvalidPriceException ex)
            {
                Console.WriteLine(ex.Message);
                goto RETRY;
            }

            Console.WriteLine("The Details of the Product: " + p);
        }

    }
}
