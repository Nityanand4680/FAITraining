using System;
using System.IO;
/*
 *Files are external resources stored in the hardware of the machine which we access using the OS. They are all low level APIs
 *.NET offers a bunch of classes to access the files and perform all kinds of operations on the FileSystem of the OS. 
 *System.IO is the namespace required for all IO operations. 
 *Streams are contigenous memory that is unidirectional for transfering the data from the source to its destination. Anything that comes out of UR App is called OutputStream and anything that comes into UR App is called as InputStream. 
 *If U R working with files, we have a class called FileStream to perform the operations.
 *To work with Text files, we have StreamReader and StreamWriter to perform read-write operations on text based files. 
 *There is a static class called File with which U can perform reading, writing, creating and many more operations. 
 */
namespace SampleConApp
{
    class Employee
    {
        static int empNo = 1000;
        public Employee()
        {
            EmpID = ++empNo;
        }

        public Employee(int id)
        {
            EmpID = id;
        }
        public int EmpID { get; private set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public int EmpSalary { get; set; }
        public override string ToString()
        {
            return $"{EmpName} with ID {EmpID} from {EmpAddress} earns a salary of Rs. {EmpSalary}";
        }
    }
    class FileIODemo
    {
        const string fileName = "EmployeeDetails.txt";
        static void writeToFile(Employee emp)
        {
            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fs);
            writer.WriteLine($"{emp.EmpID},{emp.EmpName},{emp.EmpAddress},{emp.EmpSalary}");
            writer.Close();
            fs.Close();
        }

        static Employee readFromFile()
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(fs);
            string data = reader.ReadLine();
            string[] details = data.Split(',');
            Employee emp = new Employee(int.Parse(details[0]));
            emp.EmpName = details[1];
            emp.EmpAddress = details[2];
            emp.EmpSalary = int.Parse(details[3]);
            fs.Close();
            return emp;
        }
        static void Main(string[] args)
        {
            //            writeToFile(new Employee { EmpName = "Phaniraj", EmpAddress = "Bangalore", EmpSalary = 67000 });
            Console.WriteLine(readFromFile());
        }
    }
}