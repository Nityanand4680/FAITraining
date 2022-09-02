using SampleConApp.DataLayer;
using SampleConApp.MiddleLayer;
using System;
using System.Collections.Generic;
using System.Data;

namespace SampleConApp
{
    namespace UILayer
    {
        class MainClass
        {
            static IEmpBusinessComponent component = BusinessFactory.GetComponent();

            static void Main(string[] args)
            {
                if (component == null) Console.WriteLine("No COMPONENT IS INTEGRATED INTO THE APP!!!");
            }
        }
    }

    namespace MiddleLayer
    {
        static class BusinessFactory
        {
            public static IEmpBusinessComponent GetComponent() => new MySimpleEmpBusComponent(new FileDataComponent());
        }
        class Employee
        {
            public int EmpID { get; set; }
            public string EmpName { get; set; }
            public string EmpAddress { get; set; }
            public double EmpSalary { get; set; }
        }

        interface IEmpBusinessComponent
        {
            void AddNewEmployee(Employee emp);
            void UpdateEmployee(Employee emp);

            void DeleteEmployee(int id);

            List<Employee> GetAllEmployees();
        }

        class MySimpleEmpBusComponent : IEmpBusinessComponent
        {
            private IDataLayer _component;

            public MySimpleEmpBusComponent(IDataLayer component)
            {
                if (component == null) throw new Exception("Dal Component is not yet created");
                _component = component;
            }

            public void AddNewEmployee(Employee emp)
            {
                //Check the emp object for allthe business rules. 
                _component.AddNewEmployee(emp.EmpName, emp.EmpAddress, emp.EmpSalary);
            }

            public void DeleteEmployee(int id)
            {
                _component.DeleteEmployee(id);
            }

            public List<Employee> GetAllEmployees()
            {
                var list = new List<Employee>();
                var data = _component.GetAllEmployees();
                //Convert the row of the table to a Employee object and added to the list. 
                foreach(DataRow row in data.Rows)
                {
                    var emp = new Employee
                    {
                        EmpID = Convert.ToInt32(row[0]),
                        EmpName = row[1].ToString(),
                        EmpAddress = row[2].ToString(),
                        EmpSalary = Convert.ToDouble(row[3])
                    };
                    list.Add(emp);
                }
                return list;
            }

            public void UpdateEmployee(Employee emp)
            {
                _component.UpdateEmployee(emp.EmpID, emp.EmpName, emp.EmpAddress, emp.EmpSalary);
            }
        }
    }

    //Stores the data in a raw format:
    namespace DataLayer
    {
        using System.Data;
        interface IDataLayer
        {
            int AddNewEmployee(string name, string address, double salary);//Returns the id of the added emp
            void UpdateEmployee(int id, string name, string address, double salary);
            void DeleteEmployee(int id);

            DataTable GetAllEmployees();
        }

        class FileDataComponent : IDataLayer
        {
            public int AddNewEmployee(string name, string address, double salary)
            {
                throw new NotImplementedException();
            }

            public void DeleteEmployee(int id)
            {
                throw new NotImplementedException();
            }

            public DataTable GetAllEmployees()
            {
                throw new NotImplementedException();
            }

            public void UpdateEmployee(int id, string name, string address, double salary)
            {
                throw new NotImplementedException();
            }
        }
    }
}