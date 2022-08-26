/*
 * Serialization is a feature of persisting the object of a class to a storage device like a file instead of storing only the data. Object storage is required when U want to retain the state of the object in the same manner on how it was persisted. 
 * Serialization is primarily used in IPC Apps where the objects are shared b.w the Applications. 
 * There are 3 forms of serialization in .NET:
 * Binary Serialization, XML Serialization and SOAP Serialization. 
 * Binary Serialization is used within the Windows OS. XML is used for Cross Operating System. SOAP is used for Web services.
 * For any serialization U need three things: Place of storage, Format of Storage and Data to store. 
 */
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace SampleConApp
{
    class SerializationDemo
    {
        static void BinarySave(Employee emp)//Employee class comes from Ex19 file..
        {
            //Data to save: Employee object
            //Where to save: FileStream.
            FileStream fs = new FileStream("Emp.bin", FileMode.OpenOrCreate, FileAccess.Write);
            //How to save:
            BinaryFormatter fm = new BinaryFormatter();
            fm.Serialize(fs, emp);
            fs.Close();
        }

        static void ReadData()
        {
            //Data to save: Employee object
            //Where to save: FileStream.
            FileStream fs = new FileStream("Emp.bin", FileMode.Open, FileAccess.Read);
            //How to save:
            BinaryFormatter fm = new BinaryFormatter();
            object data = fm.Deserialize(fs);
            fs.Close();
            if(data is Employee)
            {
                var emp = data as Employee;
                Console.WriteLine(emp);
            }
          
        }

        static Employee createEmployee()
        {
            var id = Util.GetNumber("Enter the ID of the Employee");
            var name = Util.GetString("Enter the Name of the Employee");
            var address = Util.GetString("Enter the Address of the Employee");
            var salary = Util.GetNumber("Enter the Salary");
            var emp = new Employee(id)
            {
                EmpName=name, EmpAddress = address, EmpSalary = salary
            };

            return emp;
        }
        static void Main(string[] args)
        {
            //BinarySave(createEmployee());
            ReadData();
        }
    }
}