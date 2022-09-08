using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleWebFormApp
{
    public partial class HomePage : System.Web.UI.Page
    {

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
            //Take the values entered by the user into the controls.
            var name = txtName.Text;
            var address = txtAddress.Text;
            var salary = txtSalary.Text;

            var strContent = $"The Name: {name}<br/>The Address: {address}<br/>The Salary: {salary:C}";

            lblDisplay.Text = strContent;
        }
    }
}