using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SampleDll
{

    [Serializable]
    public class MyTestException : Exception
    {
        public MyTestException() { }
        public MyTestException(string message) : base(message) { }
        public MyTestException(string message, Exception inner) : base(message, inner) { }
       
    }

    /// <summary>
    /// Represents the Test of the Application
    /// </summary>
    public class Test
    {
        public int TestId { get; set; }
        public string TestName { get; set; }
        public double TestAmount { get; set; }
        public DateTime TestDate { get; set; }
    }

    /// <summary>
    /// This component contains data manipulation APIs to be used by the Front End Developers.
    /// </summary>
    public class TestDataComponent
    {
        #region CONSTANTS
        const string insertProc = "FaiTraining_InsertTest";
        const string updateProc = "FaiTraining_UpdateTest";
        const string deleteStatement = "DELETE FROM TESTTABLE WHERE TESTID = @id";
        const string findByDateSt = "SELECT * FROM TESTTABLE WHERE TESTDATE = @date";
        const string findById = "SELECT * FROM TESTTABLE WHERE TESTID = @id";
        #endregion


        static readonly string STRCONNECTION = ConfigurationManager.ConnectionStrings["myTestConnection"].ConnectionString;

        /// <summary>
        /// Adds a new Test to the data source
        /// </summary>
        /// <exception cref="TestApp.MyTestException/>"
        /// <param name="test">The Test object to Add</param>
        public void AddNewTest(Test test)
        {
            //break the test Object into local variables. 
            var name = test.TestName;
            var amount = test.TestAmount;
            var date = test.TestDate;
            var id = 0;
            //Create the Connection and Command object.
            var conn = new SqlConnection(STRCONNECTION);
            var cmd = new SqlCommand(insertProc, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tAmount", amount);
            cmd.Parameters.AddWithValue("@tName", name);
            cmd.Parameters.AddWithValue("@tDate", date);
            cmd.Parameters.AddWithValue("@tId", id);
            cmd.Parameters[3].Direction = ParameterDirection.Output;

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();//returns the no of rows affected. 
                
            }
            catch (SqlException ex)
            {
                throw new MyTestException("Insertion failed", ex);
            }
            finally
            {
                if(conn.State == ConnectionState.Open)
                   conn.Close();
                conn.Dispose();
            }
        }

        public void UpdateTest(Test test)
        {
            //break the test Object into local variables. 
            var name = test.TestName;
            var amount = test.TestAmount;
            var date = test.TestDate;
            var id = test.TestId;
            //Create the Connection and Command object.
            var conn = new SqlConnection(STRCONNECTION);
            var cmd = new SqlCommand(updateProc, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tAmount", amount);
            cmd.Parameters.AddWithValue("@tName", name);
            cmd.Parameters.AddWithValue("@tDate", date);
            cmd.Parameters.AddWithValue("@tId", id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();//returns the no of rows affected. 

            }
            catch (SqlException ex)
            {
                throw new MyTestException($"Updation failed for the Test {test.TestId}", ex);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Dispose();
            }
        }

        public void DeleteTest(int id)
        {
            //Create the Connection and Command object.
            var conn = new SqlConnection(STRCONNECTION);
            var cmd = new SqlCommand(deleteStatement, conn);
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();//returns the no of rows affected. 

            }
            catch (SqlException ex)
            {
                throw new MyTestException("Deletion failed", ex);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Dispose();
            }
        }

        public List<Test> FindTest(DateTime dt)
        {
            List<Test> allTests = new List<Test>();
            var conn = new SqlConnection(STRCONNECTION);
            var cmd = new SqlCommand(findByDateSt, conn);
            cmd.Parameters.AddWithValue("@date", dt.ToString("MM/dd/yyyy"));
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //create a Test object for each row...
                    var test = new Test();
                    test.TestId = Convert.ToInt32(reader[0]);
                    test.TestAmount = Convert.ToDouble(reader["TestAmount"]);
                    test.TestDate = Convert.ToDateTime(reader["TestDate"]);
                    test.TestName = reader["TestName"].ToString();
                    //Add it to the List...
                    allTests.Add(test);
                }
            }
            catch (SqlException ex)
            {
                throw new MyTestException("Cannot get the Tests", ex);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return allTests;
        }

        public Test FindTest(int id)
        {
            Test test = new Test();
            var conn = new SqlConnection(STRCONNECTION);
            var cmd = new SqlCommand(findById, conn);
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //create a Test object for each row...
                    test = new Test();
                    test.TestId = Convert.ToInt32(reader[0]);
                    test.TestAmount = Convert.ToDouble(reader["TestAmount"]);
                    test.TestDate = Convert.ToDateTime(reader["TestDate"]);
                    test.TestName = reader["TestName"].ToString();
                }
            }
            catch (SqlException ex)
            {
                throw new MyTestException("Cannot get the Tests", ex);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return test;
        }
    }
}
