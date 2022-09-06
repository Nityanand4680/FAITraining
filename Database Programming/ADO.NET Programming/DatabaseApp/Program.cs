
/*
 * .NET Apps communicate with databases using a technology called ADO.NET
 * Communication can happen using Connected and Disconnected Model.
 * In Connected Model, the App will be connected to the database while the operations are conducted. 
 * System.Data.SqlClient is the namespace that is required for Sql Server based Data interactions. 
 * Important classes: SqlConnection, SqlCommand and SqlDataReader. 
 * SqlConnection: Contains the functionalities of connecting to the database. 
 * SqlCommand: Contains the APIs for executing the SQL Commands for the associated Database Connection.
 * SqlDataReader: Reads the data as a Result of a successful Select statement executed by the SqlCommand. 
 * 
 */

using System.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace DatabaseApp
{
    class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public double EmpSalary { get; set; }
        public  DateTime EmpBirthDate { get; set; }
        public int DeptId { get; set; }
        public override string ToString()
        {
            return $"{EmpName}  from {EmpAddress} born on {EmpBirthDate.ToLongDateString()} earns a Salary of {EmpSalary}";
        }
    }

    interface IDataComponent
    {
        Employee[] GetAllEmployees();
    }


    class DataComponent : IDataComponent
    {

        private Employee createEmployee(SqlDataReader reader)
        {
            var emp = new Employee();
            emp.EmpId = Convert.ToInt32(reader[0]);
            emp.EmpName = reader["EmpName"].ToString();
            emp.EmpAddress = reader[2].ToString();
            emp.EmpSalary = Convert.ToDouble(reader[3]);
            emp.EmpBirthDate = Convert.ToDateTime(reader[4]);
            emp.DeptId = Convert.ToInt32(reader[5]);
            return emp;
        }
        const string strConnection = @"Data Source=.\SQLEXPRESS;Initial Catalog=FaiTraining;Integrated Security=True";
        public Employee[] GetAllEmployees()
        { 
            var list = new List<Employee>();
            using (var connection = new SqlConnection(strConnection))
            {
                using(var cmd = new SqlCommand("SELECT * FROM EMPTABLE", connection))
                {
                  
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            //Add to the collection.
                            list.Add(createEmployee(reader));
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                } 
                return list.ToArray();
            }

        }
    }
    class Program
    {
        const string query = "SELECT * FROM EMPTABLE";


        static void Main(string[] args)
        {
            //displayRecords();
            var records = new DataComponent().GetAllEmployees();
            if(records != null)
            {
                foreach(var rec in records)
                    Console.WriteLine(rec);
            }
        }

        private static void displayRecords()
        {
            var connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=FaiTraining;Integrated Security=True";
            //string info about the database connectivity is connectionstring. 
            string query = "SELECT * FROM EMPTABLE"; //query to execute
            using (var connection = new SqlConnection(connectionString))//Create the connection object to connect to db
            {
                var command = new SqlCommand(query, connection);//Command object to execute SQL Commands
                try
                {
                    connection.Open();//Open the connection
                    var reader = command.ExecuteReader();//Executes the Command that returns a Reader object
                    while (reader.Read())//Read each row
                        Console.WriteLine($"Name: {reader[1]}\tAddress: {reader[2]}");//Display the specific columns. 
                }
                catch (SqlException ex)//If any exceptions Catch it...
                {
                    Console.WriteLine(ex.Message);//Display the error message
                }
            }
        }
    }
}
