# Assignments
### Assignment 1
Write a program that displays the range of all the floating and integral types of .NET CTS

### Assignment 2
Write a function that takes an array of numbers and it should display the Odd and Even numbers

### Assignment 3
Write a Math Calc Program that allows Users to enter the values and operation and the Program should display the result based on the operator the user has typed. It should be in a loop until the user specifies to close it.

### Assignment 4
Write a function that takes an array of integers as arg and it should display the sum of odd Numbers and the sum of Even numbers from the array.
Call the function in the Main program and call it multiple times to see the valid outputs

### Assignment 5
Write a Function that returns a interest amount for a Principal Amount for a term with a specific rate of interest  Let the inputs for the function be in the form of parameters. 

### Assignment 6
Implement the body for the following function:

```
static boolean isValidDate(int year, int month, int day) { 
	// do stuff here
	return false;
}
```
The function should check if the parameter values constitute a valid calendar date or not. Accordingly return true or false.

For example,

year=2018, month=13, day=1 is an invalid date as the possible values for month is 1 to 12.

year=2018, month=2, day=29 is an invalid date as the maximum days in February is 28 in the year 2018

year=2016, month=2, day=29 is a valid date.

Write a C# program to call the above function multiple times with different values.

### Assignment 7
Implement the body for the following function:
```
static boolean isPrimeNumber(int num) {
	// do stuff here
	return false;
}
```
The function should check and return true only if the number passed as argument is a prime number.

Write a C# program to call the above function multiple times with different values.

### Assignment 8
Implement the C# function listed below:
```
public static void printCalendar(int month, int year) {
	/// do stuff here
}
```
The function should accept month and year and print the calendar for the same. If inputs are invalid, appropriate error message/s should be printed.

Sample output for the inputs (8, 2018):
![image](https://user-images.githubusercontent.com/79626160/186892071-5a8bf6da-4795-44a7-97e5-f2a382714c87.png)

PS:
Do not use any builtin C# classes like DateTime
Divide the function into small reusable functions, if possible.

### Assignment 9
Write a function called "reverseByWords", that takes a sentence (string) as an input, and returns another string. The return value must be a sentence in which the words in the original sentence appear in reverse order.
```
public static string reverseByWords(string sentence) {
	// do stuff here
	return null;
}
```
For example,

String out = reverseByWords("my name is vinod and i live in bangalore");


// the variable "out" should be equal to "bangalore in live i and vinod is name my".


Call the function in main, multiple times by supplying multiple values and verify the same.

### Assignment 10
Write a function called "inWords" that takes a number between 1 and 99,99,99,999 and returns a String representing the input number in words.
```
public static String inWords(int num) {
	// do stuff here
	return null;
}
```
For example,

inWords(12345);
// should return "twelve thousand three hundred forty five"

inWords(10203040);
// should return "one crore two lakh three thousand forty"

inWords(101);
// should return "one hundred one"

Call the function in main, multiple times by supplying multiple values and verify the same.
### Assignment 11
Create a Console App that stores the Customer Records into an Array.

The App should allow the User to Add, Remove, Update and Find the Customers by ID.

The App should be a menu-driven App that allows the user to choose an option and perform the expected operation. The App should not terminate at any point unless chosen by the User. 

Make the App Interactive with User inputs coming from Console. 

Hint:
Create separate classes for Customer, CustomerRepo which have functions of Operations, and UI Class that will handle the UI of the Application. 

Make the App as modular as possible.
