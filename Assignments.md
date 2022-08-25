## Assignment 1
Implement the body for the following function:

static boolean isValidDate(int year, int month, int day) {
	// do stuff here
	return false;
}
The function should check if the parameter values constitute a valid calendar date or not. Accordingly return true or false.

For example,

year=2018, month=13, day=1 is an invalid date as the possible values for month is 1 to 12.
year=2018, month=2, day=29 is an invalid date as the maximum days in February is 28 in the year 2018
year=2016, month=2, day=29 is a valid date.
Write a Java program to call the above function multiple times with different values.

Assignment 2
Implement the body for the following function:

static boolean isPrimeNumber(int num) {
	// do stuff here
	return false;
}
The function should check and return true only if the number passed as argument is a prime number.

Write a Java program to call the above function multiple times with different values.

Assignment 3
Write a function called "sumOfPrimes", that takes two integers as input and returns the sum of all the prime numbers between the same.

public static int sumOfPrimes(int from, int to) {
	// do stuff here
	return 0;
}
Write a Java program to call the above function multiple times with different values.

Assignment 4
Write a Java program to print the following pattern:

*
**
***
****
*****
The number of rows should be based on the value of a variable "num", and the number of stars in a row is based on the row number itself.

Assignment 5
In trignometry, the Sine of an angle is represented by the series below:



Write a Java function that accepts angle in degrees and returns the sine of the given angle.

Call the function in main, multiple times by supplying multiple values and verify the same.

PS:

Divide the function into small reusable functions, if possible.
Do not use builtin Java classes like Math
Inside the sine function, use a loop that iterates for n times (for example 10)
Assignment 6
Implement the Java function listed below:

public static void printCalendar(int month, int year) {
	/// do stuff here
}
The function should accept month and year and print the calendar for the same. If inputs are invalid, appropriate error message/s should be printed.

Sample output for the inputs (8, 2018):

Su Mo Tu We Th Fr Sa
          1  2  3  4
 5  6  7  8  9 10 11
12 13 14 15 16 17 18
19 20 21 22 23 24 25
26 27 28 29 30 31
PS:

Do not use any builtin Java classes like Date or Calendar
Divide the function into small reusable functions, if possible.
