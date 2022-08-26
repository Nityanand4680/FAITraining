/*
 * Serialization is a feature of persisting the object of a class to a storage device like a file instead of storing only the data. Object storage is required when U want to retain the state of the object in the same manner on how it was persisted. 
 * Serialization is primarily used in IPC Apps where the objects are shared b.w the Applications. 
 * There are 3 forms of serialization in .NET:
 * Binary Serialization, XML Serialization and SOAP Serialization. 
 * Binary Serialization is used within the Windows OS. XML is used for Cross Operating System. SOAP is used for Web services.
 * For any serialization U need three things: Place of storage, Format of Storage and Data to store. 
 * For Binary Serialization, the Class must be having an attribute called [Serializable]. This attribute is set for the class whose objects are to be serialized. 
 * For XML serialization, U should make the class as public. 
 */
using System; //Default namespace
using System.Collections.Generic;//For Generic collection classes
using System.IO;//For File IO classes
using System.Runtime.Serialization.Formatters.Binary; //For BinaryFormatter class
using System.Xml.Serialization;//For XmlSerializer

namespace SampleConApp
{
    class Ex20_SerializationDemo
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

        static void saveAsXml(List<Employee> empList)
        {
            var fs = new FileStream("Data.xml", FileMode.OpenOrCreate, FileAccess.Write);
            var formatter = new XmlSerializer(typeof(List<Employee>));//Should privide the Type Info of the class that U R serializing. 
            formatter.Serialize(fs, empList);
            fs.Close();
        }

        static List<Employee> loadXmlData()
        {
            var fs = new FileStream("Data.xml", FileMode.Open, FileAccess.Read);
            var formatter = new XmlSerializer(typeof(List<Employee>));//Should privide the Type Info of the class that U R serializing. 
            var list = formatter.Deserialize(fs) as List<Employee>;
            fs.Close();
            return list;
        }

        static void Main(string[] args)
        {
            //BinarySave(createEmployee());
            //ReadData();
            List<Employee> empList = new List<Employee>();
            empList.Add(new Employee { EmpName = "Ramesh", EmpAddress = "Mysore", EmpSalary = 56000 });
            empList.Add(new Employee { EmpName = "Aravind", EmpAddress = "Tumkur", EmpSalary = 46000 });
            empList.Add(new Employee { EmpName = "Suresh", EmpAddress = "Dharwad", EmpSalary = 56000 });
            empList.Add(new Employee { EmpName = "Gopal", EmpAddress = "Chennai", EmpSalary = 45000 });
            saveAsXml(empList);//For saving
            
            empList = loadXmlData();
            foreach (var emp in empList) Console.WriteLine(emp.EmpName);
        }
    }
}