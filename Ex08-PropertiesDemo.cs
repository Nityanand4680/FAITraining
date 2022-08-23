using System;
/*
 * Properties are data accessors with get/set blocks for the fields.
 * Fields are usually private to the class. 
 * To access the private fields we use properties with get block or set block, sometimes both. 
 */


namespace SampleConApp
{
    class Book
    {
        int _id;//default is private in C#...
        string _title;
        string _author;
        double _price;

        public int BookID
        {
            get { return _id; }
            set 
            { 
                if(value <= 0)
                    throw new Exception("ID cannot be less than or equal to 0");
                _id = value; 
            }
        }
        //New in C#, we can use Lambda Operator => 
        public string Title { get => _title; set => _title = value; }
        public string Author { get => _author; set => _author = value; }
        public double Price { get => _price; set => _price = value; }
    }
    class PropertiesDemo
    {
        static void Main(string[] args)
        {
            Book book = new Book();//create the instance of the class.
            book.BookID = 123;//set the values for the properties
            book.Title = "Professional C#";
            book.Author = "James Anderson";
            book.Price = 650;

            //Object initialization Syntax of C# 3.5
            Book newBook = new Book { BookID = 123, Price = 567, Author ="Chetan Bhagat", Title="2 States" };
            //With this syntax, U can set the properties in a single line. 

            //Read and display the properties of the book in the console.
            Console.WriteLine($"The Title of the Book is {book.Title} written by {book.Author} that costs {book.Price} and available at ISBN {book.BookID}");

            Console.WriteLine($"The Title of the Book is {newBook.Title} written by {newBook.Author} that costs {newBook.Price} and available at ISBN {newBook.BookID}");
        }

        static void displayBookDetails()
        {
            Book newBook = new Book { BookID = 123, Price = 567, Author = "Chetan Bhagat", Title = "2 States" };
            //Take input from the user on the title.
            Console.WriteLine("Enter the title of the book to search");
            string searchValue = Console.ReadLine();

            //check for the title with our book....
            if(newBook.Title == searchValue)
            {
                Console.WriteLine($"The Title of the Book is {newBook.Title} written by {newBook.Author} that costs {newBook.Price} and available at ISBN {newBook.BookID}");
            }//else tell them that the book is not correct
            else
            {
                Console.WriteLine("Book not found!!!");
            }
        }
    }
}