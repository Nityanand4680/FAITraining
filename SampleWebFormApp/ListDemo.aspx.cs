using DataComponentLib.DataLayer;
using DataComponentLib.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleWebFormApp
{
    public partial class ListDemo : System.Web.UI.Page
    {
        //This event is triggered when the Page object is loaded into the memory of the App
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)//fills the listbox only first time.
            {
                //Create the object of the Dll Component
                var obj = DataFactory.GetEmployeeManager();
                //Call the method to get all employees
                List<Employee> data = obj.GetAllEmployees();
                //Add the names to the listbox from the employees.  
                lstNames.DataSource = data;
                lstNames.DataTextField = "EmpName";
                lstNames.DataValueField = "EmpId";
                lstNames.DataBind();
            }
        }
        //Event will trigger only when the listbox is set to AutoPostBack
        protected void lstNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            var obj = DataFactory.GetEmployeeManager();
            //Call the method to get all employees
            List<Employee> data = obj.GetAllEmployees();
            var selectedValue = lstNames.SelectedValue;
            foreach (var emp in data)
            {
                if(emp.EmpId.ToString() == selectedValue)
                {
                    txtId.Text = emp.EmpId.ToString();
                    txtAddress.Text = emp.EmpAddress;
                    txtName.Text = emp.EmpName;
                    txtSalary.Text = emp.EmpSalary.ToString();
                    txtDoB.Text = emp.DateOfBirth.ToString("dd/MM/yyyy");
                    txtDept.Text = emp.DeptId.ToString();
                    return;
                }
            }
        }
    }
}