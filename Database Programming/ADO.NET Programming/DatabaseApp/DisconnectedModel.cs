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
        
        static void Main(string[] args)
        {

            addEmployeesToCache();
            //addDeptToCache();
            var list = getAllEmployees();
            foreach (var emp in list) 
                Console.WriteLine(emp.EmpName);
            //Read the data from the dataset...
            //foreach(DataRow row in ds.Tables["mySetOfEmployees"].Rows)
            //{
            //    Console.WriteLine($"{row[1].ToString().ToUpper()} is from {row["EmpAddress"]}");
            //}
            Console.WriteLine("---------------------------------");
            foreach(DataTable table in ds.Tables)
                Console.WriteLine(table.TableName);
        }
    }
}