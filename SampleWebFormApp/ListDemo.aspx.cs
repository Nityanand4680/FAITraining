using DataComponentLib.DataLayer;
using DataComponentLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleWebFormApp
{
    public partial class ListDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGet_Click(object sender, EventArgs e)
        {
            //Create the object of the Dll Component
            var obj = DataFactory.GetEmployeeManager();
            //Call the method to get all employees
            List<Employee> data = obj.GetAllEmployees();
            //Add the names to the listbox from the employees.  
            foreach (var emp in data)
                lstNames.Items.Add(emp.EmpName);
        }
    }
}