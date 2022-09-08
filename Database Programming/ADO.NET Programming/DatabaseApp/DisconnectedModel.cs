namespace DisconnectedDemo
{
    using System.Data.SqlClient;//For SQL Server related classes
    using System.Data; // For DataSet and DataTables.
    using System.Configuration;
    using System;
    using System.Collections.Generic;

    class Employee
    {
        public int EmpID { get; set; }
        public string EmpAddress { get; set; }
        public string EmpName { get; set; }
    }
    static class MainProgram
    {
        const string STRQUERY = "SELECT * FROM EMPTABLE";
        static readonly string STRCONNECTION = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        static DataSet ds = new DataSet("MyData");
         
        //Ds has a collection of DataTable objects where each DataTable object has a collection of DataRows and DataColumns. 

        static List<Employee> getAllEmployees()
        {
            List<Employee> list = new List<Employee>();
            if(ds.Tables["mySetOfEmployees"] == null)
            {
                Console.WriteLine("The data is not filled into the dataset");
            }
            else
            {
                foreach(DataRow row in ds.Tables["mySetOfEmployees"].Rows)
                {
                    var emp = new Employee();
                    emp.EmpID = Convert.ToInt32(row[0]);
                    emp.EmpName = row[1].ToString();
                    emp.EmpAddress = row[2].ToString();
                    list.Add(emp);
                }
            }
            return list;
        }

        static void addEmployeesToCache()
        {
            //Get all the data from the database
            var con = new SqlConnection(STRCONNECTION);
            var cmd = new SqlCommand(STRQUERY, con);
            SqlDataAdapter ada = new SqlDataAdapter(cmd);
            ada.Fill(ds, "mySetOfEmployees"); //Now to fill the data into the DataSet. Fill is a smart method, it opens the closed connection, fills the data into the specific table of the dataset and immediately closes the connection. 
        }

        static void addDeptToCache()
        {
            var adapter = new SqlDataAdapter("SELECT * FROM DEPTTABLE", STRCONNECTION);
            adapter.Fill(ds, "myDeptTable");

        }
        
        static void updateRecordToDatabase()
        {
            var adapter = new SqlDataAdapter("SELECT * FROM EMPTABLE", STRCONNECTION);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            if (ds.Tables.Contains("MyEmpList"))//If its already there, remove it. 
            {
                ds.Tables.Remove("MyEmpList");//Delete the Table from the DS....
            }
            adapter.Fill(ds, "MyEmpList");//Get the fresh data...
            //Create the values.
            var name = "Jim Anderson";
            var address = "London";
            var salary = 56000;
            var deptId = 4;
            var id = 125;
            var dob = new DateTime(1965, 7, 20);
            foreach(DataRow row in ds.Tables["MyEmpList"].Rows)
            {
                if(Convert.ToInt32(row[0]) == id)
                {
                    row[1] = name;
                    row[2] = address;
                    row[3] = salary;
                    row[4] = dob;
                    row[5] = deptId;
                    adapter.Update(ds, "MyEmpList");
                    return;
                }
            }
        }
        static void addingRecordToDatabase()
        {
            var adapter = new SqlDataAdapter("SELECT * FROM EMPTABLE", STRCONNECTION);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Fill(ds, "MyEmpList");//Another DataTable..
            //Create the values.
            var name = "Jim Rogerrson";
            var address = "New York";
            var salary = 56000;
            var deptId = 4;
            var dob = new DateTime(1965, 7, 20);

            //Create a new Row in the dataset. 
            DataRow row = ds.Tables["MyEmpList"].NewRow();
            Console.WriteLine(row.RowState);
            //Fill the rows with the data. 
            row[1] = name;
            row[2] = address;
            row[3] = salary;
            row[4] = dob;
            row[5] = deptId;
            //Add the filled row into the Rows Collection of the table
            ds.Tables["MyEmpList"].Rows.Add(row);
            Console.WriteLine(row.RowState);

            adapter.Update(ds, "MyEmpList");

        }
        static void Main(string[] args)
        {

            addEmployeesToCache();
            ////addDeptToCache();
            //var list = getAllEmployees();
            //foreach (var emp in list) 
            //    Console.WriteLine(emp.EmpName);
            //Console.WriteLine("----------------Display All Tables-----------------");
            //foreach(DataTable table in ds.Tables)
            //    Console.WriteLine(table.TableName);

            addingRecordToDatabase();
            updateRecordToDatabase();
        }
    }
}