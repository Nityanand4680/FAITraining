using DataComponentLib.Common;
using DataComponentLib.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataComponentLib
{
    namespace Entities
    {
        public class Employee
        {
            public int EmpId { get; set; }
            public string EmpName { get; set; }
            public string EmpAddress { get; set; }
            public double EmpSalary { get; set; }
            public int DeptId { get; set; }
            public DateTime DateOfBirth { get; set; }
        }

        public class Department
        {
            public int DeptId { get; set; }
            public string DeptName { get; set; }
        }
    }

    namespace Common
    {

        public class EmployeeManagerException : Exception
        {
            public EmployeeManagerException() { }
            public EmployeeManagerException(string message) : base(message) { }
            public EmployeeManagerException(string message, Exception inner) : base(message, inner) { }
           
        }    
    }

    namespace DataLayer
    {
        public interface IEmployeeManager
        {
            void AddNewEmployee(string name, string address, DateTime date, int deptId, double salary);
            void UpdateEmployee(Employee emp);
            List<Employee> GetAllEmployees();
            void DeleteEmployee(int id);
            List<Department> GetAllDepartments();
        }

        class EmployeeManager : IEmployeeManager
        {
            #region CONSTANTS AND READ ONLY
            static readonly string STRCONNECTION = ConfigurationManager.ConnectionStrings["myCon"].ConnectionString;

            const string insertProc = "Fai_InsertEmployee";
            const string updateProc = "Fai_UpdateEmployee";
            const string selectProc = "Fai_SelectAll";
            const string deleteStatement = "DELETE FROM EMPTABLE WHERE EMPID = @empId";
            const string selectDept = "SELECT * FROM DEPTTABLE";


            #endregion

            static SqlConnection sqlCon = new SqlConnection(STRCONNECTION);
            public void AddNewEmployee(string name, string address, DateTime date, int deptId, double salary)
            {
                int generatedId = 0;
                using(SqlCommand cmd = new SqlCommand(insertProc, sqlCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@salary", salary);
                    cmd.Parameters.AddWithValue("@deptId", deptId);
                    cmd.Parameters.AddWithValue("@dob", date);
                    cmd.Parameters.AddWithValue("@empId", generatedId);
                    cmd.Parameters[5].Direction = ParameterDirection.Output;

                    try
                    {
                        if(sqlCon.State != ConnectionState.Open)
                        {
                            sqlCon.Open();
                        }
                        cmd.ExecuteNonQuery();
                    }
                    catch(SqlException ex)
                    {
                        throw new EmployeeManagerException("Adding the Employee has Failed", ex);
                    }
                    finally
                    {
                        if (sqlCon.State != ConnectionState.Closed)
                        {
                            sqlCon.Close();
                        }
                    }

                }
            }

            public void DeleteEmployee(int id)
            {
                using (SqlCommand cmd = new SqlCommand(deleteStatement, sqlCon))
                {
                    cmd.Parameters.AddWithValue("@empId", id);
                    try
                    {
                        if (sqlCon.State != ConnectionState.Open)
                        {
                            sqlCon.Open();
                        }
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        throw new EmployeeManagerException("Deleting the Employee has Failed", ex);
                    }
                    finally
                    {
                        if (sqlCon.State != ConnectionState.Closed)
                        {
                            sqlCon.Close();
                        }
                    }
                }
            }

            public List<Department> GetAllDepartments()
            {
                List<Department> departments = new List<Department>();
                using (SqlCommand cmd = new SqlCommand(selectDept, sqlCon))
                {
                    try
                    {
                        if (sqlCon.State != ConnectionState.Open)
                        {
                            sqlCon.Open();
                        }
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            var dept = new Department
                            {
                                DeptId = Convert.ToInt32(reader[0]),
                                DeptName = Convert.ToString(reader[1])
                            };
                            departments.Add(dept);
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new EmployeeManagerException("Failed to get the Departments, See Inner Exceptions for details", ex);
                    }
                    finally
                    {
                        if (sqlCon.State != ConnectionState.Closed)
                        {
                            sqlCon.Close();
                        }
                    }

                    return departments;
                }
            }
            public List<Employee> GetAllEmployees()
            {
                List<Employee> employees = new List<Employee>();
                using (SqlCommand cmd = new SqlCommand(selectProc, sqlCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        if (sqlCon.State != ConnectionState.Open)
                        {
                            sqlCon.Open();
                        }
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            var emp = new Employee
                            {
                              DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                              DeptId = Convert.ToInt32(reader["DeptId"]),
                              EmpAddress = Convert.ToString(reader["EmpAddress"]),
                              EmpId = Convert.ToInt32(reader[0]),
                              EmpName = Convert.ToString(reader[1]),
                              EmpSalary = Convert.ToDouble(reader["EmpSalary"])
                            };
                            employees.Add(emp);
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new EmployeeManagerException("Failed to get the Employees, See Inner Exceptions for details", ex);
                    }
                    finally
                    {
                        if (sqlCon.State != ConnectionState.Closed)
                        {
                            sqlCon.Close();
                        }
                    }

                    return employees;
                }
            }

            public void UpdateEmployee(Employee emp)
            {
                using (SqlCommand cmd = new SqlCommand(updateProc, sqlCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", emp.EmpName);
                    cmd.Parameters.AddWithValue("@address", emp.EmpAddress);
                    cmd.Parameters.AddWithValue("@salary", emp.EmpSalary);
                    cmd.Parameters.AddWithValue("@deptId", emp.DeptId);
                    cmd.Parameters.AddWithValue("@dob", emp.DateOfBirth);
                    cmd.Parameters.AddWithValue("@empId", emp.EmpId);
                    try
                    {
                        if (sqlCon.State != ConnectionState.Open)
                        {
                            sqlCon.Open();
                        }
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        throw new EmployeeManagerException("Updating the Employee has Failed", ex);
                    }
                    finally
                    {
                        if (sqlCon.State != ConnectionState.Closed)
                        {
                            sqlCon.Close();
                        }
                    }

                }
            }
        }

        public static class DataFactory
        {
            public static IEmployeeManager GetEmployeeManager() => new EmployeeManager();
        }
    }
}
