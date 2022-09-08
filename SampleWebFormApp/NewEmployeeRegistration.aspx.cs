using DataComponentLib.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleWebFormApp
{
    public partial class NewEmployeeRegistration : System.Web.UI.Page
    {
        //Use this to set values to the controls of the ASP.NET Web Page. 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var com = DataFactory.GetEmployeeManager();
                var depts = com.GetAllDepartments();
                dpDepts.DataSource = depts;
                dpDepts.DataTextField = "DeptName";
                dpDepts.DataValueField = "DeptId";
                dpDepts.DataBind();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    var name = txtName.Text;
                    var address = txtAddress.Text;
                    var salary = double.Parse(txtSalary.Text);
                    var dept = int.Parse(dpDepts.SelectedValue);
                    var dob = DateTime.Parse(txtDate.Text);

                    var com = DataFactory.GetEmployeeManager();
                    com.AddNewEmployee(name, address, dob, dept, salary);
                    Response.Redirect("./ListDemo.aspx");
                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                }
            }
        }
    }
}